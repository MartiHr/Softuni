import { showHome } from "./home.js";
import { showPost } from "./post.js";

const sections = document.querySelectorAll('section');

const paths = {
    '/': showHome,
    '/post': showPost,
}

export function showView(path) {
    hideAll();

    let renderer = paths[path];
    renderView(renderer);
}

function renderView(renderer) {
    hideAll();
    renderer();
}

function hideAll() {
    sections.forEach(s => s.style.display = 'none');
}