function attachEvents() {

    const baseUrl = `http://localhost:3030/jsonstore/phonebook/`;

    const loadButtonElement = document.getElementById('btnLoad');
    const phonebookUlElement = document.getElementById('phonebook');

    const createButtonElement = document.getElementById('btnCreate');
    const [personInputElement, phoneInputElement] = document.querySelectorAll('input');

    loadButtonElement.addEventListener('click', (e) => {
        fetch(baseUrl)
            .then(res => {
                if (res.status != 200) {
                    throw new Error();
                }

                return res.json();
            })
            .then(data => {
                phonebookUlElement.innerHTML = '';

                Object.values(data)
                    .forEach(x => {
                        let liElement = document.createElement('li');
                        liElement.textContent = `${x.person}: ${x.phone}`;
                        
                        let deleteButton = document.createElement('button');
                        deleteButton.textContent = 'Delete';

                        deleteButton.addEventListener('click', (e) =>{
                            fetch(`${baseUrl}/${x._id}`, {
                                method: 'DELETE'
                            })
                            .catch(error => alert('Error'));

                            phonebookUlElement.removeChild(liElement);
                        });

                        liElement.append(deleteButton);

                        phonebookUlElement.append(liElement);
                    })

            })
            .catch(error => alert('Error'))
    });

    createButtonElement.addEventListener('click', (e) => {
        if (personInputElement.value && phoneInputElement.value) {
            let data = {
                person: personInputElement.value,
                phone: phoneInputElement.value
            }

            fetch(baseUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data),
            })
            .catch(error => alert('Error'));
            
            personInputElement.value = '';
            phoneInputElement.value = '';
        } else {
            alert('Error')
        }
    });
}

attachEvents();