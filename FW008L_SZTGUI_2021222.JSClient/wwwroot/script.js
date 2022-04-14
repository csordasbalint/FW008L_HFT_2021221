let books = [];

fetch('http://localhost:48920/book')
    .then(x => x.json())
    .then(y =>
    {
        books = y;
        console.log(books);
        display()
    });


function display()
{
    books.forEach(t =>
    {
        document.getElementById('results').innerHTML +=
            "<tr><td>" + t.book_Id + "</td><td>" + t.title +
            "</td><td>" + t.published + "</td><td>" + t.genre +
            "</td><td>" + t.writer_Id + "</td><td>" + t.person_Id + "</td></tr>";
        console.log(t.title);
    });
}