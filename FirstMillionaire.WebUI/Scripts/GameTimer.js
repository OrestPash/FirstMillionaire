var d = 31;
var myVar = setInterval(function myTimer() {
    d--;
    if (d >= 0) {
        document.getElementById("demo").innerHTML = d;
    }
    else {
        document.getElementById("demo").innerHTML = "Time is out";
    }
}, 1000);

