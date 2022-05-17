import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllGames } from "../api/gameService.js";

const cardTemplate = (game) => {
    return html`
    <div class="allGames">
        <div class="allGames-info">
            <img src="${game.imageUrl}">
            <h6>${game.category}</h6>
            <h2>${game.title}</h2>
            <a href="/details/${game._id}" class="details-button">Details</a>
        </div>
    </div>`;
}

const catalogTemplate = (gamesTemplate) => {
    return html`
    <section id="catalog-page">
        <h1>All Games</h1>

        ${gamesTemplate
            ? gamesTemplate
            : html`<h3 class="no-articles">No articles yet</h3>`
        }
    </section>`;
}

export const catalogView = async (ctx) => {
    
    const games = await getAllGames();
    
    let gamesTemplate = '';
    if (games.length > 0) {
        gamesTemplate = games.map(g => cardTemplate(g));
    }
    
    ctx.render(catalogTemplate(gamesTemplate));
}