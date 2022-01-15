function sumInterval(m, n) {
    let number1 = Number(m);
    let number2 = Number(n);

    let result = 0;

    for (let i = number1; i <= number2; i++) {
        result += i;
    }

    console.log(result);
}