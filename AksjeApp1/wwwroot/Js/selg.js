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



    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id); // må ha med id inn skjemaet, hidden i html 
        $("#aksjeNavn").html(aksje.navn);
        $(".aksje_navn").html(aksje.navn);
        $("#aksjePris").html("Pris : " + aksje.pris + " NOK");
        console.log(
            "Aksje - " +
            aksje.id +
            aksje.navn +
            aksje.pris +
            aksje.maxAntall +
            aksje.antallLedige
        );
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#brukerFullNavn").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
        console.log(
            "Bruker - " + bruker.id + bruker.fornavn + bruker.etternavn + bruker.saldo
        );
    });
    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html("Din beholdning er " + portfolio.antall + " aksjer");
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
        console.log(
            "Portfolio - " +
            portfolio.id +
            portfolio.antall +
            portfolio.aksjeId +
            portfolio.aksjeNavn +
            portfolio.aksjePris +
            portfolio.brukerId
        );
    });

}

function bekreftSalg() {
    const portfolio = {
        antall: $("#antall").val(),
    };

    const id = window.location.search.substring(1);

    $.post("Aksje/selg?" + id, (id, portfolio), function (id, portfolio) {
        if ((id, portfolio)) {

            const para = document.createElement("p");
            para.innerText = "Salget ditt er registrert";
            document.querySelector(".selg_bekreft_tekst").appendChild(para)

        } else {
            console.log("Du gjorde noe feil as");
        }
    });

}


