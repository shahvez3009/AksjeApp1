$(function () {
    hentHelePortfolio();
});

function hentHelePortfolio()
{
    $.get("Aksje/HentPortfolio", function (portfolio) {
        formaterPortfolio(portfolio);
    });
}

function formaterPortfolio(portfolio) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Pris per Aksje</th><th>Antall Aksjer</th><th>Sum</th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.navn + "</td>" +
            "<td>" + portfolio.pris + "</td>" +
            "<td>" + portfolio.antall + "</td>" +
            "<td>" + portfolio.sum + "</td> +
            "</tr>";
    }
    ut += "</table>";
    $("#portfolio").html(ut);
}

