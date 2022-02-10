function validate() {

    let buttonElement = document.getElementById('submit');
    let [usernameElement, emailElement, passwordElement, confirmPasswordElement, isCompanyElement]
        = document.querySelectorAll('input');
    let fieldsetElement = document.getElementById('companyInfo');
    let fieldsetInputElement = document.querySelector('fieldset input[id="companyNumber"]');
    let validElement = document.getElementById('valid');

    let usernamePattern = /^[a-zA-Z0-9]{3,20}$/;
    let passwordPattern = /^\w{5,15}$/;
    let emailPattern = /^.*@.*\..*$/;

    isCompanyElement.addEventListener('change', (e) => {
        if (e.target.checked) {
            console.log(fieldsetElement.value);
            fieldsetElement.style.display = 'block';
        } else {
            fieldsetInputElement.value = undefined;
            fieldsetElement.style.display = 'none';
        }
    });

    buttonElement.addEventListener('click', (e) => {

        e.preventDefault();

        let noErrors = true;

        if (usernamePattern.test(usernameElement.value)) {
            usernameElement.style.borderColor = "";
        } else {
            noErrors = false;
            usernameElement.style.borderColor = "red";
        }

        if (emailPattern.test(emailElement.value)) {
            emailElement.style.borderColor = "";
        } else {
            noErrors = false;
            emailElement.style.borderColor = "red";
        }

        if (passwordElement.value === confirmPasswordElement.value) {
            if (passwordPattern.test(passwordElement.value)) {
                passwordElement.style.borderColor = "";
            } else {
                noErrors = false;
                passwordElement.style.borderColor = "red";
            }

            if (passwordPattern.test(confirmPasswordElement.value)) {
                confirmPasswordElement.style.borderColor = "";
            } else {
                noErrors = false;
                confirmPasswordElement.style.borderColor = "red";
            }
        } else {
            noErrors = false;
            passwordElement.style.borderColor = "red";
            confirmPasswordElement.style.borderColor = "red";
        }

        if (isCompanyElement.checked) {
            if (Number(fieldsetInputElement.value) >= 1000 && Number(fieldsetInputElement.value) <= 9999) {
                fieldsetInputElement.style.borderColor = "";
            } else {
                noErrors = false;
                fieldsetInputElement.style.borderColor = "red";
            }
        }

        if (noErrors) {
            validElement.style.display = 'block';
        } else {
            validElement.style.display = 'none';
        }
    });
}
