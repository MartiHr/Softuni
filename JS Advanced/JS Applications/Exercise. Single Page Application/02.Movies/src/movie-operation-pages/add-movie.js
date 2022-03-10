import { showView } from "../router.js";

const addMovieSectionElement = document.getElementById('add-movie');
const formElement = addMovieSectionElement.querySelector('form');
const submitButtonElement = addMovieSectionElement.querySelector('button');

submitButtonElement.addEventListener('click', submitMovie);

const url = 'http://localhost:3030/data/movies';

export function showAddMovie() {
    addMovieSectionElement.style.display = 'block';
}

function submitMovie(e) {
    e.preventDefault();
    
    let formData = new FormData(formElement);

    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');

    if (title && description && imageUrl) {
        let data = {
            title,
            description,
            imageUrl
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.accessToken
            },
            body: JSON.stringify(data),
        })
            .then(res => {
                if (res.status != 200) {
                    throw new Error();
                }

                return res.json();
            })
            .then(data => {
                formElement.reset();
                showView('/');
            })
            .catch(error => alert('Error'));
        
    } else {
        alert('Fill in all input boxes.');
    }
}