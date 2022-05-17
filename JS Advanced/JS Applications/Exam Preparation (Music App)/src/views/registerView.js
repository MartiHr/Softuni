import { html } from "../../node_modules/lit-html/lit-html.js"
import { register } from "../api/authService.js";

export const registerTemplate = (registerHandler) => {
    return html`
        <section id="registerPage">
            <form @submit=${registerHandler}>
                <fieldset>
                    <legend>Register</legend>
        
                    <label for="email" class="vhide">Email</label>
                    <input id="email" class="email" name="email" type="text" placeholder="Email">
        
                    <label for="password" class="vhide">Password</label>
                    <input id="password" class="password" name="password" type="password" placeholder="Password">
        
                    <label for="conf-pass" class="vhide">Confirm Password:</label>
                    <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">
        
                    <button type="submit" class="register">Register</button>
        
                    <p class="field">
                        <span>If you already have profile click <a href="/login">here</a></span>
                    </p>
                </fieldset>
            </form>
        </section>
    `
}

export const registerView = (ctx) => {
    ctx.render(registerTemplate(registerHandler.bind(null, ctx)));
}

async function registerHandler(ctx, e) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('conf-pass');

    if (!email || !password) {
        return alert('Fill in everything');
    }

    if (password != rePass) {
        return alert('Password and repeated password do not match.');
    }

    await register({email, password});
    ctx.page.redirect('/');
}