import { html } from "../../node_modules/lit-html/lit-html.js";

import { update } from "../app.js";
import { addFormTemplate } from "./addFormTeplate.js";
import { booksTemplate } from "./booksTemplate.js";
import { editFormTemplate } from "./editFormTemplate.js";

export const pageTemplate = (books) => {
    return html`
    <button id="loadBooks" @click=${update}>LOAD ALL BOOKS</button>
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            ${booksTemplate(books)}
        </tbody>
    </table>
    
    ${addFormTemplate()}
    
    ${editFormTemplate()}`
}