document.getElementById("btnStoreNumbers").addEventListener("click", function () {
    var number = document.forms[0].numbers.value;
    var numbers = [];
    if (localStorage.hasOwnProperty("numbers")) {
        // Read an object/array using JSON
        numbers = JSON.parse(localStorage.numbers);
    }
    numbers.push(number);

    // Store an object/array using JSON
    localStorage.numbers = JSON.stringify(numbers);
});

document.getElementById("btnShowNumbers").addEventListener("click", function () {
    var numbers = [];
    var outputdiv = document.getElementById("output");
    outputdiv.innerHTML = "";

    if (!window.localStorage) {
        addParagraph(outputdiv, "Your browser does not support local storage.");
    }
    else {
        if (!localStorage.hasOwnProperty("numbers")) {
            addParagraph(outputdiv, "There is no data stored yet.");
        }
        else {
            // Read an object/array using JSON
            numbers = JSON.parse(localStorage.numbers);
            for (var i = 0; i < numbers.length; i++) {
                addParagraph(outputdiv, numbers[i] + " ");
            }
        }
    }
});

function addParagraph(node, txt) {
    var pnode = document.createElement("P");
    var txtnode = document.createTextNode(txt);
    pnode.appendChild(txtnode);
    node.appendChild(pnode);
}