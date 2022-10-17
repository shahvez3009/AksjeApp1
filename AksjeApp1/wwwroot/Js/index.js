$(function () {
    console.log("1");
    hentAlleAksjer();
});

function hentAlleAksjer() {
    console.log("2");
    $.get("Aksje/HentAksjene", function (aksjer) {
        console.log("3");
        formaterAksjer(aksjer);
        console.log("4");
    });
}

function formaterAksjer(aksjer) {
    console.log("5");
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Pris</th><th>AntallLedige</th><th>MaxAntall</th>" +
        "</tr>";
    for (let aksje of aksjer) {
        console.log("6");
        ut += "<tr>" +
            "<td>" + aksje.navn + "</td>" +
            "<td>" + aksje.pris + "</td>" +
            "<td>" + aksje.maxAntall + "</td>" +
            "<td>" + aksje.antallLedige + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}