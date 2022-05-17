import page from '../node_modules/page/page.mjs';

import { navigationMiddleware, renderMiddleware } from './middlewares/renderMiddleware.js';
import { sessionMiddleware } from './middlewares/sessionMiddleware.js';
import { catalogView } from './views/catalogView.js';
import { createView } from './views/createView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { homeView } from './views/homeViews.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';


page(sessionMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView);
page('/catalog', catalogView);
page('/details/:id/edit', editView);
page('/details/:id', detailsView);
page('/create', createView);

page.start();