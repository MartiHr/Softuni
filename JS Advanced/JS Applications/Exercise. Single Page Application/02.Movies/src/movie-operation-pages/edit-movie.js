import { showView } from "../router.js";

const movieDetailsElement = document.getElementById('edit-movie');
const formElement = movieDetailsElement.querySelector('form');
const submitButtonElement = movieDetailsElement.querySelector('button');
const [movieTitleElement, imageUrlElement] = movieDetailsElement.querySelectorAll('input');
const movieDescriptionElement = movieDetailsElement.querySelector('textarea');

const url = `http://localhost:3030/data/movies`;

export function editMovieDetails() {
    movieDetailsElement.style.display = 'block';
}

export function fillInEditForm(movieData) {
    movieId = movieData._id;

    movieTitleElement.value = movieData.title;
    imageUrlElement.value = movieData.img;
    movieDescriptionElement.value = movieData.description;
}

let movieId;

submitButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

    let data = {
        title: movieTitleElement.value,
        description: movieDescriptionElement.value,
        img: imageUrlElement.value,
    }

    if (movieTitleElement.vaule, imageUrlElement.vaule, movieDescriptionElement.value) {
        fetch(`${url}/${movieId}`, {
            method: 'PUT',
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
            .then(resData => {
                showView('/');
                alert('Succesfully edited movie!');
                formElement.reset();
            })
    } else {
        alert('Fill in all input boxes');
    }
});