let books = [];
getdata();

async function getdata()
{
    await fetch('http://localhost:48920/book')
        .then(x => x.json())
        .then(y =>
        {
            books = y;
            console.log(books);
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




//function create2() {
//    let title = document.getElementById('title').value;
//    let published = document.getElementById('published').value;
//    let genre = document.getElementById('genre').value;
//    let writer_Id = document.getElementById('writer_Id').value;
//    let person_Id = document.getElementById('person_Id').value;

//    fetch('http://localhost:48920/book',
//        {
//            method: 'POST',
//            headers: { 'Content-Type': 'application/json', },
//            body: JSON.stringify(
//                {
//                    title: title,
//                    published: published,
//                    genre: genre,
//                    writer_Id: writer_Id,
//                    person_Id: person_Id
//                }),
//        })
//        .then(response => response)
//        .then(data => {
//            console.log('Success:', data);
//            getData();
//        })
//        .catch((error) => { console.error('Error:', error); });
//}