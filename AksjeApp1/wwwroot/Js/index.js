$(function () {
    hentAlleAksjer();
});

function hentAlleAksjer() {
    $.get("Aksje/HentAksjer", function (aksjer) {
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
            "<td>" + aksje.Navn + "</td>" +
            "<td>" + aksje.Pris + "</td>" +
            "<td>" + aksje.MaxAntall + "</td>" +
            "<td>" + aksje.AntallLedige + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}