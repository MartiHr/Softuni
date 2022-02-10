function colorize() {

    let rowElements = document.querySelectorAll('tr:nth-of-type(2n)');

    for (let i = 0; i < rowElements.length; i++) {
        rowElements[i].style.backgroundColor = 'teal';
    }
}