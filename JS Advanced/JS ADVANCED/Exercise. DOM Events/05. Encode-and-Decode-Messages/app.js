function encodeAndDecodeMessages() {

    let [encodeButtonElement, decodeButtonElement] = document.querySelectorAll('div button');

    encodeButtonElement.addEventListener('click', encode);
    decodeButtonElement.addEventListener('click', decode);

    let [inputTextElement, outputTextElement] = document.querySelectorAll('textarea');

    function encode(e) {
        let inputText = inputTextElement.value;
        let encodedText = '';
        
        for (const character of inputText) {
            encodedText += String.fromCharCode(character.charCodeAt(0) + 1);
        }

        inputTextElement.value = '';
        outputTextElement.value = encodedText;
    }

    function decode(e) {
        let inputText = outputTextElement.value;
        let decodedText = '';
        
        for (const character of inputText) {
            decodedText += String.fromCharCode(character.charCodeAt(0) - 1);
        }

        outputTextElement.value = decodedText;
    }
}