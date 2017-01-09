$(document).ready(function () {
    $('#privacyLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#privacy').load(url);
    });


    $('#asTextLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#asTextResponse').load(url);
        //jQuery.get(url, null, function (data) {
        //    $('#asTextResponse').html = data;
        //});
    });

    $('#asXMLLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        //$('#asXMLResponse').load(url);

        // Without jQuery
        var request = new XMLHttpRequest();
        request.open("GET", "Fruits/AsXML", true);
        request.send(null);
        request.onreadystatechange = function () {
            if (request.readyState == 4)
                //alert(request.responseText);
                document.getElementById('asXMLResponse').textContent = request.responseText;
        };

    });

    $('#asJSONLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        //$('#asJsonResponse').load(url);
        $.get(url, null, function (data) {
            $('#asJsonResponse').append("Name: " + data[0].Name, "   Color: " + data[0].Color);
        });
    });
});