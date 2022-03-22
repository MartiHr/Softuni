import { deleteItemById, getItemById } from '../api/data.js';
import { html } from '../library.js'

const detailsTemplate = (item, isUserOwner, onDelete) => {
    return html` 
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Furniture Details</h1>
        </div>
    </div>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src="${item.img.substring(1, item.img.length)}" />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <p>Make: <span>${item.make}</span></p>
            <p>Model: <span>${item.model}</span></p>
            <p>Year: <span>${item.year}</span></p>
            <p>Description: <span>${item.description}</span></p>
            <p>Price: <span>${item.price}</span></p>
            <p>Material: <span>${item.material}</span></p>
            <div>
                ${isUserOwner ? html` 
                <a href='${`/edit/${item._id}`}' class="btn btn-info">Edit</a>
                <a href='javascript:void(0)' class="btn btn-red" @click=${onDelete}>Delete</a>` : null}
            </div>
        </div>
    </div>`
}

export function detailsView(ctx) {

    update();

    async function update() {
        let item = await getItemById(ctx.params.id);
        let isUserOwner = item._ownerId == sessionStorage.userId;        

        ctx.render(detailsTemplate(item, isUserOwner, onDelete));
    }

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this item?');

        if (choice) {
            await deleteItemById(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}