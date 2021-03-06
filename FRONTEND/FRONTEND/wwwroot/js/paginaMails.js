var a = document.getElementById("mailMenu");
var b = document.getElementById("newMailButtons");
var x = document.getElementById("hijoPrincipal");
var y = document.getElementById("hijoCorreoNuevo");
var rec = document.getElementById("recibidos");
var cN = document.getElementById("correoNuevo");

function MostrarMail() {
    if (y.style.display === "none") {
        y.style.display = "flex";
        x.style.display = "none";
        a.style.display = "none";
        b.style.display = "flex";
    }
}
function MostrarRecibidos() {
    if (x.style.display === "none") {
        x.style.display = "flex";
        y.style.display = "none";
        b.style.display = "none";
        a.style.display = "flex";
    }
}

