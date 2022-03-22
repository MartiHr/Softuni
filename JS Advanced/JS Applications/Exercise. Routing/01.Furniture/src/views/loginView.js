import { login } from '../api/api.js';
import { html } from '../library.js'

const loginTemplate = (onSubmit, errorMsg) => {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Login User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form @submit=${onSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input class="form-control${errorMsg ? ' is-invalid' : ''}" id="email" type="text" name="email">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password">Password</label>
                    <input class="form-control${errorMsg ? ' is-invalid' : ''}" id="password" type="password" name="password">
                </div>
                <input type="submit" class="btn btn-primary" value="Login" />
            </div>
        </div>
    </form>`;
}

export function loginView(ctx) {

    update();

    function update(errorMsg) {
        ctx.render(loginTemplate(onSubmit, errorMsg));
    }
    
    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        
        const email = formData.get('email');
        const password = formData.get('password');

        try {
            if (email && password) {
                await login(email, password);
                ctx.updateUserNav();
                ctx.page.redirect('/');
            } else {
                alert('Fill in all input boxes.');
            }
        } catch (error) {
            update('Email or password don\'t match.');
        }
    }
}
