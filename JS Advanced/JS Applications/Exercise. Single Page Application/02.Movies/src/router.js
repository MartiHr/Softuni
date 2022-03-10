import { showHome } from "./main-pages/home.js";
import { showLogin } from "./main-pages/login.js";
import { logout } from "./main-pages/logout.js";
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
    '/logout': logout
}

export function showView(path) {
    hideAll();

    let renderer = paths[path];
    renderView(renderer);
}

function renderView(renderer) {
    renderer();
    renderBar();
}

function hideAll() {
    sections.forEach(s => s.style.display = 'none');
}

const navbarNavElement = document.querySelector('.navbar-nav');
const [welcomeTextElement, logoutButtonElement, loginButtonElement, registerButtonElement]
    = navbarNavElement.querySelectorAll('a');

function renderBar() {
    if (localStorage.email) {
        welcomeTextElement.textContent = `Welcome, ${localStorage.email}`;
        logoutButtonElement.style.display = 'block';
        loginButtonElement.style.display = 'none';
        registerButtonElement.style.display = 'none';
    } else {
        welcomeTextElement.textContent = 'Welcome, guest';
        logoutButtonElement.style.display = 'none';
        loginButtonElement.style.display = 'block';
        registerButtonElement.style.display = 'block';
    }
}