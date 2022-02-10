function requestValidator(requestObject) {

    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriPattern = /^[a-zA-Z0-9.]+$/gm;
    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messageAntiPattern = /[<>\\&'"]+/gm;

    if (!validMethods.includes(requestObject.method) || requestObject.method == undefined) {
        throw Error('Invalid request header: Invalid Method');
    }

    if (requestObject.uri != '*' && !uriPattern.test(requestObject.uri) || requestObject.uri == undefined) {
        throw Error('Invalid request header: Invalid URI');
    }

    if (!validVersions.includes(requestObject.version) || requestObject.version == undefined) {
        throw Error('Invalid request header: Invalid Version');
    }

    if (messageAntiPattern.test(requestObject.message) || requestObject.message == undefined) {
        throw Error('Invalid request header: Invalid Message');
    }

    return requestObject;
}

// let obj = result({
//     method: 'GET',
//     uri: 'svn.public.catalog',
//     version: 'HTTP/1.1',
//     message: ''
// });


// console.log(requestValidator({
//     method: 'POST',
//     version: 'HTTP/2.0',
//     message: 'rm -rf /*'
// }));