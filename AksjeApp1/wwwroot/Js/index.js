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
        "<th>Navn</th><th>Pris</th><th>Max Antall</th><th>Antall Ledige</th><th></th><th></th>" +
        "</tr>";
    for (let aksje of aksjer) {
        ut += "<tr>" +
            "<td>" + aksje.navn + "</td>" +
            "<td>" + aksje.pris + "</td>" +
            "<td>" + aksje.maxAntall + "</td>" +
            "<td>" + aksje.antallLedige + "</td>" +
            "<td> <a class='btn btn-secondary' href='portfolio.html?id=" + aksje.id + "'>Vis Graf</a></td>" +
            "<td> <a class='btn btn-success'  href='portfolio.html?id=" + aksje.id + "'>Kjøp</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}






