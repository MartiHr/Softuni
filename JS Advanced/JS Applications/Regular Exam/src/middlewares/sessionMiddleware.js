import { getUserData } from "../util.js";

export const sessionMiddleware = (ctx, next) => {
    ctx.user = getUserData();

    next();
} 
