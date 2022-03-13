const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

const accordionUrl = 'http://127.0.0.1:5500/01.%20Accordion/';

describe('Tests', async function () {
    this.timeout(6000);

    let browser, page;

    before(async () => {
        browser = await chromium.launch();
        //  Run in headless mode
        // { headless: false, slowMo: 1000 }
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        page.close();
    });

    it('Loads articles', async () => {
        await page.goto(accordionUrl)

        let articles = await page.$$eval('span', articles => articles.map(a => a.textContent));

        assert.equal(articles[0], 'Scalable Vector Graphics');
        assert.equal(articles[1], 'Open standard');
        assert.equal(articles[2], 'Unix');
        assert.equal(articles[3], 'ALGOL');
    });

    it('Buttons can toggle to more details', async () => {
        await page.goto(accordionUrl)

        await page.click('text=MORE');

        // Check for button text content
        const buttonText = await page.textContent('text=LESS');
        assert.equal(buttonText, 'Less');

        // Check if details are present
        const isDetailsContentVisible = await page.isVisible('p');
        assert.equal(true, isDetailsContentVisible);
    });

    it('Buttons can toggle to less details', async () => {
        await page.goto(accordionUrl)

        await page.click('text=MORE');
        await page.click('text=LESS');

        // Check for button text content
        const buttonText = await page.textContent('text=MORE');
        assert.equal(buttonText, 'More');

        // Check if details are present
        const isDetailsContentVisible = await page.isVisible('p');
        assert.equal(false, isDetailsContentVisible);
    })
});