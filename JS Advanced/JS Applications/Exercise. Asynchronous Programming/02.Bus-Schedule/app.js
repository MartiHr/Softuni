function solve() {

    const departButtonElement = document.getElementById('depart');
    const arriveButtonElement = document.getElementById('arrive');
    const infoElement = document.getElementById('info').firstChild;

    let currentStop = {
        next: 'depot',
    };

    async function depart() {
        try {
            const url = `http://localhost:3030/jsonstore/bus/schedule/${currentStop.next}`;
            const res = await fetch(url);

            if (res.status != 200) {
                throw Error();
            }

            const data = await res.json();

            infoElement.textContent = `Next stop ${data.name}`;
            currentStop = data;

            departButtonElement.disabled = true;
            arriveButtonElement.disabled = false;
        } catch (error) {
            infoElement.textContent = 'Error';
        }
    }

    function arrive() {
        infoElement.textContent = `Arriving at ${currentStop.name}`;

        departButtonElement.disabled = false;
        arriveButtonElement.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();