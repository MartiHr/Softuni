import { register } from '../api/api.js';
import { html } from '../library.js'

const registerTemplate = (onSubmit, errorMsg, errors) => {
    return html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control${errors && errors.email ? ' is-invalid' : ''}" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control${errors && errors.password ? ' is-invalid' : ''}" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control${errors && errors.rePass ? ' is-invalid' : ''}" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;
}

export function registerView(ctx) {

    update();

    function update(errorMsg, errors) {
        ctx.render(registerTemplate(onSubmit, errorMsg, errors));
    }

    async function onSubmit(e) {
        e.preventDefault();
      
        const formData = new FormData(e.target);
        
        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('rePass');

        try {
            if (!(email && password && rePass)) {
                throw {
                    message: new Error('Fill in all input boxes.'),
                    errors: {
                        email: email == '',
                        password: password == '',
                        rePass: rePass == '',
                    }
                };
            }

            if (password != rePass) {
                throw {
                    message: new Error('Password and repeat password do not match.'),
                    errors: {
                        email: false,
                        password: true,
                        rePass: true
                    }
                };
            }

            await register(email, password);
            ctx.updateUserNav();
            ctx.page.redirect('/');
        } catch (err) {
            let errMessage = err.message;
            let errors = err.errors;

            if (!errMessage) {
                errMessage= 'User with the email already exists.';
                errors =  {
                    email: true,
                    password: true,
                    rePass: true,
                };

                update(errMessage, errors);
            } else {
                update(errMessage, errors);
            }
        }
    }
}