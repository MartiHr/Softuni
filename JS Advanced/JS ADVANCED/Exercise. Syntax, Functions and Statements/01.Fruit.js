function logFruitPrice(fruitType, weightInGrams, pricePerKilogram) {
    
    let weightInKilos = weightInGrams / 1000 ; 
    let totalPrice = weightInKilos * pricePerKilogram;
    
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKilos.toFixed(2)} kilograms ${fruitType}.`);
}