import { html } from "../node_modules/lit-html/lit-html.js"

export const optionsTemplate = (data) => {
    return html`${data.map(x => html`<option value=${x._id}>${x.text}</option>`)}`;
}
