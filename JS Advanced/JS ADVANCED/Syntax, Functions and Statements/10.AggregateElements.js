function aggregateElements(numberArr) {

    let sum1 = 0;
    let sum2 = 0;
    let concatenated = '';

    for (let i = 0; i < numberArr.length; i++) {
        sum1 += numberArr[i];
        sum2 += 1 / numberArr[i];
        concatenated += numberArr[i].toString();
    }

    console.log(sum1);
    console.log(sum2);
    console.log(concatenated);
}