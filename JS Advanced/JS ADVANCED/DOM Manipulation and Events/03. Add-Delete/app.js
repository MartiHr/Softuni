function addItem() {

    let inputElement = document.getElementById('newItemText');

    let liElement = document.createElement('li');
    liElement.textContent = inputElement.value;

    let aElement = document.createElement('a');
    aElement.textContent = '[Delete]';
    aElement.href = '#';
    aElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    liElement.appendChild(aElement);
    
    let ulElement = document.getElementById('items');
    ulElement.appendChild(liElement);
}