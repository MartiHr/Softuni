function createSortedCatalog(productInfoArr) {
    
    productInfoArr = productInfoArr.sort((a, b) => a.localeCompare(b));

    let categoryChar = productInfoArr[0][0];
    let result = categoryChar + '\n';

    for (const productInfo of productInfoArr) {
        let [productName, productPrice] = productInfo.split(' : ');
        productPrice = Number(productPrice);

        if (productName[0] !== categoryChar) {
            categoryChar = productName[0];
            result += categoryChar + '\n'
        }
        
        result += `  ${productName}: ${productPrice}\n`;
    }

    console.log(result.trimEnd());
}

// createSortedCatalog(['Appricot : 20.4',
// 'Fridge : 1500',
// 'TV : 1499',
// 'Deodorant : 10',
// 'Boiler : 300',
// 'Apple : 1.25',
// 'Anti-Bug Spray : 15',
// 'T-Shirt : 10'])