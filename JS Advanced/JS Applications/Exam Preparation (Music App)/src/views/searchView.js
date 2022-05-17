import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { getAlbumsByQuery } from "../api/albumService.js";
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

const searchTemplate = (albumsTemplate, searchClicked, searchHandler) => {
    return html`
    <section id="searchPage">
        <h1>Search by Name</h1>
    
        <div class="search">
            <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
            <button class="button-list" @click=${searchHandler}>Search</button>
        </div>
    
        <h2>Results:</h2>
      
        ${searchClicked
            ? html`
                <div class="search-result">
                    ${albumsTemplate
                        ? albumsTemplate
                        : html`<p class="no-result">No result.</p>`
                    }
                </div>`
            : nothing
        }
    </section>`;
}

export const searchView = (ctx) => {
    ctx.render(searchTemplate('', false, searchHandler.bind(null, ctx)));
}

async function searchHandler(ctx, e) {
    e.preventDefault();

    const query = e.target.parentNode.querySelector('input').value;

    if (!query) {
        return alert('Fill search box');
    }

    const isLogged = Boolean(getUserData());
    const soughtAlbums = await getAlbumsByQuery(query);

    let soughtAlbumsTemplate = '';
    if (soughtAlbums.length > 0) {
        soughtAlbumsTemplate =  soughtAlbums.map(a => cardTemplate(a, isLogged));
    }

    ctx.render(searchTemplate(soughtAlbumsTemplate, true, searchHandler.bind(null, ctx)));
}