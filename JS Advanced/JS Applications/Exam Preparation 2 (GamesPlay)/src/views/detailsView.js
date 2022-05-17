import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteGame, getGameById } from "../api/gameService.js";

const detailsTemplate = (game, owner, deleteHandler) => {
    return html`
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
    
            <div class="game-header">
                <img class="game-img" src="${game.imageUrl}" />
                <h1>${game.title}</h1>
                <span class="levels">MaxLevel: ${game.maxLevel}</span>
                <p class="type">${game.category}</p>
            </div>
    
            <p class="text">${game.summary}</p>
    
            <!-- Bonus ( for Guests and Users ) -->
            <div class="details-comments">
                <h2>Comments:</h2>
                <ul>
                    <!-- list all comments for current game (If any) -->
                    <li class="comment">
                        <p>Content: I rate this one quite highly.</p>
                    </li>
                    <li class="comment">
                        <p>Content: The best game.</p>
                    </li>
                </ul>
                <!-- Display paragraph: If there are no games in the database -->
                <p class="no-comment">No comments.</p>
            </div>
    
            ${owner
                ? html`
                    <div class="buttons">
                        <a href="/details/${game._id}/edit" class="button">Edit</a>
                        <a href="javascript:void(0)" class="button" @click=${deleteHandler}>Delete</a>
                    </div>`
                : nothing
            }
        </div>
    
        Bonus
        <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
        <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>
    
    </section>
    `
}

export const detailsView = async (ctx) => {
    const game = await getGameById(ctx.params.id);

    let owner = false;

    if (ctx.user && ctx.user._id == game._ownerId) {
        owner = true;
    }

    ctx.render(detailsTemplate(game, owner, deleteHandler.bind(null, ctx)));
}

async function deleteHandler(ctx, e) {
    e.preventDefault();

    const confirmed = confirm('Do you want to delete this game?');

    if (confirmed) {
        await deleteGame(ctx.params.id);
    }

    ctx.page.redirect('/');
}