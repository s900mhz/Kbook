var yourAPIKey = 'AIzaSyBeXUW-Nknu_CqR2YSRfegh1OrDkUOmd98'
var BASE_URL = `https://www.googleapis.com/books/v1/volumes?key=AIzaSyBeXUW-Nknu_CqR2YSRfegh1OrDkUOmd98`
//https://www.codeproject.com/Articles/124541/Working-on-JSON-objects-in-jQuery-and-MVC
$(document).ready(function () {
    $("#Search").on("click", function (event) {
        $("#results").remove();
        let userBook = $("#book").val();
        getBookByTitle(userBook)
    });
});
//Calls the REST Api along with the search query to return an array of max 10 of books
function getBookByTitle(title) {
    let url = BASE_URL + "&q=" + title;
    $.getJSON(url,displayBooks);
};
//Displays the books and builds an adaptive list 
function displayBooks(data) {

    let htmlString = "<div id='results'>";
    
    $.each(data.items, function (i, item){
        htmlString += '<div class="col-xs-3">';
        // Build up the HTML using the data from the API
        if(typeof item.volumeInfo.imageLinks !== 'undefined'){
            htmlString += '<img src="' + item.volumeInfo.imageLinks.thumbnail + '" alt="' + item.id + '" title="' + item.id + '", class ="img-fluid"/><br/>';
        }
        if(typeof item.volumeInfo.averageRating !== 'undefined'){
            htmlString += `<div class="col-xs-3"> <img src="Star/${Math.round(item.volumeInfo.averageRating)}-star.png" class = "img-fluid" style="max-width: 10%"/> </div>`
        }  
        htmlString += '<strong class="small">Publish Date: ' + item.volumeInfo.publishedDate + '</strong></div>';
        htmlString += '<div class="col-xs-9"><h1>' + item.volumeInfo.title + '</h1>';
        $.each(item.volumeInfo.authors, function (i, author) {
            htmlString += '<p class="bg-info"><i>' + author + '</i></p>';
        });
        htmlString += '<p class="small">' + item.volumeInfo.description + '</p>';
        if(typeof item.searchInfo !== 'undefined'){
            htmlString += '<p class="well small">Extract: "' + item.searchInfo.textSnippet + '"<a href="' + item.accessInfo.webReaderLink + '" target="_blank"> Read more</a></p>';
        }
        
        htmlString += '</div>';
        
    });
    $("#booktitle").html(htmlString + "</div>")
}

