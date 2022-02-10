function getElements(stringArr, n) {
    let newArr = [];

    for (let i = 0; i < stringArr.length; i += n) {
        newArr.push(stringArr[i]);        
    }

    return newArr;
}