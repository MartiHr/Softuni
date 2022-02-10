function createHeroicInventory(heroesArr) {
    
    let result = [];

    for (const heroString of heroesArr) {
        let [name, level, items] = heroString.split(' / ');
        
        level = Number(level);
        items = items ? items.split(', ') : [];

        result.push({name, level, items});
    }

    console.log(JSON.stringify(result));
}