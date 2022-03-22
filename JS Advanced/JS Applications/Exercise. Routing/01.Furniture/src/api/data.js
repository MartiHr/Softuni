import * as api from './api.js'

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const baseUrl = 'http://localhost:3030';

const endpoint = {
    all: `${baseUrl}/data/catalog`,
    byId: (userId) => `${baseUrl}/data/catalog/${userId}`,
    ownedById: (userId) => `${baseUrl}/data/catalog?where=_ownerId%3D%22${userId}%22`,
} 

export async function getAllItems() {
    return api.get(endpoint.all);
}

export async function getItemById(id) {
    return api.get(endpoint.byId(id));
}

export async function getOwnedItemsById(id) {
    return api.get(endpoint.ownedById(id));
}

export async function createItem(data) {
    return api.post(endpoint.all, data);
}

export async function updateItemById(id, data) {
    return api.put(endpoint.byId(id), data);
}

export async function deleteItemById(id) {
    return api.del(endpoint.byId(id));
}