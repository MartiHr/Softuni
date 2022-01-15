function evenPosition(array) {

    let result = '';

    for (let i = 0; i < array.length; i += 2) {
        result += array[i] + ' ';
    }

    console.log(result);
}