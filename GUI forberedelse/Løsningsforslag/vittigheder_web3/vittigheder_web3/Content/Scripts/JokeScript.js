class Joke {
    constructor(jokeString, source, tags) {
        this.JokeString = jokeString;
        this.Source = source;
        this.Tags = tags;
    }

    //get Hullspeed() {
    //    return 1.34 * Math.sqrt(this.Length);
    //}

}

class Tag {
    constructor(tagString) {
        this.TagString = tagString;
    }
}

function getJokesBasedOnCategory(categorystring) {
    $.ajax({
            type: "GET",
            url: "Home/GetJokesBasedOnCategory",
            data: { category: categorystring }
        })
        .done(function(msg) {
            $("#jokeBox").val(JSON.stringify(msg));
        });
}
function SearchChanged() {
    getJokesBasedOnCategory($("#searchString").val());
}

function addJokeAjax(joke) {
    $.ajax({
        type: "POST",
        url: "Home/AddJoke",
        data: { objektString: joke }
    });
}

function AddJoke() {
    var objektTagArray = new Array();
    var tags = $("#Tag").val();
    var tagarray = tags.split(",");

    for (var i = 0; i < tagarray.length; i++) {
        objektTagArray.push(new Tag(tagarray[i]));
    }

    var joke = new Joke($("#JokeString").val(), $("#Source").val(), objektTagArray);

    addJokeAjax(JSON.stringify(joke));
}

function RemoveText() {
    $("#Added").text("");
}