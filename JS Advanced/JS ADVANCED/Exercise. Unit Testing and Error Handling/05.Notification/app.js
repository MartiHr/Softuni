function notify(message) {

    let notificationElement = document.getElementById('notification');
    notificationElement.textContent = message;
    notificationElement.style.display = 'block';

    notificationElement.addEventListener('click', (e) => {
        e.target.style.display = 'none';
    });
}