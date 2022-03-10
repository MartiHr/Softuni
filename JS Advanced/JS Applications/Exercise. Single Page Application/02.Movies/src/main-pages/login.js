import { showView } from "../router.js";

const url = 'http://localhost:3030/users/login';

const loginSectionElement = document.getElementById('form-login');
const loginFormElement = loginSectionElement.querySelector('form');
const loginButtonElement = loginSectionElement.querySelector('button');

loginButtonElement.addEventListener('click', login); 

export function showLogin() {
    loginSectionElement.style.display = 'block';
}

function login(e) {
    e.preventDefault();

    let formData = new FormData(loginFormElement);

    let email = formData.get('email');
    let password = formData.get('password');

    if (email && password) {
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
                loginFormElement.reset();
                showView('/');
            })
            .catch(error => alert('Error'));
    } else {
        alert('Fill in all input boxes.');
    }
}