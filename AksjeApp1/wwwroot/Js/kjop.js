$(function () {
    hentAllInfo();

});

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);
    /*
    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id); // må ha med id inn skjemaet, hidden i html
        $("#aksjeNavn").val(aksje.navn);
        $("#aksjePris").val(aksje.pris);
        $("#aksjeMax").val(aksje.maxAntall);
        $("#aksjeLedige").val(aksje.antallLedige);
        console.log("Aksje - " + aksje.id + aksje.navn + aksje.pris + aksje.maxAntall + aksje.antallLedige);
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#brukerFornavn").val(bruker.fornavn);
        $("#brukerEtternavn").val(bruker.etternavn);
        $("#brukerSaldo").val(bruker.saldo);
        console.log("Bruker - " + bruker.id + bruker.fornavn + bruker.etternavn + bruker.saldo);
    });

    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").val(portfolio.antall);
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
        console.log("Portfolio - " + portfolio.id + portfolio.antall + portfolio.aksjeId + portfolio.aksjeNavn + portfolio.aksjePris + portfolio.brukerId);
    });
    */

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id); // må ha med id inn skjemaet, hidden i html
        $("#aksjeNavn").html(aksje.navn);
        $(".aksje_navn").html(aksje.navn);
        $("#aksjePris").html("Pris Pr Aksje" + ": " + aksje.pris);
        console.log("Aksje - " + aksje.id + aksje.navn + aksje.pris + aksje.maxAntall + aksje.antallLedige);
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#brukerFullNavn").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
        console.log("Bruker - " + bruker.id + bruker.fornavn + bruker.etternavn + bruker.saldo);
    });
    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html(portfolio.antall);
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
        console.log("Portfolio - " + portfolio.id + portfolio.antall + portfolio.aksjeId + portfolio.aksjeNavn + portfolio.aksjePris + portfolio.brukerId);
    });

}





function bekreftKjop() {
    const portfolio = {
        antall: $("#antallAksjer").val()
    }
    const id = window.location.search.substring(1);

    $.post("Aksje/Kjop?" + id, (id,portfolio), function (id, portfolio) {
        if (id,portfolio) {
            console.log("Det gikk bra kompis");
        }

        else {
            console.log("Du gjorde noe feil as");
        }
    });
}

/*
function kjopAksje() {
    const portfolio = {
        id: 5,
        navn: "microsoft",
        pris: 300,
        antall: 5,
        sum: 200,
        aksje: 1,
        bruker: 1,
    }
    console.log(portfolio.aksjeId, portfolio.pris, portfolio.antall, portfolio.navn, portfolio.bruker);

    $.post("Aksje/Kjop", portfolio, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
           
    }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}
*/

