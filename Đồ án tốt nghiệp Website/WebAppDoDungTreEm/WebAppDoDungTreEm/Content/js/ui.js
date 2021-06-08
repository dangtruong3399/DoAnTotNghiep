

function incNumber() {
    var i = 0;
    if (i < 10) {
        i++;
    } else if (i = 10) {
        i = 0;
    }
    document.getElementById("display").innerHTML = i;
}

function decNumber() {
    var i = 0;
    if (i > 0) {
        --i;
    } else if (i = 0) {
        i = 10;
    }
    document.getElementById("display").innerHTML = i;
}