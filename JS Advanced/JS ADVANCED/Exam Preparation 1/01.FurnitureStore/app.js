window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add');

    let totalPriceElement = document.querySelector('td[class="total-price"]');
    totalPriceElement.textContent = '0';

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let [modelElement, yearElement, priceElement] = document.getElementsByTagName('input');
        let descriptionElement = document.getElementById('description');

        if (!modelElement.value || !descriptionElement.value) {
            return;
        }

        if (Number(yearElement.value) <= 0 || Number(priceElement.value) <= 0) {
            return;
        }

        let tbodyElement = document.getElementById('furniture-list');

        //First tr
        let trInfoElement = document.createElement('tr');
        trInfoElement.classList.add('info');

        //Model
        let tdModel = document.createElement('td');
        tdModel.textContent = modelElement.value;
        trInfoElement.appendChild(tdModel);

        // Price
        let tdPrice = document.createElement('td');
        tdPrice.textContent = Number(priceElement.value).toFixed(2);
        trInfoElement.appendChild(tdPrice);

        //Actions
        let tdActionsElement = document.createElement('td');

        let moreButtonElement = document.createElement('button');
        moreButtonElement.textContent = 'More Info';
        moreButtonElement.classList.add('moreBtn');
        tdActionsElement.appendChild(moreButtonElement);

        let buyButtonElement = document.createElement('button');
        buyButtonElement.textContent = 'Buy it';
        buyButtonElement.classList.add('buyBtn');
        tdActionsElement.appendChild(buyButtonElement);

        trInfoElement.appendChild(tdActionsElement);

        //Second tr
        let trHideElement = document.createElement('tr');
        trHideElement.classList.add('hide');

        //Second tr, first td
        let yearTdElement = document.createElement('td');
        yearTdElement.textContent = 'Year: ' + yearElement.value;
        trHideElement.appendChild(yearTdElement);

        //Second tr, second td
        let descriptionTdElement = document.createElement('td');
        descriptionTdElement.colSpan = 3;
        descriptionTdElement.textContent = 'Description: ' + descriptionElement.value;
        trHideElement.appendChild(descriptionTdElement);

        //tBody add all tr
        tbodyElement.appendChild(trInfoElement);
        tbodyElement.appendChild(trHideElement);

        //Info button logic
        moreButtonElement.addEventListener('click', (e) => {
            if (moreButtonElement.textContent == 'More Info') {
                e.target.textContent = 'Less Info'
                trHideElement.style.display = 'contents';
            } else {
                e.target.textContent = 'More Info'
                trHideElement.style.display = 'none';
            }
        });

        //Buy button logic

        buyButtonElement.addEventListener('click', (e) => {
            totalPriceElement.textContent = (Number(totalPriceElement.textContent) + Number(tdPrice.textContent)).toFixed(2);
            tbodyElement.removeChild(trInfoElement);
            tbodyElement.removeChild(trHideElement);
        });

        //Clear input elements
        modelElement.value = '';
        yearElement.value = '';
        descriptionElement.value = '';
        priceElement.value = '';
    });
}