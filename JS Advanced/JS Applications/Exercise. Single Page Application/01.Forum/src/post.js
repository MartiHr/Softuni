const postSectionElement = document.querySelector('.post');
const formElement = postSectionElement.querySelector('form');
const postButtonElement = postSectionElement.querySelector('button');
const postElement = postSectionElement.querySelector('.comment');

const postsUrl = `http://localhost:3030/jsonstore/collections/myboard/posts`;
const commentsUrl = `http://localhost:3030/jsonstore/collections/myboard/comments`;

let date = new Date();

export function showPost() {
    postSectionElement.style.display = 'block';
}

let injectedId = '';

export async function renderPost(id) {
    injectedId = id;

    let wantedPost = await getWantedPost(id);

    postElement.innerHTML = '';
    renderHeader(wantedPost);
    renderUserComments(id);

    postButtonElement.addEventListener('click', postComment);
}

function postComment(e) {
    e.preventDefault();

    let formData = new FormData(formElement);

    let postText = formData.get('postText');
    let username = formData.get('username');
    let ownerId = injectedId;
    let currentDate = date.toString();

    if (postText && username) {
        let data = {
            postText,
            username,
            ownerId,
            date: currentDate
        }

        fetch(commentsUrl, {
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
        renderPost(injectedId);
    } else {
        alert('Error');
    }
}

function clearForm() {
    formElement.reset();
}

function renderUserComments(id) {

    fetch(commentsUrl)
    .then(res => {
        if (res.status != 200) {
            throw new Error();
        }

        return res.json();
    })
    .then(data => {
        Object.values(data)
            .forEach(commentData => {
                if (commentData.ownerId == injectedId) {
                    let commentElement = getUserCommentElement(commentData);
                    postElement.append(commentElement);
                }
            })
    })
    .catch(err => alert('Error'))
}

function getUserCommentElement(data) {
    let divElement = document.createElement('div');
    divElement.classList.add('user-comment');

    divElement.innerHTML = ` <div class="topic-name-wrapper">
    <div class="topic-name">
        <p><strong>${data.username}</strong> commented on <time>${data.date}</time></p>
        <div class="post-content">
            <p>${data.postText}</p>
            </div>
        </div>
    </div>`;

    return divElement;
}

function renderHeader(postData) {
    let headerElement = document.createElement('div');
    headerElement.classList.add('header');

    headerElement.innerHTML= `
        <img src="./static/profile.png" alt="avatar">
        <p><span>${postData.username}</span> posted on <time>${postData.date}</time></p>
        <p class="post-content">${postData.post}</p>`;

    postElement.append(headerElement);
}

async function getWantedPost(id) {
    let posts = Object.values(await getAllPosts());

    return posts.find(x => x._id == id);
}

async function getAllPosts() {
    try {
        let res = await fetch(postsUrl);
        
        if (res.status != 200) {
            throw new Error();
        }

        let data = res.json();

        return data;
    } catch (error) {
        alert('Error')
    }
}