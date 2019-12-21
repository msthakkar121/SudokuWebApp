var BlankOutput = '000000000000000000000000000000000000000000000000000000000000000000000000000000000';
$(document).ready(function () { 
    if ($('#IsError').val() == "true") {
        $('#SudoInput').val($('#InputData').val());
        buildInputTable($('#InputData').val());
        buildOutputTable(BlankOutput);
        alert('Solution not found !!!\nPlease change your input!');
    } else {
        if ($('#OutputData').val() != '') {
            // Display Output
            $('#SudoInput').val($('#InputData').val());
            buildOutputTable($('#OutputData').val());
            buildInputTable($('#InputData').val());
        }
        else {
            //Page loading or first time
            //set Hidden field value
            $('#InputData').val('000000000000495000506000104001802600000000000005709200204000805000687000080504030');
            $('#SudoInput').val($('#InputData').val());
            // Assumed that the initial input string is correct and need not be validated
            buildInputTable($('#InputData').val());
            buildOutputTable(BlankOutput);
        }
    }
});

//Validate Input before Populating in Grid
function validate() {
    var regex = /^[0-9]{81}$/;
    if (!$('#SudoInput').val().match(regex)) {
        alert('Please enter valid input !!!\nNumeric string of 81 digits with `0` for blank.');
    }
    else {
        //set Hidden field value
        $('#InputData').val($('#SudoInput').val());
        buildInputTable($('#SudoInput').val());
        buildOutputTable(BlankOutput);
    }
}

function buildInputTable(Data) {
    var griddiv = $('#SudoGridInput');
    griddiv.html("<table id='SudoGridInputTable' ></table>");

    var tbody = $('#SudoGridInputTable');

    for (var i = 0; i < 9; i++) {
        var row = document.createElement("tr");
        var strRow = "";
        for (var j = 0; j < 9; j++) {
            strRow += "<td><input type='text' class='noDrop sudoSquares' readonly/></td>"
        }
        row.innerHTML = strRow;
        tbody.append(row);
    }

    if (Data.length == 81) {
        var cells = $("#SudoGridInputTable input");
        for (var i = 0; i < 81; i++) {
            if (Data.charAt(i) != 0) {
                cells[i].value = Data.charAt(i);
            }
            else {
                cells[i].value = '';
            }
        }
    }
}

function buildOutputTable(OutputData) {
    var griddiv = $('#SudoGridOutput');
    griddiv.html("<table id='SudoGridOutputTable' ></table>");

    var tbody = $('#SudoGridOutputTable');

    for (var i = 0; i < 9; i++) {
        var row = document.createElement("tr");
        var strRow = "";
        for (var j = 0; j < 9; j++) {
            strRow += "<td><input type='text' class='noDrop sudoSquares' readonly/></td>"
        }
        row.innerHTML = strRow;
        tbody.append(row);
    }

    if (OutputData.length == 81) {
        var cells = $("#SudoGridOutputTable input");
        for (var i = 0; i < 81; i++) {
            if (OutputData.charAt(i) != 0) {
                cells[i].value = OutputData.charAt(i);
            }
            else {
                cells[i].value = '';
            }
        }
    }
}