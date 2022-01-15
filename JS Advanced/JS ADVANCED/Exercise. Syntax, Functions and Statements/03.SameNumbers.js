function sameNumber(num) {
    
    let numberAsString = num.toString();
    let firstDigit = numberAsString[0];
    
    let areSame = true;
    let sumOfDigits = 0;

    for (let i = 0; i < numberAsString.length; i++) {
        
        let currentDigitsAsString = numberAsString[i]; 
        sumOfDigits += Number(currentDigitsAsString);

        if (currentDigitsAsString !== firstDigit) {
            areSame = false;
        }
    }

    console.log(areSame);
    console.log(sumOfDigits);
}