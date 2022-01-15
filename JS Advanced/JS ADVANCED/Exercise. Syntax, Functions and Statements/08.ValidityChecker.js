function validityCheck(x1, y1, x2, y2) {

    function formulaCheck(a1, b1, a2, b2) {

        let result = Math.sqrt(((a2 - a1) ** 2) + ((b2 - b1) ** 2));

        let output = '';

        if (Number.isInteger(result)) {
            output = `{${a1}, ${b1}} to {${a2}, ${b2}} is valid`
        } else {
            output = `{${a1}, ${b1}} to {${a2}, ${b2}} is invalid`
        }

        return output;
    }

    console.log(formulaCheck(x1, y1, 0, 0));
    console.log(formulaCheck(x2, y2, 0, 0));
    console.log(formulaCheck(x1, y1, x2, y2));
}