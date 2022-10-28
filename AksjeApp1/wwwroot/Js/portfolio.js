﻿$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    $.get("Aksje/HentPortfolio", function (portfolios) {
        formaterPortfolio(portfolios);
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#portfolioEier").html(bruker.fornavn + " " + bruker.etternavn + " - Portfolio");
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
    });
}

function formaterPortfolio(portfolios) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Aksje navn</th><th>Pris Per Aksje</th><th>Beholdning</th><th>Sum</th><th></th><th></th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.aksjeNavn + "</td>" +
            "<td>" + portfolio.aksjePris + "</td>" +
            "<td>" + portfolio.antall + "</td>" +
            "<td>" + portfolio.antall * portfolio.aksjePris + "</td> " +
            "<td> <a class='btn btn-success'  href='kjop.html?id=" + portfolio.aksjeId + "'>Kjøp mer</a></td>" +
            "<td> <a class='btn btn-danger'  href='selg.html?id=" + portfolio.aksjeId + "'>Selg</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#portfolio").html(ut);
}