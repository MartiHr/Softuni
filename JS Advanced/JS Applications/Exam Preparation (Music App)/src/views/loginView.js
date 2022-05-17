import { html } from "../../node_modules/lit-html/lit-html.js"
import { login } from "../api/authService.js";

const loginTemplate = (loginHandler) => {
    return html` 
    <section id="loginPage">
        <form @submit=${loginHandler}>
            <fieldset>
                <legend>Login</legend>
    
                <label for="email" class="vhide">Email</label>
                <input id="email" class="email" name="email" type="text" placeholder="Email">
    
                <label for="password" class="vhide">Password</label>
                <input id="password" class="password" name="password" type="password" placeholder="Password">
    
                <button type="submit" class="login">Login</button>
    
                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </fieldset>
        </form>
    </section>`
}

export const loginView = (ctx) => {
    ctx.render(loginTemplate(loginHandler.bind(null, ctx)));
}

async function loginHandler(ctx, e) {
    e.preventDefault();

    const {email, password} = Object.fromEntries(new FormData(e.currentTarget));

    if (email && password) {
        await login({email, password});
        ctx.page.redirect('/');
    }
}