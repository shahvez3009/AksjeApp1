$(function () {
    // hent aksje med aksje-id fra url og vis denne i skjemaet

    const aksjeid = window.location.search.substring(1);
    const brukerid = 1;
    const urlAksje = "Aksje/HentEnAksje?" + aksjeid;
    const urlBruker = "Aksje/HentEnBruker?" + brukerid;

    $.get(urlAksje, function (aksje) {
        $("#aksjeId").val(aksje.aksjeid); // må ha med id inn skjemaet, hidden i html
        $("#aksjeNavn").val(aksje.navn);
        $("#aksjePris").val(aksje.pris);
        $("#aksjeMax").val(aksje.maxAntall);
        $("#aksjeLedige").val(aksje.antallLedige);
    });

    $.get(urlBruker, function (bruker) {
        $("#brukerId").val(bruker.brukerid);
        $("#brukerFornavn").val(bruker.fornavn);
        $("#brukerEtternavn").val(bruker.etternavn);
        $("#brukerSaldo").val(bruker.saldo);
    });

});