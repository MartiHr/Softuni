function toggle() {

    let buttonElement = document.querySelector('.button');
    let textElement = document.getElementById('extra');

    let buttonText = buttonElement.textContent;

    if (buttonText === 'More') {
        buttonElement.textContent = 'Less';
        textElement.style.display = 'block';
    } else {
        buttonElement.textContent = 'More';
        textElement.style.display = 'none';
    }
}