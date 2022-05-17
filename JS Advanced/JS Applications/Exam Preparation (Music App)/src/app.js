import page from '../node_modules/page/page.mjs';

import { renderMiddleware, navigationMiddleware } from './middlewares/renderMiddleware.js';
import { catalogView } from './views/catalogView.js';
import { createView } from './views/createView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import { searchView } from './views/searchView.js';

page(navigationMiddleware);
page(renderMiddleware);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView);
page('/catalog/details/:id/edit', editView)
page('/catalog/details/:id', detailsView);
page('/catalog', catalogView);
page('/create', createView);
page('/search', searchView);

page.start();