import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deletePet, donate, getPet, getTotalDonationsCount, hasUserDonated } from "../api/petService.js";

const detailsTemplate = (pet, user, isOwner, deleteHandler, hasNotDonated, donateHandler) => {
    return html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: ${pet.totalDonations}$</h4>
                </div>

                <!-- if there is no registered user, do not display div-->
                ${user
                    ? html`
                        <div class="actionBtn">
                            ${isOwner
                                ? html` 
                                    <a href="/details/${pet._id}/edit" class="edit">Edit</a>
                                    <a href="javascript:void(0)" class="remove" @click=${deleteHandler}>Delete</a>`
                                : hasNotDonated 
                                    ? html`<a href="javascript:void(0)" class="donate" @click=${donateHandler}>Donate</a>` 
                                    : nothing}                               
                        </div>`
                    : nothing
                }
            </div>
        </div>
    </section>`
}

export const detailsView = async (ctx) => {
    const pet = await getPet(ctx.params.id);
    let isOwner = false;
    let hasNotDonated = false;
    if (ctx.user) {
        isOwner = pet._ownerId == ctx.user._id;
        hasNotDonated = await hasUserDonated(ctx.params.id, ctx.user._id) == 0 ? true : false;
    }

    pet.totalDonations = await getTotalDonationsCount(ctx.params.id) * 100;

    ctx.render(detailsTemplate(pet, ctx.user, isOwner, deleteHandler.bind(null, ctx), hasNotDonated, donateHandler.bind(null, ctx)));
}

async function deleteHandler(ctx, e) {
    e.preventDefault();

    const confirmed = confirm('Do you want to delete this pet?');

    if (confirmed) {
        await deletePet(ctx.params.id);
        
        ctx.page.redirect('/');
    }
}

async function donateHandler(ctx, e) {
    e.preventDefault();

    let petId = ctx.params.id;
    await donate({ petId });
    
    ctx.page.redirect(`/details/${ctx.params.id}`);
}