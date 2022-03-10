import { renderMovieDetails } from "../movie-operation-pages/movie-details.js";
import { showView } from "../router.js";

const homeSectionElement = document.getElementById('home-page');
const homeMoviesSectionElement = document.getElementById('movie');
const addMovieButtonElement = document.getElementById('add-movie-button');
const cardDeckElement = homeMoviesSectionElement.querySelector('.card-deck');

const url = 'http://localhost:3030/data/movies';

export function showHome() {
    homeSectionElement.style.display = 'block';
    homeMoviesSectionElement.style.display  = 'block';

    if (localStorage.email) {
        addMovieButtonElement.style.display = 'block';
    } else {
        addMovieButtonElement.style.display = 'none';
    }

    renderMovies();
}

function renderMovies() {
    fetch(url)
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }
            
            return res.json();
        })
        .then(data => {
            cardDeckElement.innerHTML = '';

            Object.values(data)
                .forEach(movieData => {
                    let movieElement = createMovieElement(movieData);

                    cardDeckElement.append(movieElement);
                });
        })
        .catch(error => alert('Error'));
}

function createMovieElement(movieData) {
    let movieElement = document.createElement('div');
    movieElement.classList.add('card');
    movieElement.classList.add('mb-4');

    movieElement.innerHTML = `
        <img class="card-img-top"
                src="${movieData.img}"
                alt="Card image cap" width="400">
            <div class="card-body">
                <h4 class="card-title">${movieData.title}</h4>
            </div>
            <div class="card-footer">
                <a href="/details/${movieData._ownerId}">
                    <button type="button" class="btn btn-info">Details</button>
                </a>
            </div>`;

    let detailButtonElement = movieElement.querySelector('button');

    detailButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        showView('/details')
        renderMovieDetails(movieData._id);
    });

    return movieElement;
}