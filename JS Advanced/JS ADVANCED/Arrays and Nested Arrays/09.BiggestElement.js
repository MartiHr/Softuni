function findBiggestElement(matrix) {
    
    let biggestNum = Number.MIN_SAFE_INTEGER;

    for (const arr of matrix) {
        for (const number of arr) {
            if (number > biggestNum) {
                biggestNum = number;
            }
        }
    }

    return biggestNum
}