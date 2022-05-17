import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/authService.js";

const registerTemplate = (registerHandler) => {
    return html`
         <section id="register-page" class="content auth">
            <form id="register" @submit=${registerHandler}>
                <div class="container">
                    <div class="brand-logo"></div>
                    <h1>Register</h1>

                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="maria@email.com">

                    <label for="pass">Password:</label>
                    <input type="password" name="password" id="register-password">

                    <label for="con-pass">Confirm Password:</label>
                    <input type="password" name="confirm-password" id="confirm-password">

                    <input class="btn submit" type="submit" value="Register">

                    <p class="field">
                        <span>If you already have profile click <a href="/login">here</a></span>
                    </p>
                </div>
            </form>
        </section>`;
}

export const registerView = (ctx) => {
    ctx.render(registerTemplate(registerHandler.bind(null, ctx)));
}

async function registerHandler(ctx, e) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);
    const { email, password} = Object.fromEntries(formData);  
    const rePass = formData.get('confirm-password');  

    if (!email || !password || !rePass) {
        return alert('Fill in all input boxes.');
    }    
    
    if (password != rePass) {
        return alert('Password and repeated password must match.');
    }    

    const user = await register({email, password});

    if (user) {
        alert('Successful register!');
    }

    ctx.page.redirect('/');
}