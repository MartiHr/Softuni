function calculator(number1, number2, operator) {
    let result;

    switch (operator) {
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;            
        case '/':
            result = number1 / number2;
            break; 
        case '%':
            result = number1 % number2;
            break;   
        case '**':
            result = number1 ** number2;
            break;   
        default:
            break;
    }

    console.log(result);
}