import { months } from "./months.js";
import { hideAll } from "./util.js";

const yearsSectionElement = document.getElementById('years');

hideAll();
yearsSectionElement.style.display = 'inline';

yearsSectionElement.addEventListener('click', (e) => {
    e.preventDefault();

    let year = -1;
    if (e.target.tagName == 'TD') {
        year = e.target.querySelector('div').textContent;
    } else if (e.target.tagName == 'DIV') {
        year = e.target.textContent;
    }

    if (year != -1) {
        ShowMonthsSection(year);
    }
});

function ShowMonthsSection(year) {
    hideAll();

    let wantedSection = document.querySelector(`section[class="monthCalendar"][id="year-${year}"]`);
    wantedSection.style.display = 'inline';

    wantedSection.addEventListener('click', (e) => {
        let month = '';
        if (e.target.tagName == 'TD') {
            month = e.target.querySelector('div').textContent;
        } else if (e.target.tagName == 'DIV') {
            month = e.target.textContent;
        }

        if (month) {
            ShowDaysSection(month, year);
        }
    })

}

function ShowDaysSection(month, year) {
    hideAll();

    let wantedSection = document.querySelector(`section[id="month-${year}-${months.indexOf(month)}"]`);
    wantedSection.style.display = 'inline';
}