import { html, nothing } from "../../node_modules/lit-html/lit-html.js"

import { getAllAlbumbs } from "../api/albumService.js";
import { getUserData } from "../util.js";

const cardTemplate = (album, isLogged) => {
    return html`
    <div class="card-box">
        <img src="${album.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: ${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            ${isLogged 
                ? html`
                    <div class="btn-group">
                        <a id="details" href="/catalog/details/${album._id}">Details</a>
                    </div>`
                : nothing
            }
        </div>
    </div>
    `;
}

const catalogTemplate = (albumsTemplate) => {
    return html`
    <section id="catalogPage">
        <h1>All Albums</h1>

        ${albumsTemplate 
            ? albumsTemplate
            : html`<p>No Albums in Catalog!</p>`
        }
    </section>
    `;
}

export const catalogView = async (ctx) => {
    const albums = await getAllAlbumbs();
    let isLogged = Boolean(getUserData());

    let albumsTemplate = '';
    if (albums.length > 0) {
        albumsTemplate = albums.map(album => cardTemplate(album, isLogged));
    }
    
    ctx.render(catalogTemplate(albumsTemplate));
}