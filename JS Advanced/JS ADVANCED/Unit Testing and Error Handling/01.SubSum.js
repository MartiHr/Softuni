function subSum(numArr, startIndex, endIndex) {
    
    if (!Array.isArray(numArr)) {
        return NaN;
    }

    startIndex = Math.max(0, startIndex);
    endIndex = Math.min(numArr.length - 1, endIndex);

    let filteredArr = numArr.slice(startIndex, endIndex + 1);
    
    return filteredArr.reduce((a, number) => a += Number(number), 0);
}