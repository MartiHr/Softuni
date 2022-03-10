const registerSectionElement = document.getElementById('form-sign-up');
const registrationFormElement = registerSectionElement.querySelector('form');
const registerButtonElement = registerSectionElement.querySelector('button');

const url = 'http://localhost:3030/users/register';

export function showRegister() {
    registerSectionElement.style.display = 'block';

    registerButtonElement.addEventListener('click', (e) => {
        
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
                        localStorage.setItem('username', data.email);
                        localStorage.setItem('accessToken', data.accessToken);

                        registrationFormElement.reset();
                    })
            } else {
                alert('Wrong input data');
            }
        } else {
            alert('Fill in all input boxes.');
        }
    });
}