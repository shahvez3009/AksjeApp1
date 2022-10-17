$(function () {
    hentAlleAksjer();
});

function hentAlleAksjer() {
    $.get("Aksje/HentAksjene", function (aksjer) {
        formaterAksjer(aksjer);
    });
}

function formaterAksjer(aksjer) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Pris</th><th>AntallLedige</th><th>MaxAntall</th>" +
        "</tr>";
    for (let aksje of aksjer) {
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