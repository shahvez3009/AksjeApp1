$(function () {
    hentHelePortfolio();
});

function hentHelePortfolio()
{
    $.get("aksje/hentPortfolio", function (portfolio) {
        formaterPortfolio(portfolio);
    });
}

/*function formaterPortfolio(portfolio)
{
   
}
*/
