import { html, nothing } from "../../node_modules/lit-html/lit-html.js"
import { getAlbumById, updateAlbum } from "../api/albumService.js";
import { getUserData } from "../util.js";

const editTemplate = (album, isOwner, editHandler) => {
    return html`
        <section class="editPage">
            <form @submit=${editHandler}>
                <fieldset>
                    <legend>Edit Album</legend>
        
                    <div class="container">
                        <label for="name" class="vhide">Album name</label>
                        <input id="name" name="name" class="name" type="text" value="${album.name}">
        
                        <label for="imgUrl" class="vhide">Image Url</label>
                        <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value="${album.imgUrl}">
        
                        <label for="price" class="vhide">Price</label>
                        <input id="price" name="price" class="price" type="text" value="${album.price}">
        
                        <label for="releaseDate" class="vhide">Release date</label>
                        <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value="${album.releaseDate}">
        
                        <label for="artist" class="vhide">Artist</label>
                        <input id="artist" name="artist" class="artist" type="text" value="${album.artist}">
        
                        <label for="genre" class="vhide">Genre</label>
                        <input id="genre" name="genre" class="genre" type="text" value="${album.genre}">
        
                        <label for="description" class="vhide">Description</label>
                        <textarea name="description" class="description" rows="10"
                            cols="10">${album.description}</textarea>
        
                        ${isOwner
                            ? html`<button class="edit-album" type="submit">Edit Album</button>`
                            : nothing
                        }
                    </div>
                </fieldset>
            </form>
        </section>
    `;
}

export const editView = async (ctx) => {
    const album = await getAlbumById(ctx.params.id);

    let isOwner = album._ownerId == getUserData()._id;
    ctx.render(editTemplate(album, isOwner, editHandler.bind(null, ctx)));
}

function editHandler(ctx, e) {
    e.preventDefault();

    const inputFieldsDataObject = Object.fromEntries(new FormData(e.currentTarget));

    let emptyFields = false;
    for (const field in inputFieldsDataObject) {
        if (!inputFieldsDataObject[field]) {
            emptyFields = true;
        }
    }

    if (emptyFields) {
        return alert('Fill in all input boxes.');
    }

    updateAlbum(ctx.params.id, inputFieldsDataObject);

    ctx.page.redirect(`/catalog/details/${ctx.params.id}`);
}