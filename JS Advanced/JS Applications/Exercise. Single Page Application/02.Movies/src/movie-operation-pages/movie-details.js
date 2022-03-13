import { showView } from "../router.js";
import { fillInEditForm } from "./edit-movie.js";

const movieSectionElement = document.getElementById('movie-example');

const moviesUrl = 'http://localhost:3030/data/movies';

export function showMovieDetails() {
    movieSectionElement.style.display = 'block';
}

export async function renderMovieDetails(id) {
    movieSectionElement.innerHTML = '';

    let movieData = await getNeededMovieData(id);

    let movieElement = document.createElement('div');
    movieElement.classList.add('container');

    movieElement.innerHTML = `  
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movieData.title}</h1>
            <div class="col-md-8">
                <img class="img-thumbnail" src="${movieData.img}"
                    alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${movieData.description}</p>
                <a class="btn btn-danger" href="#">Delete</a>
                <a class="btn btn-warning" href="#">Edit</a>
                <a class="btn btn-primary" href="#">Like</a>
                <span class="enrolled-span">Liked 1</span>
            </div>
        </div>`;

    let [deleteAElemenent, editAElement, likeAElement] = movieElement.querySelectorAll('a');
    let totalLikes = movieElement.querySelector('span');

    deleteAElemenent.addEventListener('click', (e) => {
        e.preventDefault();

        if (localStorage._id == movieData._ownerId) {
            fetch(`http://localhost:3030/data/movies/${movieData._id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': localStorage.accessToken
                }
            })
                .then(res => {
                    if (res.status != 200) {
                        throw new Error();
                    }

                    return res.json();
                })
                .then(data => {
                    alert('Successfully deleted movie.')
                    showView('/');
                })
                .catch(error => alert('Error'));
        }
    });

    editAElement.addEventListener('click', (e) => {
        e.preventDefault();

        if (localStorage._id == movieData._ownerId) {
            showView('/edit');
            fillInEditForm(movieData);
        }
    });

    reloadLikes(totalLikes, movieData._id);

    likeAElement.addEventListener('click', async (e) => {
        e.preventDefault();

        let likeId = await userLikeId(movieData._id, localStorage._id);

        let data = {
            movieId: movieData._id
        }

        if (likeId == undefined) {
            likeAElement.style.display = 'none';

            fetch(`http://localhost:3030/data/likes`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': localStorage.accessToken
                },
                body: JSON.stringify(data)
            })
                .then(res => {
                    if (res.status != 200) {
                        throw new Error();
                    }
                })
                .then(data => {
                    reloadLikes(totalLikes, movieData._id);
                })
                .catch(error => alert('Error'));
        } else {
            fetch(`http://localhost:3030/data/likes/${likeId}`, {
                method: 'DELETE',
                headers: {
                    'X-Authorization': localStorage.accessToken
                }
            })
                .then(res => {
                    if (res.status != 200) {
                        throw new Error();
                    }
                })
                .then(data => {
                    alert('Removed like!');
                    reloadLikes(totalLikes, movieData._id);
                })
                .catch(error => alert('Error'));
        }
    });

    if (localStorage._id == movieData._ownerId) {
        deleteAElemenent.style.display = 'inline';
        editAElement.style.display = 'inline';
        likeAElement.style.display = 'none';
    } else {
        likeAElement.style.display = 'inline';
        deleteAElemenent.style.display = 'none';
        editAElement.style.display = 'none';
    }

    let likeId = await userLikeId(movieData._id, localStorage._id);
    
    if (likeId != undefined) {
        likeAElement.style.display = 'none';
    }

    movieSectionElement.append(movieElement);
}

async function reloadLikes(totalLikes, id) {
    let likes = await getTotalLikes(id);
    totalLikes.textContent = `Liked ${likes}`;
}

async function userLikeId(movieId, userId) {
    let res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);

    if (res.status != 200) {
        alert('Error')
    }

    let data = Object.values(await res.json());

    if (data[0]) {
        return data[0]._id 
    }

    return undefined;
}

async function getTotalLikes(id) {
    let res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);

    if (res.status != 200) {
        alert('Error')
    }

    let likes = await res.json()

    return likes;
}

async function getNeededMovieData(id) {
    let res = await fetch(moviesUrl);

    let movies = Object.values(await getAllMoviesData());

    return movies.find(x => x._id == id);
}

function getAllMoviesData() {
    return fetch(moviesUrl)
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            return Object.values(data)
        })
        .catch(error => alert('Error'));
}