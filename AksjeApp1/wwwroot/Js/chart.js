
const labels = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December"];

//Tenkte at vi kan lage forskjellige data objekter for hver aksje. Så Finner vi ut hvilken aksje som kom via knappen, og skriver den
//inn i config objectet.
 
//Microsoft
const data = {
    labels: labels,
    datasets: [
        {
            label: "stock",
            backgroundColor: "rgb(1, 29, 156)",
            borderColor: "rgb(1, 29, 156)",
            data: [100, 10, 5, 2, 25, 35, 45, 5, 10, 8, 10, 12],
        },
    ],
};

////Apple
//const Apple = {
//    labels: labels,
//    datasets: [
//        {
//            label: "Apple",
//            backgroundColor: "rgb(1, 29, 156)",
//            borderColor: "rgb(45, 45, 415)",
//            data: [100, 10, 5, 2, 25, 35, 45, 5, 10, 8, 10, 12],
//        },
//    ],
//};


//under: skal vi putte hvilken datasett vi vil bruke. (VI MÅ FINNE UT HVORDAN VI FÅR NAVNET TIL AKSJEN)


const config = {
    type: "line",
    data: data, 
    options: {},
};

const myChart = new Chart(document.querySelector(".dashboard"), config);





//$(function () {
//    // hent kunden med kunde-id fra url og vis denne i skjemaet

//    const id = window.location.search.substring(1);
//    const url = "Aksje/HentEn?" + id;
//    $.get(url, function (kunde) {
//        $("#id").val(aksje.id); // må ha med id inn skjemaet, hidden i html
//        $("#navn").val(aksje.navn);
//    });
//});



