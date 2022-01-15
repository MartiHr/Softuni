function pieceOfPie(flavors, targetFlavor1, targetFlavor2) {
    
    let flavorsInRange = flavors.slice(flavors.indexOf(targetFlavor1), flavors.indexOf(targetFlavor2) + 1);

    return flavorsInRange;
}