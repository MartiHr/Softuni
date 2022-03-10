const homeSectionElement = document.getElementById('home-page');
const homeMoviesSectionElement = document.getElementById('movie');

export function showHome() {
    homeSectionElement.style.display = 'block';
    homeMoviesSectionElement.style.display  = 'block';
}