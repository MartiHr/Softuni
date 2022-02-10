function sumTable() {

    let priceElements = document.querySelectorAll('tr td:nth-of-type(2)');

    let sum = Array.from(priceElements).reduce((a, x) => {
        let currentValue =  Number(x.textContent) || 0
        return a + currentValue
    }, 0)

    let resultElement = document.getElementById('sum');
    resultElement.textContent = sum;
}