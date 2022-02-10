function displayInfo(...args) {
    
    let countByType = {};
    
    for (const element of args) {
        
        let type = typeof(element); 
        console.log(`${type}: ${element}`);

        if (!countByType[type]) {
            countByType[type] = 0;
        }

        countByType[type]++;
    }
}