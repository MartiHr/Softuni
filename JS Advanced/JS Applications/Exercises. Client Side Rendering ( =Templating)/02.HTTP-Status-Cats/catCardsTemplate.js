import { html } from "../node_modules/lit-html/lit-html.js"
import { catCardTemplate } from "./catCardTemplate.js"

export const catCardsTemplate = (data) => {
    return html`
    <ul>
        ${data.map(catInfo => catCardTemplate(catInfo))}
    </ul>`
}