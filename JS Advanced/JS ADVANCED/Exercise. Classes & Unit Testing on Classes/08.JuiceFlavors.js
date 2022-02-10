function storeJuice(juices) {
    let quantityByFlavour = {};
    let bottlesByFlavour = {};

    for (const juice of juices) {
        let [flavour, quantity] = juice.split(' => ');
        quantity = Number(quantity);

        if (!quantityByFlavour[flavour]) {
            quantityByFlavour[flavour] = 0;
        }

        quantityByFlavour[flavour] += quantity;

        if (quantityByFlavour[flavour] / 1000 >= 1) {
            if (!bottlesByFlavour[flavour]) {
                bottlesByFlavour[flavour] = 0;
            }

            let bottles = Math.floor(quantityByFlavour[flavour] / 1000);
            let leftover = quantityByFlavour[flavour] % 1000;

            bottlesByFlavour[flavour] += bottles;
            quantityByFlavour[flavour] = leftover;
        }
    }

    let result = '';
    for (const flavour in bottlesByFlavour) {
        result += `${flavour} => ${bottlesByFlavour[flavour]}\n`;
    }
    
    return result.trimEnd();
}