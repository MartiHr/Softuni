import { logout } from "../api/authService.js"

export const logoutView = async (ctx) => {
    await logout();

    ctx.page.redirect('/');
}