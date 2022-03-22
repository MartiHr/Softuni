import { html } from "../../node_modules/lit-html/lit-html.js";

export const addFormTemplate = () => {
    return html`
    <form id="add-form" display="none">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit" @click=${addBook}>
    </form>`;
}

function addBook(e) {
    e.preventDefault();

    let formElement = e.target.parentNode;

    let formData = new FormData(formElement);

    let title = formData.get('title');
    let author = formData.get('author');

    if (title && author) {
        let data = {
            author,
            title
        }

        fetch('http://localhost:3030/jsonstore/collections/books', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(res => {
                if (res.status != 200) {
                    throw new Error();
                }
            })
            .catch(error => alert('Error'));

        formElement.reset();
    } else {
        alert('Fill in all input boxes.')
    }
}