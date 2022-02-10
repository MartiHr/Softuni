function solve(numberArr, filter) {

    if (filter === 'asc') {
        numberArr = numberArr.sort((a, b) => a - b);
    } else if (filter === 'desc') {
        numberArr = numberArr.sort((a, b) => b - a);
    }

    return numberArr;
}