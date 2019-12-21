<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SudokuWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sudoku Web Application</title>
    <%--JQuery File--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <%--Bootstrap File--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="Resources/Scripts/Script.js"></script>
    <link href="Resources/Styles/Style.css" rel="stylesheet" />
</head>
<body>
    <br />
    <p class="text-center mr-0">Enter Input String (row-wise numeric string, 0 for null values):</p>
    <br />
    <a href="http://forum.enjoysudoku.com/patterns-game-results-t6291.html" target="_blank">Sample Input Strings</a>
    <br />
    <textarea id="SudoInput" class="mt-3 mb-3" style="width: 470px"></textarea>
    <br />
    <button class="btn" onclick="validate()">Populate</button>
    <div id="SudoGridInput" class="SudoGrid"></div>
    <form id="SudoForm" runat="server">
        <div>
            <input type="hidden" id="InputData" runat="server" name="InputData" />
            <input type="hidden" id="OutputData" runat="server" name="OutputData" />
            <input type="hidden" id="IsError" runat="server" name="IsError" />
            <asp:Button runat="server" ID="SudoFormSubmit" OnClick="SudoFormSubmit_Click" class="btn mb-3" Text="Solve It" />
        </div>
    </form>
    <div id="SudoGridOutput" class="SudoGrid"></div>
</body>
</html>
