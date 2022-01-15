function processOddPositions(numbers) {
   
    let result = numbers
        .filter((num, i) => i % 2 == 1)
        .map(x => x * 2)
        .reverse()
        .join(' ');

    console.log(result);
}