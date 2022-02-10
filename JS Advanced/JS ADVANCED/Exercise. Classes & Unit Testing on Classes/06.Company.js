class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || salary < 0) {
            throw Error('Invalid input!')
        }

        let employee = {
            name,
            salary,
            position,
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {

        let bestDepartment = {
            name: '',
            averageSalary: -1 
        };

        for (const departmentName in this.departments) {
            let averageSalary = 0;

            for (const employee of this.departments[departmentName]) {
                averageSalary += employee.salary;
            }
            averageSalary /= this.departments[departmentName].length;

            if (averageSalary > bestDepartment.averageSalary) {
                bestDepartment.name = departmentName;
                bestDepartment.averageSalary = averageSalary;
            }
        }

        let result = `Best Department is: ${bestDepartment.name}`;
        result += `\nAverage salary: ${bestDepartment.averageSalary.toFixed(2)}`;
        this.departments[bestDepartment.name]
            .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
            .forEach(x => result += `\n${x.name} ${x.salary} ${x.position}`)
        
        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());