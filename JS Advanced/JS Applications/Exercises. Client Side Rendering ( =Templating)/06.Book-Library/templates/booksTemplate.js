import { html } from "../../node_modules/lit-html/lit-html.js";
import { update } from "../app.js";

export const booksTemplate = (books) => {
    return html`${books.map(book => html`
        <tr id=${book._id}>
            <td>${book.title}</td>
            <td>${book.author}</td>
            <td>
                <button @click=${edit}>Edit</button>
                <button @click=${deleteElement}>Delete</button>
            </td>
        </tr>`
    )}`;
}

function edit(e) {
    e.preventDefault();

    let addFormElement = document.querySelector('form[id="add-form"]')
    let editFormElement = document.querySelector('form[id="edit-form"]')

    addFormElement.style.display = 'none';
    editFormElement.style.display = 'block';

    let tdElements = e.target.parentNode.parentNode.querySelectorAll('td');

    let title = tdElements[0].textContent;
    let author = tdElements[1].textContent;

    let [titleInputElement, authorInputElement] = editFormElement.querySelectorAll('input');

    titleInputElement.value = title;
    authorInputElement.value = author;

    showEditForm();

    localStorage.setItem('id', e.target.parentNode.parentNode.id);
}

function deleteElement(e) {
    e.preventDefault();
    
    let tbodyElement = document.querySelector('tbody');
    let trElement = e.target.parentNode.parentNode;

    fetch(`http://localhost:3030/jsonstore/collections/books/${trElement.id}`,{
        method: 'DELETE'
    })
    .catch(error => alert('Error'));
    
    tbodyElement.removeChild(trElement);
}

function showEditForm() {
    let addFormElement = document.querySelector('form[id="add-form"]')
    let editFormElement = document.querySelector('form[id="edit-form"]')

    addFormElement.style.display = 'none';
    editFormElement.style.display = 'block';
}