function sortNames(nameArr) {
    nameArr.sort((a, b) => a.localeCompare(b));

    let orderNumber = 1;

    nameArr.forEach(x => {
        console.log(`${orderNumber++}.${x}`);
    })
}