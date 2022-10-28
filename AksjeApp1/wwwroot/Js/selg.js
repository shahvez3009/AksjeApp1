$(function () {
    hentAllInfo();
});

let aksjeAntall; 

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html("Aksjenavn - <b>" + aksje.navn + "</b>");
        $("#aksjePris").html("Pris per Aksje - <b>" + aksje.pris + "</b>");
        $("#sumForKjop").html("Total sum for salg: " + aksje.pris * $("#antallAksjer").val());
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: <b>" + bruker.saldo + "</b> NOK");
    });
    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        aksjeAntall = portfolio;
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html("Antall " + portfolio.aksjeNavn + " aksjer i portefølje - <b>" + portfolio.antall + "</b>");
    });
}

function oppdater() {
    hentAllInfo();

    const feil = document.getElementById("feil");
    feil.innerHTML = "";
}

function bekreftSalg() {

    const feil = document.getElementById("feil");
    const antallAksjer = $("#antallAksjer").val();
    const portfolioAntall = aksjeAntall.antall;

    if (antallAksjer > portfolioAntall) {
        feil.innerText = "Antallet ditt overskrider tilgjengelig beholdning";
    }

    const portfolio = {
        antall: $("#antallAksjer").val(),
    };

    const id = window.location.search.substring(1);

    $.post("Aksje/selg?" + id, (id, portfolio), function (id, portfolio) {
        if (id, portfolio) {
            $("#antallAksjer").val(null);
            hentAllInfo();
            console.log("Salget ble gjennomført!");
        }
        else {
            console.log("Error");
        }
    });
}
