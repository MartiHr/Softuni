import { html } from "../../node_modules/lit-html/lit-html.js";
import { startGame } from "../gameLogic.js";

const winnerTemplate = (winner, playAgainHandler) => html`
        <div class="end">
            <div class="game-over">
                <h2>${winner} won!</h2>
                <button @click=${playAgainHandler}>Play again</button>
            </div>
        </div>
        `;

export const gameOverView = (ctx) => {
    let winner = sessionStorage.getItem('turn') == 'playerTwo' ? 'Player 1' : 'Player 2';

    ctx.render(winnerTemplate(winner, playAgainHandler.bind(null, ctx)));
    sessionStorage.clear();
}

function playAgainHandler(ctx) {
    ctx.page.redirect('/');
}