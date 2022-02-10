function solve() {

    let textElement = document.getElementById('text');
    let namingConvetionElement = document.getElementById('naming-convention');

    let text = textElement.value;
    let namingConvention = namingConvetionElement.value;

    let result = '';

    if (namingConvention === 'Camel Case') {
        for (let i = 0; i < text.length; i++) {
            if (text[i] === ' ') {
                result += (text[i + 1].toUpperCase());
                i++;
            } else {
                result += (text[i].toLowerCase());
            }
        }
    } else if (namingConvention === 'Pascal Case') {
        
        result += (text[0].toUpperCase());

        for (let i = 1; i < text.length; i++) {
            if (text[i] === ' ') {
                result += (text[i + 1].toUpperCase());
                i++;
            } else {
                result += (text[i].toLowerCase());
            }
        }
    } else {
        result = 'Error!'
    }

    let resultElement = document.getElementById('result');
    resultElement.textContent = result;
}