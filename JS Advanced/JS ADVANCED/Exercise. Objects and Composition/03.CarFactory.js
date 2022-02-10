function assembleCar(carModelObject) {

    let car = {};

    car.model = carModelObject.model;

    let engine = {};
    

    if (carModelObject.power <= 90) {
        engine.power = 90;
        engine.volume = 1800;
    } else if (carModelObject.power <= 120) {
        engine.power = 120;
        engine.volume = 2400;
    } else if (carModelObject.power <= 200) {
        engine.power = 200;
        engine.volume = 3500;
    }

    car.engine = engine;

    car.carriage = {
        type: carModelObject.carriage,
        color: carModelObject.color,
    }

    let wheelSize = carModelObject.wheelsize;

    if (carModelObject.wheelsize % 2 === 0) {
        wheelSize = wheelSize - 1;
    }

    car.wheels = Array(4).fill(wheelSize);

    return car;
}

// let carParts = {
//     model: 'VW Golf II',
//     power: 90,
//     color: 'blue',
//     carriage: 'hatchback',
//     wheelsize: 14
// }

// console.log(assembleCar(carParts));