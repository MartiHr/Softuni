function deleteByEmail() {

    let textInput = document.querySelector('input[name="email"]').value;
    let emailCellElements = document.querySelectorAll('tr td:nth-of-type(2)');
    let resultElement = document.getElementById('result');


    for (const cellElement of emailCellElements) {
        if (cellElement.textContent.includes(textInput)) {
            cellElement.parentElement.remove();
            resultElement.textContent = 'Deleted.';
            return;
        }
    }

    resultElement.textContent = 'Not found.';
}