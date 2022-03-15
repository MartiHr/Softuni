import { render, html} from '../node_modules/lit-html/lit-html.js';
import { contacts } from "./contacts.js";

const divContatcsContainerElement = document.getElementById('contacts');

const contactCardsTemplate = (data) => html`
    ${data.map(contact => 
    html`
        <div class="contact card">
            <div>
                <i class="far fa-user-circle gravatar"></i>
            </div>
            <div class="info">
                <h2>Name: ${contact.name}</h2>
                <button class="detailsBtn" @click=${showDetails}>Details</button>
                <div class="details" id="${contact.id}">
                    <p>Phone number: ${contact.phoneNumber}</p>
                    <p>Email: ${contact.email}</p>
                </div>
            </div>
        </div>`)}`;

render(contactCardsTemplate(contacts), divContatcsContainerElement);

function showDetails(e) {
    e.preventDefault();

    let detailsElement = e.target.parentNode.querySelector('div');

    if (detailsElement.style.display == 'none') {
        detailsElement.style.display = 'block'
    } else {
        detailsElement.style.display = 'none'
    }
};       