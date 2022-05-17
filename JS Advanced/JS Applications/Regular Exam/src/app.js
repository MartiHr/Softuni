import page from '../node_modules/page/page.mjs';

import { navigationMiddleware, renderMiddleware } from './middlewares/renderMiddleware.js';
import { sessionMiddleware } from './middlewares/sessionMiddleware.js';
import { createView } from './views/createView.js';
import { dashboardView } from './views/dashboardView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';

page(sessionMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homeView);
page('/login', loginView);
page('/logout', logoutView);
page('/register', registerView);
page('/dashboard', dashboardView);
page('/create', createView);
page('/details/:id/edit', editView);
page('/details/:id', detailsView);

page.start();