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


function create()
{
    let title = document.getElementById('title').value;
    let published = document.getElementById('published').value;
    let genre = document.getElementById('genre').value;
    let writer_Id = document.getElementById('writer_Id').value;
    let person_Id = document.getElementById('person_Id').value;

    fetch('http://localhost:48920/book',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(
            {
                title: title,
                published: published,
                genre: genre,
                writer_Id: writer_Id,
                person_Id: person_Id
            }),
        })
        .then(response => response.json())
        .then(data => { console.log('Success:', data); })
        .catch((error) => {console.error('Error:', error); });

}