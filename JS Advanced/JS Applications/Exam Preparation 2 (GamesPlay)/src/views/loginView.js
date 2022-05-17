import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/authService.js";

const loginTemplate = (loginHandler) => {
    return html`
        <section id="login-page" class="auth">
            <form id="login" @submit=${loginHandler}>
                <div class="container">
                    <div class="brand-logo"></div>
                    <h1>Login</h1>
                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

                    <label for="login-pass">Password:</label>
                    <input type="password" id="login-password" name="password">
                    <input type="submit" class="btn submit" value="Login">
                    <p class="field">
                        <span>If you don't have profile click <a href="/register">here</a></span>
                    </p>
                </div>
            </form>
        </section>`;
}

export const loginView = (ctx) => {
    ctx.render(loginTemplate(loginHandler.bind(null, ctx)));
}

async function loginHandler(ctx, e) {
    e.preventDefault();

    const { email, password } = Object.fromEntries(new FormData(e.currentTarget));  

    if (!email || !password) {
        return alert('Fill in all input boxes.');
    }    

    const user = await login({email, password});

    if (user) {
        alert('Successful login!');
    }

    ctx.page.redirect('/');
}