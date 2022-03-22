import { html } from "../node_modules/lit-html/lit-html.js"

export const studentsTemplate = (students, text) => {
    return html`
        ${students.map(student => html`
            <tr class=${text && checkIfTextIsContained(student, text) ? 'select' : ''}>
                <td>${student.firstName} ${student.lastName}</td>
                <td>${student.email}</td>
                <td>${student.course}</td>
            </tr>`
        )}`;
}

function checkIfTextIsContained(student, text) {
    student.fullName = `${student.firstName} ${student.lastName}`;
    let contained =(Object.values(student).some(propValue => propValue.toLowerCase().includes(text.toLowerCase()))) 
    return contained;
}