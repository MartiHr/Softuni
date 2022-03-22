import { getAllItems, getOwnedItemsById } from '../api/data.js';
import { html } from '../library.js'

const itemTemplate = (itemData) => {
    return html`
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=${itemData.img} />
                <p>${itemData.description}</p>
                <footer>
                    <p>Price: <span>${itemData.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${itemData._id}" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>
    </div>`;
}

const catalogTemplate = (itemsTemplate, pageOfUser) => {
    return html`<div class="row space-top">
    <div class="col-md-12">
        ${!pageOfUser 
        ? html`
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>`
        : html`
            <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>`}
    </div>
    </div>
    <div class="row space-top">
        ${itemsTemplate}
    </div>`
}

export async function catalogView(ctx) {
    const pageOfUser = ctx.pathname == '/my-furniture';
    let data = await loadItems(pageOfUser);
    let itemsAsTemplate = data.map(itemData => itemTemplate(itemData));
    
    ctx.render(catalogTemplate(itemsAsTemplate, pageOfUser));
}

async function loadItems(pageOfUser) {

    let data = [];

    if (pageOfUser) {
        data = await getOwnedItemsById(sessionStorage.userId);
    } else {
        data = await getAllItems();
    }

    return await data;
}