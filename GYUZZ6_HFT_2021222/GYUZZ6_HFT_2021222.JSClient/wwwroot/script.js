let cars = [];
let connection = null;

let caIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:18131/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        getdata();
    });

    connection.on("CarDeleted", (user, message) => {
        getdata();
    });

    connection.on("CarUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:18131/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            display();
        });
}

function display() {
    document.getElementById('resultArea').innerHTML = "";
    cars.forEach(c => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + c.id + "</td><td>"
            + c.model + "</td><td>"
            + c.brandId + "</td><td>"
            + c.basePrice + "</td><td>"
            + `<button type="button" onclick="remove(${c.id})">Delete</button>`
            + `<button type="button" onclick="showupdate(${c.id})">Update</button>`
            + "</td></tr>"
    });
}

function showupdate(id) {
    document.getElementById('carModeltoUpdate').value = cars.find(t => t['id'] == id)['model'];
    document.getElementById('carBrandIDtoUpdate').value = cars.find(t => t['id'] == id)['brandId'];
    document.getElementById('carBasePricetoUpdate').value = cars.find(t=> t['id'] == id)['basePrice'];
    document.getElementById('uformdiv').style.display = 'flex';
    caIdtoUpdate = id;
}

function update() {
    document.getElementById('uformdiv').style.display = 'none';
    let model = document.getElementById('carModeltoUpdate').value;
    let brandID = document.getElementById('carBrandIDtoUpdate').value;
    let basePrice = document.getElementById('carBasePricetoUpdate').value;
    fetch('http://localhost:18131/car', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                id: caIdtoUpdate,
                model: model,
                brandId: brandID,
                basePrice: basePrice,
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:18131/car/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let model = document.getElementById('carModel').value;
    let brandID = document.getElementById('carBrandID').value;
    let basePrice = document.getElementById('carBasePrice').value;
    fetch('http://localhost:18131/car', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                model: model,
                brandId: brandID,
                basePrice: basePrice,
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}