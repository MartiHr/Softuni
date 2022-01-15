function arrangeNumbers(arr) {
    
    let newArr = [];

    for (let num of arr) {
        if (num < 0) {
            newArr.unshift(num);
        } else {
            newArr.push(num);
        }
    }

    for (let num of newArr) {
        console.log(num);
    }
}