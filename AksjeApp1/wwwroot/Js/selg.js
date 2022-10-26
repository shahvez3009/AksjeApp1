$(function () {
    hentAllInfo();
});

let aksjeState; 

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html("Aksjenavn - <b>" + aksje.navn + "</b>");
        $("#aksjePris").html("Pris per Aksje - <b>" + aksje.pris + "</b>");
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: <b>" + bruker.saldo + "</b> NOK");
    });

    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio) {
        aksjeState = portfolio; 
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html("Antall " + portfolio.aksjeNavn + " aksjer i portefølje - <b>" + portfolio.antall + "</b>");
    });
}


function fjernFeil() {
    const feil = document.getElementById("feil"); 
    feil.innerHTML = "";
}

function bekreftSalg() {

    const feil = document.getElementById("feil");
    const antallAksjer = $("#antallAksjer").val();
    const portfolioAntall = aksjeState.antall;


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
            console.log("Det gikk bra kompis. Jeg er i JS");
        }
        else {
            console.log("Du gjorde noe feil as. Jeg er i JS");
        }
    });
}
