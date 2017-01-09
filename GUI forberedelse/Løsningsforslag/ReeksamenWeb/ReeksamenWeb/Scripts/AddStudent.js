function addStudent() {
    
    var container = document.getElementById("contId");

    //var div = document.createElement("div");
    //container.appendChild(div);

        var input = document.createElement("input");
        input.type = "text";
        input.placeholder = "Studienummer";
        input.class = "form-control";
    input.id = "stn"+container.childElementCount;

        var input1 = document.createElement("input");
        input1.type = "text";
        input1.placeholder = "Karakter";
        input1.class = "form-control";
        input.id = "grade" + container.childElementCount;
        container.appendChild(input);

        container.appendChild(input1);
        
       
    }
