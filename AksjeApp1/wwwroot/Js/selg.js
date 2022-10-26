$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html(aksje.navn);
        $(".aksje_navn").html(aksje.navn);
        $("#aksjePris").html(aksje.pris);
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });

    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html(portfolio.antall);
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
    });
}

function bekreftSalg() {
    const portfolio = {
        antall: $("#antall").val(),
    };

    const id = window.location.search.substring(1);

    $.post("Aksje/selg?" + id, (id, portfolio), function (id, portfolio) {
        if ((id, portfolio)) {
            console.log("Det gikk bra kompis");
        }
        else {
            console.log("Du gjorde noe feil as");
        }
    });
}
