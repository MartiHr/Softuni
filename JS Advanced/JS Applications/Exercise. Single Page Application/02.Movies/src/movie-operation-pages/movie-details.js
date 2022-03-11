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

    if (localStorage._id == movieData._ownerId) {
        deleteAElemenent.style.display = 'inline';
        editAElement.style.display = 'inline';
        likeAElement.style.display = 'none';
    } else {
        likeAElement.style.display = 'inline';
        deleteAElemenent.style.display = 'none';
        editAElement.style.display = 'none';
    }

    movieSectionElement.append(movieElement);
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