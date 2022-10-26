$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    const aksjeid = window.location.search.substring(1);

    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje) {
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html("Aksjenavn - <b>" + aksje.navn + "</b>");
        $("#aksjePris").html("Pris per Aksje - <b>" + aksje.pris + "</b>");
        $("#aksjeLedigeMax").html("Aksjer Ledige/Max - <b>" + aksje.antallLedige + "</b>/<b>" + aksje.maxAntall + "</b>");
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
        $("#brukerSaldo").html("Saldo: <b>" + bruker.saldo + "</b> NOK");
    });
}

function bekreftKjop() {
    const portfolio = {
        antall: $("#antallAksjer").val()
    }
    const id = window.location.search.substring(1);

    $.post("Aksje/Kjop?" + id, (id, portfolio), function (id, portfolio) {
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