function sortNumbers(numberArr) {
   
    let resultArr = [];
    numberArr = numberArr.sort((a, b) => a - b);
    
    while (numberArr.length !== 0) {
        resultArr.push(numberArr.shift());
        resultArr.push(numberArr.pop());
    }

    return resultArr;
}