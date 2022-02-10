function solve() {

	let [generateButtonElement, buyButtonElement] = document.querySelectorAll('button');
	let [inputTextElement, outputTextElement] = document.querySelectorAll('textArea');

	generateButtonElement.addEventListener('click', generateFurnitureEvent);
	buyButtonElement.addEventListener('click', buySelectedItemsEvent);

	function buySelectedItemsEvent(e) {
		
		let checkboxElements = document.querySelectorAll('input[type="checkbox"]');

		let items = [];

		for (const checkboxElement of checkboxElements) {

			if (!checkboxElement.checked)
			{
				continue;
			}

			let [nameElement, priceElement, decFactorElement] = checkboxElement.parentElement.parentElement.querySelectorAll('p');
			
			let item = {
				name: nameElement.textContent,
				price: Number(priceElement.textContent),
				decFactor: Number(decFactorElement.textContent)
			}

			items.push(item);
		}

		let result = 'Bought furniture: ';

		result += items.map(x => x.name).join(', ');

		let totalPrice = 0;

		items.forEach(x => {
			totalPrice += x.price;
		})

		let totalDecFator = 0;
		
		items.forEach(x => {
			totalDecFator += x.decFactor;
		})

		result += '\n' + `Total price: ${totalPrice.toFixed(2)}`;
		result += '\n' + `Average decoration factor: ${totalDecFator / items.length}`;

		outputTextElement.value = result;
	}

	function generateFurnitureEvent(e) {

		let objects = JSON.parse(inputTextElement.value);

		for (const object of objects) {

			let rowElement = document.createElement('tr');

			let imageTdElement = document.createElement('td');
			let imageElement = document.createElement('img');
			imageElement.src = object.img;

			imageTdElement.appendChild(imageElement);
			rowElement.appendChild(imageTdElement);

			let nameTdElement = document.createElement('td');
			let nameElement = document.createElement('p');
			nameElement.textContent = object.name;

			nameTdElement.appendChild(nameElement);
			rowElement.appendChild(nameTdElement);

			let priceTdElement = document.createElement('td');
			let priceElement = document.createElement('p');
			priceElement.textContent = object.price;

			priceTdElement.appendChild(priceElement);
			rowElement.appendChild(priceTdElement);

			let decorationFactorTdElement = document.createElement('td');
			let decorationFactorElement = document.createElement('p');
			decorationFactorElement.textContent = object.decFactor;

			decorationFactorTdElement.appendChild(decorationFactorElement);
			rowElement.appendChild(decorationFactorTdElement);

			let markTdElement = document.createElement('td');
			let markElement = document.createElement('input');
			markElement.type = 'checkbox';

			markTdElement.appendChild(markElement);
			rowElement.appendChild(markTdElement);

			let tableElement = document.querySelector('tbody');
			tableElement.appendChild(rowElement);
		}
	}
}



// [
//     {
// 		"img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg",
// 		"name": "Sofa",
// 		 "price": 150,
// 		 "decFactor": 1.2
// 	}
// ]

// [
//     {
// 		"name": "Sofa",
// 		 "price": 150,
// 		 "decFactor": 1.2
// 	},
// {
// 		"name": "Sofa",
// 		 "price": 150,
// 		 "decFactor": 1.2
// 	}
// ]