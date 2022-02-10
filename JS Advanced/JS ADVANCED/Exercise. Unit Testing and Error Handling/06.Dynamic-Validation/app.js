function validate() {

    let emailPattern = /\w+@\w+\.\w+/gm;
    let emailElement = document.getElementById('email');
    emailElement.addEventListener('change', (e) => {
        if (!emailPattern.test(e.target.value)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });
}