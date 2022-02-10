function solution() {

    let products = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        }
    }

    let ingredients = {};

    return function manage(input) {
        let [command, type, count] = input.split(' ');
        count = Number(count);

        switch (command) {
            case 'restock':
                if (!ingredients[type]) {
                    ingredients[type] = 0;
                }

                ingredients[type] += count;
                return 'Success';
                break;
            case 'prepare':
                let product = products[type];
                let canPrepare = true;
                let faultProduct = '';

                for (const ingredient in product) {
                    if (typeof(ingredients[ingredient]) == 'undefined' || ingredients[ingredient] < product[ingredient] * count) {
                        canPrepare = false;
                        faultProduct = ingredient;
                        break;
                    }
                }

                if (canPrepare) {
                    for (const ingredient in product) {
                        ingredients[ingredient] -= product[ingredient] * count; 
                    }

                    return 'Success';
                } else {
                    return `Error: not enough ${faultProduct} in stock`;
                }
                
                break;
            case 'report':
                let result = '';

                for (const ingredient in ingredients) {
                    result += `${ingredient}=${ingredients[ingredient]} `
                }

                return result.trimEnd();
                break;
        }
    }
}

// let manager = solution();

// console.log(manager('prepare turkey 1'));
// console.log(manager('restock protein 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock carbohydrate 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('report'));

// console.log(manager('restock flavour 50')); // Success 
// console.log(manager('prepare lemonade 4')); // Error: not enough carbohydrate in stock