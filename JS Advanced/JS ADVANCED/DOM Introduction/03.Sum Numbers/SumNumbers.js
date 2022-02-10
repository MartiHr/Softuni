function calc() {
   
    let firstInputElement = document.getElementById('num1');
    let secondInputElement = document.getElementById('num2');

    let num1 = Number(firstInputElement.value);
    let num2 = Number(secondInputElement.value);

    let sum = num1 + num2;

    let ouputElement = document.getElementById('sum');
    ouputElement.value = sum;
}