function townsToJSON(dataArr) {
    
    let result = [];

    const regex = new RegExp(/\s*\|\s*/)

    for (let i = 1; i < dataArr.length; i++) {
        
        let [town, latitude, longitude] = dataArr[i].split(regex).filter(Boolean);
        latitude = Number(latitude);
        longitude = Number(longitude);

        let obj = {
            Town: town,
            Latitude: Number(latitude.toFixed(2)),
            Longitude: Number(longitude.toFixed(2)),
        }
        
        result.push(obj);
    }

    console.log(JSON.stringify(result));
}

// townsToJSON(['| Town | Latitude | Longitude |',
//     '| Sofia | 42.696552 | 23.32601 |',
//     '| Beijing | 39.913818 | 116.363625 |'])