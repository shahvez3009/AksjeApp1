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