$(function (){
    hentAllInfo();
});

function hentAllInfo(){
    const aksjeid = window.location.search.substring(1);
   
    $.get("Aksje/HentEnAksje?" + aksjeid, function (aksje){
        $("#aksjeId").val(aksje.id);
        $("#aksjeNavn").html(aksje.navn);
        $(".aksje_navn").html(aksje.navn);
        $("#aksjePris").html("Pris Pr Aksje" + ": " + aksje.pris);
    });

    $.get("Aksje/HentEnBruker", function (bruker){
        $("#brukerId").val(bruker.id);
        $("#brukerSaldo").html("Saldo: " + bruker.saldo + " NOK");
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });

    $.get("Aksje/HentEtPortfolioRad?" + aksjeid, function (portfolio){
        $("#portfolioId").val(portfolio.id);
        $("#portfolioAntall").html(portfolio.antall);
        $("#portfolioAksjeId").val(portfolio.aksjeId);
        $("#portfolioAksjeNavn").val(portfolio.aksjeNavn);
        $("#portfolioAksjePris").val(portfolio.aksjePris);
        $("#portfolioBrukerId").val(portfolio.brukerId);
    });
}

function bekreftKjop()
{
    const portfolio ={
        antall: $("#antallAksjer").val()
    }
    const id = window.location.search.substring(1);

    $.post("Aksje/Kjop?" + id, (id, portfolio), function (id, portfolio){
        if (id, portfolio) {

            const bekreft_tekst = document.createElement("p");
            bekreft_tekst.innerText = "Kjøpet ditt er registrert";
            document.querySelector(".kjop_bekreft_tekst").appendChild(bekreft_tekst); 
           // console.log("Det gikk bra kompis");
        }

        else{
            console.log("Du gjorde noe feil as");
        }
    });
}


