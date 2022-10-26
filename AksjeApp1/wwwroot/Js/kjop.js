$(function () {
    hentAllInfo();
});

let aksjeState;

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        aksjeState = aksje;
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html("Aksjenavn - <b>" + aksje.navn + "</b>");
        $("#aksjePris").html("Pris per Aksje - <b>" + aksje.pris + "</b>");
        $("#aksjeLedigeMax").html("Aksjer Ledige/Max - <b>" + aksje.antallLedige + "</b>/<b>" + aksje.maxAntall + "</b>");
        $("#sumForKjop").html("Total sum for kjøp: " + aksje.pris * $("#antallAksjer").val());
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: <b>" + bruker.saldo + "</b> NOK");
    });
}

function oppdaterSum() {
    hentAllInfo();
}

function fjernFeil() {
    const feil = document.getElementById("feil");
    feil.innerHTML = "";
}

function bekreftKjop() {

    const feil = document.getElementById("feil");
    const antallAksjer = $("#antallAksjer").val()
    const aksjeLedigeMax = aksjeState.antallLedige;

    if (antallAksjer > aksjeLedigeMax) {
        feil.innerText = "Antallet ditt overskrider tilgjengelig beholdning";
    }
    

    const portfolio = {
        antall: $("#antallAksjer").val()
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