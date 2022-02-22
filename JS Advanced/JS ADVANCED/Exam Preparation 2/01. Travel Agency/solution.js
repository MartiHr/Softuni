window.addEventListener('load', solution);

function solution() {

	let submitButtonElement = document.getElementById('submitBTN');

	submitButtonElement.addEventListener('click', (e) => {
		let [nameElement, emailElement, phoneElement, addressElement, postalCodeElement] =
			document.getElementsByTagName('input');
		
		if (!nameElement.value || !emailElement.value) {
			throw Error;
		}

		let inputName = nameElement.value;
		let inputEmail = emailElement.value;
		let inputPhone = phoneElement.value;
		let inputAddress = addressElement.value;
		let inputPostal = postalCodeElement.value;

		let ulElement = document.getElementById('infoPreview');

		let liNameElement = document.createElement('li');
		liNameElement.textContent = 'Full Name: ' + nameElement.value;
		ulElement.appendChild(liNameElement);

		let liEmailElement = document.createElement('li');
		liEmailElement.textContent = 'Email: ' + emailElement.value;
		ulElement.appendChild(liEmailElement);

		let liPhoneElement = document.createElement('li');
		liPhoneElement.textContent = 'Phone Number: ' + phoneElement.value;
		ulElement.appendChild(liPhoneElement);

		let liAddressElement = document.createElement('li');
		liAddressElement.textContent = 'Address: ' + addressElement.value;
		ulElement.appendChild(liAddressElement);

		let liPostalElement = document.createElement('li');
		liPostalElement.textContent = 'Postal Code: ' + postalCodeElement.value;
		ulElement.appendChild(liPostalElement);

		nameElement.value = '';
		emailElement.value = '';
		phoneElement.value = '';
		addressElement.value = '';
		postalCodeElement.value = '';

		e.target.disabled = true;

		let editButtonElement = document.getElementById('editBTN');
		let continueButtonElement = document.getElementById('continueBTN');

		editButtonElement.disabled = false;
		continueButtonElement.disabled = false;

		editButtonElement.addEventListener('click', (e) => {
			nameElement.value = inputName;
			emailElement.value = inputEmail;
			phoneElement.value = inputPhone;
			addressElement.value = inputAddress;
			postalCodeElement.value = inputPostal;

			ulElement.removeChild(liNameElement);
			ulElement.removeChild(liEmailElement);
			ulElement.removeChild(liPhoneElement);
			ulElement.removeChild(liAddressElement);
			ulElement.removeChild(liPostalElement);

			submitButtonElement.disabled = false;
			editButtonElement.disabled = true;
			continueButtonElement.disabled = true;
		});

		continueButtonElement.addEventListener('click', (e) => {
			let divBlockElement = document.getElementById('block');
			divBlockElement.innerHTML = '';

			let endElement = document.createElement('h3');
			endElement.textContent = 'Thank you for your reservation!';

			divBlockElement.appendChild(endElement);
		});
	});
}