window.addEventListener('load', solve);

function solve() {
    let sendFormElement = document.querySelector('button[type="submit"]');

    sendFormElement.addEventListener('click', (e) => {
        e.preventDefault();

        let productTypeElement = document.getElementById('type-product');
        let descriptionElement = document.getElementById('description');
        let [clientNameElement, clientPhoneElement] = document.querySelectorAll('input[type="text"]')

        if (!descriptionElement.value || !clientNameElement.value || !clientPhoneElement.value) {
            return;
        }

        if (productTypeElement.value != 'Phone' && productTypeElement.value != 'Computer') {
            return;
        }

        let receivedOrdersElement = document.getElementById('received-orders');

        let divContainerElement = document.createElement('div');
        divContainerElement.classList.add('container');

        let h2Element = document.createElement('h2');
        h2Element.textContent = `Product type for repair: ${productTypeElement.value}`;
        divContainerElement.appendChild(h2Element);

        let h3Element = document.createElement('h3');
        h3Element.textContent = `Client information: ${clientNameElement.value}, ${clientPhoneElement.value}`;
        divContainerElement.appendChild(h3Element);

        let h4Element = document.createElement('h4');
        h4Element.textContent = `Description of the problem: ${descriptionElement.value}`;
        divContainerElement.appendChild(h4Element);

        let startButtonElement = document.createElement('button');
        startButtonElement.classList.add('start-btn');
        startButtonElement.textContent = 'Start repair';
        divContainerElement.appendChild(startButtonElement);

        let finishButtonElement = document.createElement('button');
        finishButtonElement.classList.add('finish-btn');
        finishButtonElement.textContent = 'Finish repair';
        finishButtonElement.disabled = true;
        divContainerElement.appendChild(finishButtonElement);

        receivedOrdersElement.appendChild(divContainerElement);

        descriptionElement.value = '';
        clientNameElement.value = '';
        clientPhoneElement.value = '';

        startButtonElement.addEventListener('click', (e) => {
            e.target.disabled = true;
            finishButtonElement.disabled = false;
        });

        finishButtonElement.addEventListener('click', () => {
            let completedOrders = document.getElementById('completed-orders');

            receivedOrdersElement.removeChild(divContainerElement);
            divContainerElement.removeChild(startButtonElement);
            divContainerElement.removeChild(finishButtonElement);
            completedOrders.appendChild(divContainerElement);
        });

        let clearButtonElement = document.querySelector('button[class="clear-btn"]');
        clearButtonElement.addEventListener('click', (e) => {
            for (const divElement of e.target.parentNode.getElementsByTagName('div')) {
                e.target.parentNode.removeChild(divElement);
            }
        });
    });
}