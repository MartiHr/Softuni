function findLowestPrice(townDataArr) {
    
    let townArr = [];

    for (const townData of townDataArr) {
        let [townName, productName, productPrice] = townData.split(' | ');
        productPrice = Number(productPrice);

        if (townArr.find(x => x.productName === productName)){

            let foundTown = (townArr.find(x => x.productName === productName));

            if (foundTown.productPrice > productPrice) {
                foundTown.townName = townName;
                foundTown.productPrice = productPrice;
            } 
        } else {
            let town = {
                townName,
                productName,
                productPrice,
            };

            townArr.push(town);
        }
    }

    townArr.forEach(x => {
        console.log(`${x.productName} -> ${x.productPrice} (${x.townName})`);
    })
}

// findLowestPrice(['Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10'])

// findLowestPrice(['Sofia City | Audi | 100000',
// 'Sofia City | BMW | 100000',
// 'Sofia City | Mitsubishi | 10000',
// 'Sofia City | Mercedes | 10000',
// 'Sofia City | NoOffenseToCarLovers | 0',
// 'Mexico City | Audi | 1000',
// 'Mexico City | BMW | 99999',
// 'Mexico City | Mitsubishi | 10000',
// 'New York City | Mitsubishi | 1000',
// 'Washington City | Mercedes | 1000',
// ])