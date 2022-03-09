import { showView } from "./router.js";

showView('/');

const navbarElement = document.querySelector('nav');

navbarElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target.tagName == 'A') {
        let url = new URL(e.target.href);
        let path = url.pathname;

        showView(path);
    }
});