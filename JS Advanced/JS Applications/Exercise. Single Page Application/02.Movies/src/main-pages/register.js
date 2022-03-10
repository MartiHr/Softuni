import { showView } from "../router.js";

const url = 'http://localhost:3030/users/register';

const registerSectionElement = document.getElementById('form-sign-up');
const registrationFormElement = registerSectionElement.querySelector('form');
const registerButtonElement = registerSectionElement.querySelector('button');

registerButtonElement.addEventListener('click', register);

export function showRegister() {
    registerSectionElement.style.display = 'block';

}

function register(e) {
    e.preventDefault();

    let formData = new FormData(registrationFormElement);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('repeatPassword');

    if (email && password && rePass) {
        if (password == rePass && password.length >= 6) {

            let data = {
                email,
                password
            }

            fetch(url, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .then(res => {
                    if (res.status != 200) {
                        throw new Error();
                    }

                    return res.json();
                })
                .then(data => {
                    localStorage.setItem('_id', data._id);
                    localStorage.setItem('email', data.email);
                    localStorage.setItem('accessToken', data.accessToken);

                    alert('Successful login!');
                    showView('/');
                    registrationFormElement.reset();
                })
                .catch(error => alert('Error'));
        } else {
            alert('Wrong input data');
        }
    } else {
        alert('Fill in all input boxes.');
    }
}