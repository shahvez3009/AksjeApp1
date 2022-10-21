$(function () {
    hentHelePortfolio();
});

function hentHelePortfolio()
{
    $.get("Aksje/HentPortfolio", function (portfolios) {
        formaterPortfolio(portfolios);
    });
}

function formaterPortfolio(portfolios) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Stock name</th><th>Price per share</th><th>Amount of stocks</th><th>Sum</th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.navn + "</td>" +
            "<td>" + portfolio.pris + "</td>" +
            "<td>" + portfolio.antall + "</td>" +
            "<td>" + portfolio.sum + "</td> " +
            "</tr>";
    }
    ut += "</table>";
    $("#portfolio").html(ut);
}



