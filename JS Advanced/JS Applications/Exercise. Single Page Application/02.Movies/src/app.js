import { showView } from "./router.js";

showView('/');

const homeContainerElement = document.querySelector('.container');

homeContainerElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target.tagName == 'A' && e.target.href) {
        let url = new URL(e.target.href);
        let path = url.pathname;

        showView(path);
    }
});