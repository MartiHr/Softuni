const url = 'http://localhost:3030/users/login';

const formElement = document.querySelector('form[id="login"');


formElement.addEventListener('submit', (e) => {
    e.preventDefault();

    let formData = new FormData(formElement);
    
    let email = formData.get('email');
    let password = formData.get('password');

    if (!(email && password)) {
        alert('Error');
    } else {
        let data = {
            email,
            password
        };

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
    }
});