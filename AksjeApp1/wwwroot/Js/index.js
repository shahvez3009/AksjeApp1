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
        "<th>Stock Name</th><th>Price</th><th>Max Amount</th><th>Stocks Available</th><th></th><th></th>" +
        "</tr>";
    for (let aksje of aksjer) {
        ut += "<tr>" +
            "<td>" + aksje.navn + "</td>" +
            "<td>" + aksje.pris + "</td>" +
            "<td>" + aksje.maxAntall + "</td>" +
            "<td>" + aksje.antallLedige + "</td>" +
            "<td> <a class='btn btn-secondary' href='portfolio.html?id=" + aksje.id + "'>Show Chart</a></td>" +
            "<td> <a class='btn btn-success'  href='order.html?id=" + aksje.id + "'>Buy</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}






