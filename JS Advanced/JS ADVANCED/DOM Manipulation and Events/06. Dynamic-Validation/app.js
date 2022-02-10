function validate() {

    let inputElement = document.getElementById('email');
    const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

    inputElement.addEventListener('change', (e) => {
        if (!regex.test(e.target.value)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });
}