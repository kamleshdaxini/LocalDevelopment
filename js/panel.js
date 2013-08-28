
debugger;
function setpane() {
    var pane = document.getElementById('<%=Panel1.ClientID %>');
    if (pane) {
        pane.slideToggle("slow");
    }
        }