import { renderPost } from "./post.js";
import { showView } from "./router.js";

const url = `http://localhost:3030/jsonstore/collections/myboard/posts`;

const homeSectionElement = document.querySelector('.home');
const formElement = homeSectionElement.querySelector('form');
const [cancelButtonElement, postButtonElement] = formElement.querySelectorAll('button');
const topicsContainerElement = homeSectionElement.querySelector('.topic-container');

const date = new Date();

export function showHome() {
    homeSectionElement.style.display = 'block';

    renderPosts();
    cancelButtonElement.addEventListener('click', cancelClick);
    postButtonElement.addEventListener('click', postAPost);
}

function postAPost(e) {
    e.preventDefault();

    let formData = new FormData(formElement);

    let topicName = formData.get('topicName');
    let username = formData.get('username');
    let post = formData.get('postText');
    let currentDate = date.toString();

    if (topicName, username, post) {
        let data = {
            topicName,
            username,
            post,
            date: currentDate
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }
        })
        .catch(error => alert('Error'));

        alert('Added successfully');
        clearForm();
        renderPosts();
    } else {
        alert('Error');
    }
}

function cancelClick(e) {
    e.preventDefault();
    clearForm();
}

function clearForm() {
    formElement.reset();
}

function renderPosts() {

    fetch(url)
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            topicsContainerElement.innerHTML = '';

            Object.values(data).forEach(postData => {
                let postElement = viewPost(postData);

                topicsContainerElement.append(postElement);
            });
        })
        .catch(error => alert('Error'));
}

function viewPost(postData) {
    let postElement = document.createElement('div');
    postElement.classList.add('topic-name-wrapper');

    postElement.innerHTML = `
        <div class="topic-name">
            <a href="/post" class="normal">
                <h2>${postData.topicName}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>${postData.date}</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${postData.username}</span></p>
                    </div>
                </div>
            </div>
        </div>`;

    let aElement = postElement.querySelector('a');
    aElement.setAttribute('id', postData._id);

    aElement.addEventListener('click', (e) => {
        e.preventDefault();

        let url = new URL(e.currentTarget.href);
        let path = url.pathname;

        renderPost(e.currentTarget.id);
        showView(path);
    })

    return postElement;
}