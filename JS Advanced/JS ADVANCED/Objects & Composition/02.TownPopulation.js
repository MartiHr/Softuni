function createRegistry(townsAsString) {
    
    let towns = {};

    for (const townString of townsAsString) {
        
        let [townName, populationString] = townString.split(' <-> ');
        let population = Number(populationString);

        if (!towns[townName]) {
            towns[townName] = 0;
        }

        towns[townName] += population;
    }

    for (const town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }
}