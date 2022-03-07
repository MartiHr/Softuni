async function getInfo() {

    const stopIdElement = document.getElementById('stopId');
    const stopNameElement = document.getElementById('stopName');
    const busesDiv = document.getElementById('buses');

    try {
        stopNameElement.textContent = '';
        busesDiv.innerHTML = '';

        const url = `http://localhost:3030/jsonstore/bus/businfo/${stopIdElement.value}`
        const res = await fetch(url);
        
        if (res.status != 200) {
            throw new Error();
        }
        
        const data = await res.json();

        stopNameElement.textContent = data.name;

        Object.entries(data.buses).forEach(x => {
            let liElement = document.createElement('li');

            liElement.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`

            busesDiv.append(liElement);
        });
    } catch (error) {
        stopNameElement.textContent = 'Error';
    }
}