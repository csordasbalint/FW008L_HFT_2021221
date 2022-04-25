let books = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR()
{
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48920/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookCreated", (user, message) =>
    {
        getdata();
    });

    connection.on("BookDeleted", (user, message) =>
    {
        getdata();
    });

    connection.onclose(async () =>
    {
        await start();
    });
    start();
}


async function start()
{
    try
    {
        await connection.start();
        console.log("SignalR Connected.");
    }
    catch (err)
    {
        console.log(err);
        setTimeout(start, 5000);
    }
}


async function getdata()
{
    await fetch('http://localhost:48920/book')
        .then(x => x.json())
        .then(y =>
        {
            books = y;
            //console.log(books); not needed
            display()
        });
}


function display()
{
    document.getElementById('results').innerHTML = "";
    books.forEach(t =>
    {
        document.getElementById('results').innerHTML +=
            "<tr><td>" + t.book_Id + "</td><td>" + t.title +
            "</td><td>" + t.published + "</td><td>" + t.genre +
            "</td><td>" + t.writer_Id + "</td><td>" + t.person_Id +
            "</td> <td>" + `<button tpye="button" onclick="remove(${t.book_Id})">Delete </button>` +"</td> </tr>";
    });
}


function displayForNunCruds()
{
    
}


function remove(id)
{
    fetch('http://localhost:48920/book/' + id,
        {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: null
        })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function create()
{
    let book_title = document.getElementById('title').value;
    let book_published = parseInt(document.getElementById('published').value);
    let book_genre = document.getElementById('genre').value;
    let book_writer_Id = parseInt(document.getElementById('writer_Id').value);
    let book_person_Id = parseInt(document.getElementById('person_Id').value);

    fetch('http://localhost:48920/book',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(
                {
                    title: book_title,
                    published: book_published,
                    genre: book_genre,
                    writer_Id: book_writer_Id,
                    person_Id: book_person_Id
                })
        })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}