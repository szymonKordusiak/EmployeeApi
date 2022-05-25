async function getEmployees() {
    const response = await fetch('https://localhost:7200/employees');
    const data = await response.json();
    console.log(data);
}

getEmployees();