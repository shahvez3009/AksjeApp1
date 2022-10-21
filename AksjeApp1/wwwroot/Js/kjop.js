$(function () {
    // hent aksje med aksje-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    const url = "Aksje/HentEnAksje?" + id;
    $.get(url, function (aksje) {
        $("#id").val(aksje.id); // må ha med id inn skjemaet, hidden i html
        $("aksjeNavn").val(aksje.navn);
        $("aksjePris").val(aksje.pris);
        $("aksjeMax").val(aksje.maxAntall);
        $("aksjeLedige").val(aksje.antallLedige);
    });
});