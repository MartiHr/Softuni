function calculator() {

    let element1;
    let element2;
    let resultElement;

    return {
        init(selector1, selector2, resultSelector) {
            element1 = document.querySelector(selector1);
            element2 = document.querySelector(selector2);
            resultElement = document.querySelector(resultSelector);
            console.log('a');
        },
        add() {
            resultElement.value = Number(element1.value) + Number(element2.value);
        },
        subtract() {
            resultElement.value = Number(element1.value) - Number(element2.value);
        }
    }
}

// const calculate = calculator();
// calculate.init('#num1', '#num2', '#result');