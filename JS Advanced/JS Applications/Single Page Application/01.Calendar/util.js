const sections = document.querySelectorAll('section');

export function hideAll() {
    sections.forEach(x => x.style.display = 'none');
}