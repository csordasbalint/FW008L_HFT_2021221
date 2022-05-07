let books = [];
let connection = null;
getdata();
setupSignalR();

let autoBiographies = [];
let booksOfGeorges = [];
let top2ProductiveWriters = [];

function stat_getdata()
{
    autoBiographies_getdata();
    booksOfGeorges_getdata();
    top2ProductiveWriters_getdata();
}



async function autoBiographies_getdata()
{

    await fetch('http://localhost:48920/stat/autobiographiesbytitle')
        .then(x => x.json())
        .then(y => {
            autoBiographies = y;
            autoBiographies_display();
        });
}

function autoBiographies_display() {
    document.getElementById('elso').innerHTML = "";  //ide az idézőjelbe kell valami
    autoBiographies.forEach(t => {
        document.getElementById('').innerHTML += "<tr><td>"
            + t.key + "</td><td>" + t.value + "</td></tr>";
    })

}



async function booksOfGeorges_getdata() {

    await fetch('http://localhost:48920/stat/latestpublishedbooksbygeorges')
        .then(x => x.json())
        .then(y => {
            booksOfGeorges = y;
            booksOfGeorges_display();
        });
}

function booksOfGeorges_display() {
    document.getElementById('masodik').innerHTML = "";  //ide az idézőjelbe kell valami
    booksOfGeorges.forEach(t => {
        document.getElementById('').innerHTML += "<tr><td>"
            + t.key + "</td><td>" + t.value + "</td></tr>";
    })

}



async function top2ProductiveWriters_getdata()
{

    await fetch('http://localhost:48920/stat/top2productivewriters')
        .then(x => x.json())
        .then(y => {
            top2ProductiveWriters = y;
            top2ProductiveWriters_display();
        });
}

function top2ProductiveWriters_display() {
    document.getElementById('harmadik').innerHTML = "";  //ide az idézőjelbe kell valami
    top2ProductiveWriters.forEach(t => {
        document.getElementById('').innerHTML += "<tr><td>"
            + t.key + "</td><td>" + t.value + "</td></tr>";
    })

}



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

    connection.on("BookUpdated", (user, message) =>
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
            display()
        });
}

function display()
{
    document.getElementById('results').innerHTML = "";
    books.forEach(t =>
    {
        //document.getElementById('results').innerHTML +=
        //    "<tr><td>" + t.book_Id + "</td><td>" + t.title +
        //    "</td><td>" + t.published + "</td><td>" + t.genre +
        //    "</td><td>" + t.writer_Id + "</td><td>" + t.person_Id +
        //    "</td> <td>" + `<button tpye="button" onclick="remove(${t.book_Id})">Delete </button>` + "</td> </tr>";


        document.getElementById('results').innerHTML +=
            "<tr><td>" + t.book_Id + "</td><td>" + t.title +
            "</td><td>" + t.published + "</td><td>" + t.genre +
            "</td><td>" + t.writer_Id + "</td><td>" + t.person_Id +
            "</td> <td>" + `<button tpye="button" onclick="remove(${t.book_Id})">Delete </button>` +
            "</td> <td>"+ `<button tpye="button" onclick="update(${t.book_Id})">Update </button>` + "</td> </tr>";
    });
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


//function update()
//{
//    let book_title = document.getElementById('title').value;
//    let book_published = parseInt(document.getElementById('published').value);
//    let book_genre = document.getElementById('genre').value;
//    let book_writer_Id = parseInt(document.getElementById('writer_Id').value);
//    let book_person_Id = parseInt(document.getElementById('person_Id').value);
//    id kell vajon?
//    fetch('http://localhost:48920/book/' + id, here / dunno
//        {
//            method: 'PUT',
//            headers: { 'Content-Type': 'application/json', },
//            body: JSON.stringify(
//                {
//                    title: book_title,
//                    published: book_published,
//                    genre: book_genre,
//                    writer_Id: book_writer_Id,
//                    person_Id: book_person_Id,
//                    id = book_Id /*this line dunno*/
//                })
//        })
//        .then(response => response)
//        .then(data => {
//            console.log('Success:', data);
//            getdata();
//        })
//        .catch((error) => { console.error('Error:', error); });
//}


function create()
{
    let book_title = document.getElementById('title').value;
    let book_published = parseInt(document.getElementById('published').value);
    let book_genre = document.getElementById('genre').value;
    let book_writer_Id = parseInt(document.getElementById('writer_Id').value);
    let book_person_Id = parseInt(document.getElementById('person_Id').value);

    fetch('http://localhost:48920/book', /*dunno if i need a / at the end*/
        {
            method: 'POST', /*method must be post*/
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