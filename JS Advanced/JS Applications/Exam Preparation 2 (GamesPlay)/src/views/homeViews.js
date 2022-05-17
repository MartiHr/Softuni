import { html } from "../../node_modules/lit-html/lit-html.js";
import { getRecentGames } from "../api/gameService.js";

const cardTemplate = (game) => {
    return html`  
    <div class="game">
        <div class="image-wrap">
            <img src="${game.imageUrl}">
        </div>
        <h3>${game.title}</h3>
        <div class="rating">
            <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
        </div>
        <div class="data-buttons">
            <a href="/details/${game._id}" class="btn details-btn">Details</a>
        </div>
    </div>`;
}

const homeTemplate = (gamesTemplate) => {
    return html`
    <section id="welcome-world">
    
        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero">
    
        <div id="home-page">
            <h1>Latest Games</h1>

            ${gamesTemplate
                ? gamesTemplate
                : html`<p class="no-articles">No games yet</p>`
            }
        </div>
    </section>`;
}

export const homeView = async (ctx) => {
    const games = await getRecentGames();

    let gamesTemplate = '';
    if (games.length > 0) {
        gamesTemplate = games.map(g => cardTemplate(g));
    }

    ctx.render(homeTemplate(gamesTemplate));
}