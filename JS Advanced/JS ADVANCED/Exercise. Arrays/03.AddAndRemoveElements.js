function addAndRemoveElements(commandArr) {
    let resultArr = [];

    for (let i = 0; i < commandArr.length; i++) {
        let currentNumber = i + 1;
        let currentCommand = commandArr[i];

        if (currentCommand === 'add') {
            resultArr.push(currentNumber);
        } else {
            resultArr.pop();
        }
    }

    if (resultArr.length == 0) {
        console.log("Empty");
        return;
    }

    console.log(resultArr.join('\n'));
}