$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    $.get("Aksje/HentTransaksjoner", function (transaksjoner) {
        formaterTransaksjon(transaksjoner);   
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#transaksjonEier").html(bruker.fornavn + " " + bruker.etternavn + " - Transaksjoner");
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
    });
}

function formaterTransaksjon(transaksjoner) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Transaksjons type</th><th>Dato/Tid</th><th>Aksje</th><th>Pris Per Aksje</th><th>Antall Aksjer</th><th>Sum</th>" +
        "</tr>";
    for (let transaksjon of transaksjoner) {
        ut += "<tr>" +
            "<td>" + transaksjon.status + "</td>" +
            "<td>" + transaksjon.datoTid + "</td>" +
            "<td>" + transaksjon.aksjeNavn + "</td>" +
            "<td>" + transaksjon.aksjePris + "</td>" +
            "<td>" + transaksjon.antall + "</td>" +
            "<td>" + transaksjon.antall*transaksjon.aksjePris + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#transaksjon").html(ut);
}