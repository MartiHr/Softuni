function extractNumbers(numberArr) {
    let resultArr = [];

    let biggestNumber = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < numberArr.length; i++) {
        let currentNumber = numberArr[i];

        if (currentNumber >= biggestNumber) {
            resultArr.push(currentNumber);
            biggestNumber = currentNumber;
        }
    }

    return resultArr;
}