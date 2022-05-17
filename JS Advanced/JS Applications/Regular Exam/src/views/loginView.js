import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/authService.js";

const loginTemplate = (loginHandler) => {
    return html` 
    <section id="loginPage">
        <form class="loginForm" @submit=${loginHandler}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Login</h2>
    
            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>
    
            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>
    
            <button class="btn" type="submit">Login</button>
    
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </form>
    </section>`
}

export const loginView = (ctx) => {
    ctx.render(loginTemplate(loginHandler.bind(null, ctx)));
}

async function loginHandler(ctx, e) {
    e.preventDefault();

    const { email, password} = Object.fromEntries(new FormData(e.currentTarget));

    if (!email || !password) {
        return alert('Fill in all input fields.');
    }

    await login({email, password});

    ctx.page.redirect('/');
}