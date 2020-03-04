var URL_PersonAPI = "https://localhost:44359/api/person"

async function getDataAsync(url)
{
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

function buildPersonList()
{
    getDataAsync(URL_PersonAPI).then(data => {
        data.forEach(element => {
            // Create highscoreitem
            var pRow = document.createElement("tr");
            pRow.className = "PItem"
            pRow.id = pRow.className + element.id;

            pRow.insertCell(0).innerHTML = (element.firstName + " " + element.lastName);
            pRow.insertCell(1).innerHTML = element.age;
            document.getElementById("personTable").appendChild(pRow);
        });
    });
}

function buildSite()
{
    buildPersonList()
}
