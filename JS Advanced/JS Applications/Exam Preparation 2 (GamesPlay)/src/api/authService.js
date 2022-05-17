import * as api from './api.js'

const endpoints = {
    login: '/users/login',
    register: '/users/register',
    logout: '/users/logout',
}

export async function login(data) {
    const res = await api.post(endpoints.login, data);
    const user = JSON.stringify(res);

    saveUser(user);

    return user;
}

export async function register(data) {
    const res = await api.post(endpoints.register, data);
    const user = JSON.stringify(res);

    saveUser(user);
    
    return user;
}

export async function logout() {
    await api.get(endpoints.logout);
    removeUser();
}

function saveUser(user) {
    localStorage.setItem('user', user);
}


function removeUser() {
    localStorage.removeItem('user');
}