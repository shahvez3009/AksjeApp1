
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
            data: [100, 50, 25, 23, 46, 32, 45, 5, 11, 8, 77, 12],
        },
    ],
};


// Array of Objects -> Må gjøre noe sånn som data.label


//const data = [
//    {
//        labels: labels,
//        datasets: [
//            {
//                label: "Microsoft",
//                backgroundColor: "rgb(1,29,156)",
//                borderColor: "rgb(1,29,156)",
//                data: [90, 40, 15, 5, 25, 35, 25, 5, 15, 80, 10, 12]
//            }
//        ]
//    },
//    {
//        labels: labels,
//        datasets: [
//            {
//                label: "Apple",
//                backgroundColor: "rgb(1,29,156)",
//                borderColor: "rgb(1,29,156)",
//                data: [90, 100, 15, 5, 45, 35, 25, 5, 15, 80, 20, 12]
//            }
//        ]

//    },
//    {
//        labels: labels,
//        datasets: [
//            {
//                label: "Tesla",
//                backgroundColor: "rgb(1,29,156)",
//                borderColor: "rgb(1,29,156)",
//                data: [90, 100, 15, 5, 25, 35, 25, 25, 35, 80, 10, 12]
//            }
//        ]
//    },
//    {
//        labels: labels,
//        datasets: [
//            {
//                label: "Google",
//                backgroundColor: "rgb(1,29,156)",
//                borderColor: "rgb(1,29,156)",
//                data: [90, 90, 15, 5, 25, 35, 25, 15, 15, 80, 10, 12]
//            }
//        ]

//    },
//    {
//        labels: labels,
//        datasets: [
//            {
//                label: "Netflix",
//                backgroundColor: "rgb(1,29,156)",
//                borderColor: "rgb(1,29,156)",
//                data: [90, 100, 25, 5, 25, 35, 25, 5, 25, 80, 20, 12]
//            }
//        ]
//    },
//];



//  const microsoft = data.find((obj) => obj.label === "microsoft");




//chart.new(microsoft); 

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



