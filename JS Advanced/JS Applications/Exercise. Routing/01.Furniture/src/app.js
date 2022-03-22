import { logout } from "./api/data.js";
import { render } from "./library.js";
import { page } from "./library.js";

import { createView } from "./views/createView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { catalogView } from "./views/catalogView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/registerView.js";

const divContainerElement = document.querySelector('div.container');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/', catalogView);
page('/login', loginView);
page('/my-furniture', catalogView);
page('/register', registerView);

updateUserNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, divContainerElement);
    ctx.updateUserNav = updateUserNav;
    updateUserNav(ctx.path)

    next();
}

function updateUserNav(path) {
    if (sessionStorage.userId) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }

    if (path == '/create' || path == '/' || path == '/login' || path == '/my-furniture' || path == '/register') {
        document.querySelectorAll('nav a').forEach(a => a.classList.remove('active'));
        document.querySelector(`nav a[href="${path}"]`).classList.add('active');
    }
}

async function onLogout() {
    await logout();
    updateUserNav();
    page.redirect('/');
}