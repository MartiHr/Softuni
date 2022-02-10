function composeCalorieObject(stringArr) {
    
    let output = {};

    for (let i = 0; i < stringArr.length; i += 2) {
        let name = stringArr[i];
        let calories = Number(stringArr[i + 1]);

        output[name] = calories;
    }
    
    console.log(output);
}

// composeCalorieObject(['Yoghurt', '48', 'Rise', '138',
//     'Apple', '52'])