const loginSectionElement = document.getElementById('form-login');
const loginFormElement = loginSectionElement.querySelector('form');
const submitButtonElement = loginSectionElement.querySelector('button');

export function showLogin() {
    loginSectionElement.style.display = 'block';

    submitButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let formData = new FormData(loginFormElement);

        let email = formData.get('email');
        let password = formData.get('password');

        if (email && password) {
            let data = {
                email,
                password
            }

            //TODO: finish implementation
        } else {
            alert('Fill in all input boxes.');
        }
    });
}