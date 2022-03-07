function loadRepos() {
	let inputElement = document.getElementById('username');
	let ulElement = document.getElementById('repos');

	fetch(`https://api.github.com/users/${inputElement.value}/repos`)
		.then(response => {
			if (response.status == 404) {
				throw new Error('Repo not found');
			}

			return response.json();
		})
		.then(data => {
			ulElement.innerHTML = '';

			Object.values(data)
				.forEach(repo => {
					let liElement = document.createElement('li');

					let aElement = document.createElement('a');
					aElement.textContent = repo.full_name;
					aElement.href = repo.html_url;
					liElement.appendChild(aElement);

					ulElement.append(liElement);
				});
		})
		.catch(() => {
			ulElement.innerHTML = '';

			let liElement = document.createElement('li');

			let aElement = document.createElement('a');
			aElement.textContent = '{repo.full_name}';
			aElement.href = 'repo.html_url';
			liElement.appendChild(aElement);

			ulElement.append(liElement);
		});


	// Async/await solution -> the function should have the keyword |async| added before execution

	// try {
	// 	const response = await fetch(`https://api.github.com/users/${inputElement.value}/repos`);

	// 	if (response.status == 404) {
	// 		throw new Error('User not found');
	// 	}

	// 	const data = await response.json();

	// 	ulElement.innerHTML = '';

	// 	data.forEach(r => {
	// 		const liElement = document.createElement('li');
	// 		const a = document.createElement('a');
	// 		a.setAttribute('href', r.html_url);
	// 		a.textContent = r.full_name;
	// 		liElement.appendChild(a);
	// 		ulElement.appendChild(liElement);
	// 	});
	// } catch (error) {
	// 	ulElement.innerHTML = '';
	// 	const liElement = document.createElement('li');
	// 	liElement.textContent = error;
	// 	ulElement.appendChild(liElement);
	// }
}


