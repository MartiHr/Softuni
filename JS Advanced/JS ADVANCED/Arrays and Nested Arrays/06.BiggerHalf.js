function getBiggerHalf(arr) {
    
    arr.sort((a, b) => a - b);
    arr = arr.slice(Math.floor(arr.length / 2), arr.length)
    
    return arr;
}