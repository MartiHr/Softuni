import { html } from "../node_modules/lit-html/lit-html.js"

export const catCardTemplate = (catData) => {
    return html`
    <li>
        <img src="./images/${catData.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn" @click=${toggle}>Show status code</button>
            <div class="status" style="display: none" id="${catData.id}">
                <h4>Status Code: ${catData.statusCode}</h4>
                <p>${catData.statusMessage}</p>
            </div>
        </div>
    </li >`;
}

function toggle(e) {
    e.preventDefault();

    let detailsDivElement = e.target.parentNode.children[1];

    if (detailsDivElement.style.display == 'none') {
        e.target.textContent = 'Hide status code'
        detailsDivElement.style.display = 'block';
    } else {
        detailsDivElement.style.display = 'none'
        e.target.textContent = 'Show status code'
    }
}