function carCompany(inputCars) {
    let carModelByCarBrand = {};

    for (const inputCar of inputCars) {
        let [carBrand, carModel, producedCars] = inputCar.split(' | ');
        producedCars = Number(producedCars);

        let producedCarsByCarModel = {};

        if (!carModelByCarBrand[carBrand]) {
            carModelByCarBrand[carBrand] = [];

            if (!producedCarsByCarModel[carModel]) {
                producedCarsByCarModel[carModel] = 0;
            }
            producedCarsByCarModel[carModel] += producedCars;

            carModelByCarBrand[carBrand].push(producedCarsByCarModel);
        } else {
            if (!carModelByCarBrand[carBrand].find(x => x[carModel])) {
                producedCarsByCarModel[carModel] = producedCars;
                carModelByCarBrand[carBrand].push(producedCarsByCarModel);
            } else {
                let neededCar = carModelByCarBrand[carBrand].find(x => x[carModel]);
                neededCar[carModel] += producedCars;
            }
        }
    }

    let result = '';

    for (const brand in carModelByCarBrand) {
        result += `${brand}\n`;

        for (const carModelAndProducedCars of carModelByCarBrand[brand]) {
            for (const carModel in carModelAndProducedCars) {
                result += `###${carModel} -> ${carModelAndProducedCars[carModel]}\n`;
            }
        }

        result.trimEnd();
    }

    return result;
}

// console.log(carCompany(
//     ['Audi | Q7 | 1000',
//         'Audi | Q6 | 100',
//         'BMW | X5 | 1000',
//         'BMW | X6 | 100',
//         'Citroen | C4 | 123',
//         'Volga | GAZ-24 | 1000000',
//         'Lada | Niva | 1000000',
//         'Lada | Jigula | 1000000',
//         'Citroen | C4 | 22',
//         'Citroen | C5 | 10']));

        