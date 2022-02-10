function addItem() {

    let inputText = document.getElementById('newItemText').value;

    let liElement = document.createElement('li');
    liElement.textContent = inputText;
    
    let listElement = document.getElementById('items');
    listElement.appendChild(liElement);
}