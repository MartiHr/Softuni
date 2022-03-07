function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

    const loadBooksButtonElement = document.getElementById('loadBooks');
    const tbodyElement = document.querySelector('tbody');

    const [inputTitleElement, inputAuthorElement] = document.querySelectorAll('input');
    const h3Element = document.querySelector('h3');

    const formElement = document.querySelector('form');
    const submitButtonElement = formElement.querySelector('button');

    try {
        displayBooks();
        loadBooksButtonElement.addEventListener('click', displayBooks);
        formElement.addEventListener('submit', (e) => {
            e.preventDefault();

            let [titleInputElement, authorInputElement] = e.currentTarget.querySelectorAll('input');

            let data = {
                author: authorInputElement.value,
                title: titleInputElement.value,
            }

            if (!data.title || !data.author) {
                alert('Error');
            } else {
                if (submitButtonElement.textContent == 'Submit') {
                    fetch(baseUrl, {
                        method: `POST`,
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(data),
                    })
                    .catch(error => alert('Error'));
                } else if (submitButtonElement.textContent == 'Save') {

                    fetch(`${baseUrl}/${localStorage.getItem('_id')}`, {
                        method: `PUT`,
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(data),
                    })
                    .catch(error => alert('Error'));

                    localStorage.clear();
                    h3Element.textContent = 'FORM';
                    submitButtonElement.textContent = 'Submit';

                    displayBooks();
                }

                titleInputElement.value = '';
                authorInputElement.value = '';
                alert('Successful operation!');
            }
        });
    } catch (error) {
        alert('Error');
    }

    async function displayBooks() {
        tbodyElement.innerHTML = '';

        let books = await fetchStudents(baseUrl);

        for (const bookId in books) {
            let bookRowElement = createBookRowElement(books[bookId], bookId);
            tbodyElement.append(bookRowElement);
        }
    }

    async function fetchStudents(url) {
        let res = await fetch(url);

        if (res.status != 200) {
            alert('Error');
        }

        let data = await res.json();

        return data;
    }

    function createBookRowElement(book, bookId) {
        let trElement = document.createElement('tr');


        let titleTdElement = createElementWithText('td', book.title);
        trElement.append(titleTdElement);

        let authorTdElement = createElementWithText('td', book.author);
        trElement.append(authorTdElement);

        let buttonsTdElement = createElementWithText('td');

        let editButtonElement = createElementWithText('button', 'Edit');

        editButtonElement.addEventListener('click', (e) => {
            h3Element.textContent = 'Edit FORM';
            inputTitleElement.value = book.title;
            inputAuthorElement.value = book.author;
            submitButtonElement.textContent = 'Save';

            localStorage.setItem('_id', bookId);
        });

        buttonsTdElement.append(editButtonElement);

        let deleteButtonElement = createElementWithText('button', 'Delete');

        deleteButtonElement.addEventListener('click', async (e) => {
            let res = await fetch(`${baseUrl}/${bookId}`, {
                method: 'DELETE'
            });

            if (res.status != 200) {
                alert('Error');
            }

            localStorage.clear();
            h3Element.textContent = 'FORM';
            submitButtonElement.textContent = 'Submit';

            tbodyElement.removeChild(trElement);
        });

        buttonsTdElement.append(deleteButtonElement);

        trElement.append(buttonsTdElement);

        return trElement;
    }

    function createElementWithText(type, text) {
        let element = document.createElement(type);

        if (text) {
            element.textContent = text;
        }

        return element;
    }
}

attachEvents();