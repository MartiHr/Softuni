import { html } from "../../node_modules/lit-html/lit-html.js";
import { startGame } from "../gameLogic.js";

const homeTemplate = (startHandler) => html`
        <div id="home">
            <h1>Queens</h1>
            <div>
                <label for="size-x">Please enter number of rows:</label>
                <input id="size-x" name="number" type="number" value="5" min="3" max="20">
                <label for="size-y">Please enter number of columns:</label>
                <input id="size-y" name="number" type="number" value="5" min="3" max="20">
            </div>
            <button @click=${startHandler}>Multiplayer</button>
            <button class='bot' @click=${startHandler}>1v1 (Find friends please)</button>
        </div>
    `;

export const homeView = (ctx) => {
    ctx.render(homeTemplate(startHandler.bind(null, ctx)));
}

function startHandler(ctx, e) {
    let sizeX = document.querySelector('input#size-x').value;
    let sizeY = document.querySelector('input#size-y').value;

    if (e.target.classList.contains('bot')) {
        sessionStorage.setItem('bot', 'bot')
    }

    sessionStorage.setItem('turn', 'playerOne')
    sessionStorage.setItem('sizeX', sizeX)
    sessionStorage.setItem('sizeY', sizeY)

    if (sizeX > 2 && sizeY > 2) {
        
        ctx.page.redirect(`/game`);
    } else {
        alert('There a number which is too small in the input! Enter numbers bigger than two.');
    }

}