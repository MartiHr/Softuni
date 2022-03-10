import { showHome } from "./main-pages/home.js";
import { showLogin } from "./main-pages/login.js";
import { showRegister } from "./main-pages/register.js";
import { showAddMovie } from "./movie-operation-pages/add-movie.js";
import { showMovieDetails } from "./movie-operation-pages/movie-details.js";

const sections = document.querySelectorAll('.view-section');

const paths = {
    '/': showHome,
    '/login': showLogin,
    '/register': showRegister,
    '/add': showAddMovie,
    '/details': showMovieDetails,
}

export function showView(path) {
    hideAll();
    
    let renderer = paths[path];
    renderView(renderer);
}

function renderView(renderer) {
    renderer();
}

function hideAll() {
    sections.forEach(s => s.style.display = 'none');
}