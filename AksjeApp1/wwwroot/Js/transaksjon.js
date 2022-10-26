﻿$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    $.get("Aksje/HentTransaksjon", function (transaksjoner) {
        formaterTransaksjon(transaksjoner);
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#transaksjonEier").html(bruker.fornavn + " " + bruker.etternavn + " - Transaksjons Historikk");
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });
}

function formaterTransaksjon(transaksjoner) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Transaksjons type</th><th>Dato/Tid</th><th>Aksje</th><th>Pris Per Aksje</th><th>Antall Aksjer</th>><th>Sum</th>" +
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