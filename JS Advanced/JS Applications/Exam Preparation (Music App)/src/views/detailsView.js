import { html, nothing } from "../../node_modules/lit-html/lit-html.js"
import { deleteAlbum, getAlbumById } from "../api/albumService.js";
import { getUserData } from "../util.js";

const detailsTemplate = (album, isOwner, deleteHandler) => {
    return html`
    <section id="detailsPage">
        <div class="wrapper">
            <div class="albumCover">
                <img src="${album.imgUrl}">
            </div>
            <div class="albumInfo">
                <div class="albumText">
    
                    <h1>Name: ${album.name}</h1>
                    <h3>Artist: ${album.artist}</h3>
                    <h4>Genre: ${album.genre}</h4>
                    <h4>Price: ${album.price}</h4>
                    <h4>Date: ${album.releaseDate}</h4>
                    <p>Description:${album.description}</p>
                </div>
    
                ${isOwner
                    ? html`
                    <div class="actionBtn">
                    <a href="/catalog/details/${album._id}/edit" class="edit">Edit</a>
                    <a href="javascript:void(0)" class="remove" @click=${deleteHandler}>Delete</a>
                    </div>`
                    : nothing
                }
            </div>
        </div>
    </section>`
}

export const detailsView = async (ctx) => {
    const album = await getAlbumById(ctx.params.id);

    let isOwner = album._ownerId == getUserData()._id;
    ctx.render(detailsTemplate(album, isOwner, deleteHandler.bind(null, ctx)));
}

async function deleteHandler(ctx, e) {
    e.preventDefault();

    let confirmed = confirm(`Are you sure you want to delete this album?`);

    if (confirmed) {
        deleteAlbum(ctx.params.id);
        ctx.page.redirect(`/catalog`);
    }
}