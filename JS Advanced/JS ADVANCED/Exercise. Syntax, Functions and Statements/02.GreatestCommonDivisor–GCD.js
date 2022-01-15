function greatestCommonDivisor(number1, number2) {
    
    while (number1 !== number2) {
        if (number1 > number2) {
            number1 -= number2
        } else {
            number2 -= number1;
        }
    }

    console.log(number1);
}