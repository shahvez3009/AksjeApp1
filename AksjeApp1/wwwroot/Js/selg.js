$(function () {
    // hent aksje med aksje-id fra url og vis denne i skjemaet

    const aksjeid = window.location.search.substring(1);

    const urlAksje = "Aksje/HentEnAksje?" + aksjeid;
    const urlBruker = "Aksje/HentEnBruker";
    const urlPortfolio = "Aksje/HentEtPortfolioRad?" + aksjeid;

    $.get(urlAksje, function (aksje) {
        $("#aksjeId").val(aksje.id); // må ha med id inn skjemaet, hidden i html
        $("#aksjeNavn").val(aksje.navn);
        $("#aksjePris").val(aksje.pris);
        $("#aksjeMax").val(aksje.maxAntall);
        $("#aksjeLedige").val(aksje.antallLedige);
        console.log("Aksje - " + aksje.id + aksje.navn + aksje.pris + aksje.maxAntall + aksje.antallLedige);
    });

    $.get(urlBruker, function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#brukerFornavn").val(bruker.fornavn);
        $("#brukerEtternavn").val(bruker.etternavn);
        $("#brukerSaldo").val(bruker.saldo);
        console.log("Bruker - " + bruker.id + bruker.fornavn + bruker.etternavn + bruker.saldo);
    });

    $.get(urlPortfolio, function (portfolio) {
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").val(portfolio.antall);
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
        console.log("Portfolio - " + portfolio.id + portfolio.antall + portfolio.aksjeId + portfolio.aksjeNavn + portfolio.aksjePris + portfolio.brukerId);
    });

});
