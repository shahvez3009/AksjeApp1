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
        "<th>Stock name</th><th>Price per share</th><th>Amount of stocks</th><th>Sum</th><th></th><th></th>" +
        "</tr>";
    for (let portfolio of portfolios) {
        ut += "<tr>" +
            "<td>" + portfolio.navn + "</td>" +
            "<td>" + portfolio.pris + "</td>" +
            "<td>" + portfolio.antall + "</td>" +
            "<td>" + portfolio.sum + "</td> " +
            "<td> <a class='btn btn-success'  href='kjop.html?id=" + portfolio.id + "'>Kjøp mer</a></td>" +
            "<td> <a class='btn btn-danger'  href='selg.html?id=" + portfolio.id + "'>Selg</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#portfolio").html(ut);
}



