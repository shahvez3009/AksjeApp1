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
        "<th>Navn</th><th>Antall</th><th>Sum</th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.Navn + "</td>" +
            "<td>" + portfolio.Antall + "</td>" +
            "<td>" + portfolio.Sum + "</td> +
            "</tr>";
    }
    ut += "</table>";
    $("#portfolio").html(ut);
}

