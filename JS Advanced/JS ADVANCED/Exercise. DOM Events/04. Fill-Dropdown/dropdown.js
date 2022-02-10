function addItem() {

    let inputElements = Array.from(document.querySelectorAll('input[type="text"]'));
    let textInput = inputElements[0].value;
    let valueInput = inputElements[1].value;

    let optionElement = document.createElement('option');

    if (textInput !== '' && valueInput !== '') {
        optionElement.text = textInput;
        optionElement.value = valueInput;
    }

    let dropdownElement = document.getElementById('menu');
    dropdownElement.appendChild(optionElement);

    inputElements[0].value = '';
    inputElements[1].value = '';
}