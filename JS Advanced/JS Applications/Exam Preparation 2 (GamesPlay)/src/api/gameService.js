import * as api from './api.js'

const endpoints = {
    getAll: '/data/games?sortBy=_createdOn%20desc',
    getAllRecent: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    create: '/data/games',
    getById: (id) => `/data/games/${id}`,    
    updateById: (id) => `/data/games/${id}`,
    deleteById: (id) => `/data/games/${id}`,
    // getByQuery: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`,
}

export async function getAllGames() {
    const res = await api.get(endpoints.getAll);

    return res;
}

export async function getRecentGames() {
    const res = await api.get(endpoints.getAllRecent);

    return res;
}

export async function getGameById(id) {
    const res = await api.get(endpoints.getById(id));

    return res;
}

export async function createGame(data) {
    const res = await api.post(endpoints.create, data);

    return res;
}

export async function updateGame(id, data) {
    const res = await api.put(endpoints.updateById(id), data);

    return res;
}

export async function deleteGame(id) {
    const res = await api.del(endpoints.deleteById(id));

    return res;
}