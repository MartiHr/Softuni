function findCircleArea(input) {
    if (typeof(input) === 'number') {
        console.log((Math.PI * input ** 2).toFixed(2));
    } else {
        console.log('We can not calculate the circle area, because we receive a ' + typeof(input) + '.');
    }
}