import { showView } from "./router.js";

showView('/');

const navbarElement = document.querySelector('nav');
const addMovieButtonElement = document.querySelector('a[href="/add"]')

navbarElement.addEventListener('click', onLinkClick);
addMovieButtonElement.addEventListener('click', onLinkClick);

function onLinkClick(e) {
    e.preventDefault();

    if (e.target.tagName == 'A' && e.target.href) {
        let url = new URL(e.target.href);
        let path = url.pathname;

        showView(path);
    }
}