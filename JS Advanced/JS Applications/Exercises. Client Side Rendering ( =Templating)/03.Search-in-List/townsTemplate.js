import { html } from "../node_modules/lit-html/lit-html.js"
import { searchTownsForText } from "./search.js";

export const townsTemplate = (data, searchText) => {
    return html`
    <ul>
        ${data.map(town => html`<li class=${searchTownsForText(town, searchText) ? 'active': ''}>${town}</li>`)}       
    </ul>`;
}