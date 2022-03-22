import { html } from "../../node_modules/lit-html/lit-html.js";
import { update } from "../app.js";

export const editFormTemplate = () => {
    return html`
    <form id="edit-form">
        <!-- <input type="hidden" name="id"> -->
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Save" @click=${saveChanges}>
    </form>`;
}

function saveChanges(e) {
    e.preventDefault();

    let editFormElement = document.querySelector('form[id="edit-form"]')
    let formData = new FormData(editFormElement);

    let title = formData.get('title');
    let author = formData.get('author');

    if (title && author) {
        let data = {
            author,
            title
        }

        fetch(`http://localhost:3030/jsonstore/collections/books/${localStorage.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(res => {
                if (res.status != 200) {
                    throw new Error();
                }

                localStorage.clear();
            })
            .catch(error => alert('Error'));

        editFormElement.reset();
    } else {
        alert('Fill in all input boxes.')
    }

    showAddForm();
    
    update();
}

function showAddForm() {
    let addFormElement = document.querySelector('form[id="add-form"]')
    let editFormElement = document.querySelector('form[id="edit-form"]')

    addFormElement.style.display = 'block';
    editFormElement.style.display = 'none';
}