import page from '../node_modules/page/page.mjs';

import { renderMiddleware } from './middlewares/renderMiddleware.js';
import { homeView } from './views/homeView.js';
import { gameView } from './views/gameView.js';
import { gameOverView } from './views/gameOverView.js';

page(renderMiddleware);

page('/', homeView);
page('/game', gameView);
page('/game/end', gameOverView);

page.start();