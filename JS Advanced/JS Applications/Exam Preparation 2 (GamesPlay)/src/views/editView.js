import { html } from "../../node_modules/lit-html/lit-html.js";
import { createGame, getGameById, updateGame } from "../api/gameService.js";

const editTemplate = (game, editHandler) => {
    return html`
         <section id="edit-page" class="auth">
            <form id="edit" @submit=${editHandler}>
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" .value="${game.title}">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" .value="${game.category}">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" .value="${game.maxLevel}">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" .value="${game.imageUrl}">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary">${game.summary}</textarea>
                    <input class="btn submit" type="submit" .value="Edit Game">

                </div>
            </form>
        </section>
    `
}

export const editView = async (ctx) => {
    const game = await getGameById(ctx.params.id);

    ctx.render(editTemplate(game, editHandler.bind(null, ctx)))
}

async function editHandler(ctx, e) {
    e.preventDefault();

    const fieldsDataObject = Object.fromEntries(new FormData(e.currentTarget));

    if (Object.values(fieldsDataObject).some(field => !field)) {
        return alert('Fill in all input boxes');
    }

    const confirmed = confirm('Are you sure you want to edit this game?');

    if (confirmed) {
        await updateGame(gameId, fieldsDataObject);
    }

    ctx.page.redirect(`/details/${ctx.params.id}`);
}