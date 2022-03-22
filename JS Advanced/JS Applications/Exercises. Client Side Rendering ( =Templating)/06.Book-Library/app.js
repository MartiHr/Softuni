import { render } from "../node_modules/lit-html/lit-html.js";
import { pageTemplate } from "./templates/pageTemplate.js";

const bodyElement = document.querySelector('body');

update();

export async function update() {
    let books = await getBooks();
    let template = pageTemplate(books);

    render(template, bodyElement);
}

async function getBooks() {
    try {
        const res = await fetch('http://localhost:3030/jsonstore/collections/books');

        if (res.status == 200) {
            const data = await res.json();

            let books = [];

            for (const key in data) {
                books.push({
                    _id: key,
                    author: data[key].author,
                    title: data[key].title
                });
            }

            return books;
        } else {
            throw new Error();
        }
    } catch (error) {
        alert('Error');
    }
}