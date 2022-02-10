function focused() {

    let inputFieldElements = Array.from(document.querySelectorAll('input[type="text"]'));

    const inputElementFocusHandler = (e) => {
        e.target.parentElement.classList.add('focused');
    }

    const inputElementBlurHandler = (e) => {
        e.target.parentElement.classList.remove('focused');
    }

    for (const field of inputFieldElements) {
        field.addEventListener('focus', inputElementFocusHandler);
        field.addEventListener('blur', inputElementBlurHandler);
    }
}