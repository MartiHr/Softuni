function extract(content) {

    let contextElement = document.getElementById('content');

    let pattern = /\(([^(]+)\)/g;
    let matches = contextElement.textContent.matchAll(pattern);
    
    let result = [];
    
    for (const match of matches) {
        result.push(match[1]);
    }

    return result.join('; ');
}