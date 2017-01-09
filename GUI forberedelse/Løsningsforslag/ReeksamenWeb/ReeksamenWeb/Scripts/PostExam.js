class Exam {
    constructor(fag,termin, nr, grade) {
        this.Fag = fag;
        this.Termin = termin;
        this.StudieNummer = nr;
        this.Karakter = grade;
    }
}


function InsertExamAjax(exam) {


    $.ajax({
        type: "POST",
        url: 'Exam/Create',
        data: { objektString: exam }
      
    });
}

function InsertExam() {
    var childList = $('#contId').find('> input');
    
    for(var i = 0 ; i < childList.length; i+=2) {
        var plz = childList[i + 1].value;
       
        var exam = new Exam($('#fagId').val(), $('#termId').val(),childList[i].value ,childList[i + 1].value);
            
        
            InsertExamAjax(JSON.stringify(exam));
            }
            
            
        
    

}
