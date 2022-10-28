$(function () {
    hentAllInfo();
});

let brukerSaldo;
let aksjeLedige;
let aksjePris;

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        aksjeLedige = aksje.antallLedige;
        aksjePris = aksje.pris;
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html("Aksjenavn - <b>" + aksje.navn + "</b>");
        $("#aksjePris").html("Pris per Aksje - <b>" + aksje.pris + "</b>");
        $("#aksjeLedigeMax").html("Aksjer Ledige/Max - <b>" + aksje.antallLedige + "</b>/<b>" + aksje.maxAntall + "</b>");
        $("#sumForKjop").html("Total sum for kjøp: " + aksje.pris * $("#antallAksjer").val());
    });
    $.get("Aksje/HentEnBruker", function (bruker) {
        brukerSaldo = bruker.saldo;
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: <b>" + bruker.saldo + "</b> NOK");
    });
}

function oppdater() {
    hentAllInfo();

    const feil = document.getElementById("feil");
    feil.innerHTML = "";
}

function bekreftKjop() {

    const feil = document.getElementById("feil");
    const antallAksjer = $("#antallAksjer").val()
    const aksjeLedigeMax = aksjeLedige;

    if (antallAksjer > aksjeLedigeMax) {
        feil.innerText = "Antallet ditt overskrider tilgjengelig beholdning";
    }

    if (aksjePris * antallAksjer > brukerSaldo) {
        feil.innerText = "Du har ikke råd til denne transaksjonen";
    }

    const portfolio = {
        antall: antallAksjer
    }

    const id = window.location.search.substring(1);

    $.post("Aksje/Kjop?" + id, (id, portfolio), function (id, portfolio) {
        if (id, portfolio) {
            $("#antallAksjer").val(null);
            hentAllInfo();
            console.log("Kjøpet ble gjennomført");
        }
        else {
            console.log("Error");
        }
    });
}