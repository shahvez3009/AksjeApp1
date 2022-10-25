$(function () {
    hentHelePortfolio();
});

function hentHelePortfolio() {
    $.get("Aksje/HentPortfolio", function (portfolios) {
        formaterPortfolio(portfolios);
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $("#portfolioEier").html(bruker.fornavn + " " + bruker.etternavn + " - Portfolio");
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });
}

function formaterPortfolio(portfolios) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Stock name</th><th>Price per share</th><th>Amount of stocks</th><th>Sum</th><th></th><th></th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.aksjeNavn + "</td>" +
            "<td>" + portfolio.aksjePris + "</td>" +
            "<td>" + portfolio.antall + "</td>" +
            "<td>" + portfolio.antall * portfolio.aksjePris + "</td> " +
            "<td> <a class='btn btn-success'  href='kjop.html?id=" + portfolio.aksjeId + "'>Kjøp mer</a></td>" +
            "<td> <a class='btn btn-danger'  href='selg.html?id=" + portfolio.aksjeId + "'>Selg</a></td>" +
            "</tr>";
    }

    ut += "</table>";
    $("#portfolio").html(ut);

}


