import * as api from './api.js'

const endpoints = {
    getAll: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/albums',
    upade: '/data/albums',
    getById: (id) => `/data/albums/${id}`,
    updateById: (id) => `/data/albums/${id}`,
    deleteById: (id) => `/data/albums/${id}`,
    getByQuery: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`,
}


export async function getAllAlbumbs() {
    const res = await api.get(endpoints.getAll);

    return res;
}

export async function getAlbumById(albumId) {
    const res = await api.get(endpoints.getById(albumId));

    return res;
}

export async function createAlbum(data) {
    const res = await api.post(endpoints.create, data);
}

export async function updateAlbum(id, data) {
    const res = await api.put(endpoints.updateById(id), data);
}

export async function deleteAlbum(id) {
    const res = await api.del(endpoints.deleteById(id));
}

export async function getAlbumsByQuery(query) {
    const res = await api.get(endpoints.getByQuery(query));

    return res;
}