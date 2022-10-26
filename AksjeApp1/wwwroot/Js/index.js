$(function () {
    hentAlleAksjer();
});

function hentAlleAksjer() {
    $.get("Aksje/HentAksjene", function (aksjer) {
        formaterAksjer(aksjer);
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });
}

function formaterAksjer(aksjer) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Stock Name</th><th>Price</th><th>Max Amount</th><th>Available shares</th><th></th><th></th>" +
        "</tr>";

    for (let aksje of aksjer) {
        ut += "<tr>" +
            "<td>" + aksje.navn + "</td>" +
            "<td>" + aksje.pris + "</td>" +
            "<td>" + aksje.maxAntall + "</td>" +
            "<td>" + aksje.antallLedige + "</td>" +
            "<td> <a class='btn btn-secondary' " + aksje.id + "'>Show Chart</a></td>" +
            "<td> <a class='btn btn-success'  href='kjop.html?id=" + aksje.id + "'>Buy</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}