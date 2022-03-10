import { showView } from "../router.js";

export function logout() {
    fetch('http://localhost:3030/users/register/users/logout', {
        headers: {
            'X-Authorization': localStorage.accessToken
        }
    })
        .then(res => {
            if (res.status != 204) {
                throw new Error();
            }

            alert('Logged out.');
            localStorage.clear();
            showView('/');
        })
        .catch(error => alert('Error'));
}