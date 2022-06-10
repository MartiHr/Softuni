import { html } from "../../node_modules/lit-html/lit-html.js";
import { startGame } from "../gameLogic.js";

const gameTemplate = (tbodyTemplate) => {
    return html`
    <p id="player-turn">Player 1's turn!</p>
    <table>
        ${tbodyTemplate}
    </table>`;
}

const tbodyTemplate = (sizeX, sizeY, ctx) => {
    return html`
    <tbody @click=${startGame.bind(null, ctx)}>
        ${trTemplate(sizeX, sizeY)}
    </tbody>`;
}

const trTemplate = (sizeX = 3, sizeY = 3) => {
    let stringArr = [];

    for (let i = 0; i < sizeX; i++) {
        let template =
            html`
        <tr>
            ${tdElementsTemplate(sizeY, i)}
        </tr>`;

        stringArr.push(template);
    }

    return html`${stringArr}`;
}

const tdElementsTemplate = (sizeY = 3, index) => {
    let stringArr = [];

    for (let i = 0; i < sizeY; i++) {
        stringArr.push(html`<td><i id=${index}-${i} class="fa-solid fa-diamond"></i></td>`);
    }

    return html`${stringArr}`;
}


export const gameView = (ctx) => {
    let sizeX = sessionStorage.getItem('sizeX');
    let sizeY = sessionStorage.getItem('sizeY');



    ctx.render(gameTemplate(tbodyTemplate(sizeX, sizeY, ctx)));
}

