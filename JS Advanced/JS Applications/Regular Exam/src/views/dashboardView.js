import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllPets } from "../api/petService.js";

const cardTemplate = (pet) => {
    return html`
    <div class="animals-board">
        <article class="service-img">
            <img class="animal-image-cover" src="${pet.image}">
        </article>
        <h2 class="name">${pet.name}</h2>
        <h3 class="breed">${pet.breed}</h3>
        <div class="action">
            <a class="btn" href="/details/${pet._id}">Details</a>
        </div>
    </div>`;
}

const dashboardTemplate = (petsTemplate) => {
    return html`
    <section id="dashboard">
        <h2 class="dashboard-title">Services for every animal</h2>
        <div class="animals-dashboard">
    
            ${petsTemplate
                ? petsTemplate
                : html`
                    <div>
                        <p class="no-pets">No pets in dashboard</p>
                    </div>`
            }
        </div>
    </section>`;
}

export const dashboardView = async (ctx) => {
    const pets = await getAllPets();

    let petsTemplate = '';
    if (pets.length > 0) {
        petsTemplate = pets.map(p => cardTemplate(p));
    }

    ctx.render(dashboardTemplate(petsTemplate));
}