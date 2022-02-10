function extractText() {
    
    // Solution 1 (worse than the one below it)
    // let listElements = document.getElementById('items');

    // let textareaElement = document.getElementById('result');
    // textareaElement.textContent = listElements.textContent;
    
    let itemNodes = document.querySelectorAll("ul#items li");
    console.log(itemNodes);

    let textarea = document.querySelector("#result");
    
    for (let node of itemNodes) {
        textarea.value += node.textContent + "\n";
    }
}