const registerButtonElement = document.querySelector('button');
const url = 'http://localhost:3030/users/register';

registerButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

    const [emailElement, passwordElement, rePasswordElement] = document.querySelectorAll('input');

    if (!(emailElement.value && passwordElement.value && rePasswordElement.value)) {
        alert('You must fill in all input boxes.');
    } else if (passwordElement.value != rePasswordElement.value) {
        alert('Passwords must match.')
    } else {
        let data = {
            email: emailElement.value,
            password: passwordElement.value,
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
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
            localStorage.setItem('email', data.email);
            localStorage.setItem('accessToken', data.accessToken);

            window.location.href = 'index.html';
        })
        .catch(error => alert('Error'));

        alert('Successful registration!');
    }
});
