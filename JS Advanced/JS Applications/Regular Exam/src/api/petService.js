import * as api from './api.js'

const endpoints = {
    getAll: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    // getAllRecent: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    create: '/data/pets',
    getById: (id) => `/data/pets/${id}`,    
    updateById: (id) => `/data/pets/${id}`,
    deleteById: (id) => `/data/pets/${id}`,
    donate: `/data/donation`,
    getTotalDonationsById: (id) => `/data/donation?where=petId%3D%22${id}%22&distinct=_ownerId&count`,
    hasUserDonated: (petId, userId) => `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
}


export async function getAllPets() {
    const res = await api.get(endpoints.getAll);

    return res;
}

export async function createPet(data) {
    const res = await api.post(endpoints.create, data);

    return res;
}

export async function getPet(id) {
    const res = await api.get(endpoints.getById(id));

    return res;
}

export async function updatePet(id, data) {
    const res = await api.put(endpoints.updateById(id), data);

    return res;
}

export async function deletePet(id) {
    const res = await api.del(endpoints.deleteById(id));

    return res;
}

export async function donate(data) {
    const res = await api.post(endpoints.donate, data);

    return res;
}

export async function getTotalDonationsCount(id) {
    const res = await api.get(endpoints.getTotalDonationsById(id));

    return res;
}


export async function hasUserDonated(petId, userId) {
    const res = await api.get(endpoints.hasUserDonated(petId, userId));

    return res;
}
