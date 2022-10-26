$(function () {
    hentAllInfo();
});

function hentAllInfo() {
    $.get("Aksje/HentAksjene", function (aksjer) {
        formaterAksjer(aksjer);
    });

    $.get("Aksje/HentEnBruker", function (bruker) {
        $("#brukerId").val(bruker.id);
        $(".innloggetBruker").html(bruker.fornavn + " " + bruker.etternavn);
    });


}

function formaterAksjer(aksjer) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Aksje navn</th><th>Pris</th><th>Maks antall tilgjenglig</th><th>Tilgjengelig aksjer</th><th></th><th></th>" +
        "</tr>";

    for (let aksje of aksjer) {
        ut += "<tr>" +
            "<td>" + aksje.navn + "</td>" +
            "<td>" + aksje.pris + "</td>" +
            "<td>" + aksje.maxAntall + "</td>" +
            "<td>" + aksje.antallLedige + "</td>" +
            `<td> <a class='btn btn-secondary' onClick='endreChart(" ${aksje.navn}"," ${aksje.id}") '>Vis graf</a></td>` +
            "<td> <a class='btn btn-success'  href='kjop.html?id=" + aksje.id + "'>Kjøp</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#aksjer").html(ut);
}


function endreChart(navn, i) {

    $("#grafNavn").html("Graf av " + navn + " sin aksje");

    const labels = [
        "Januar",
        "Februar",
        "Mars",
        "April",
        "Mai",
        "Juni",
        "Juli",
        "August",
        "September",
        "Oktober",
        "November",
        "Desember"];
   
   
    const data = [
   {
        labels: labels,
        datasets: [
           {
                label: "Microsoft",
               // backgroundColor: "rgb(1,29,156)",
                borderColor: "rgb(0,255,0)",
                data: [90, 40, 15, 5, 25, 35, 25, 5, 15, 80, 10, 300]
            }
        ]
   },
    {
        labels: labels,
        datasets: [
            {
                label: "Apple",
               // backgroundColor: "rgb(1,29,156)",
                borderColor: "rgb(220,20,60)",
                data: [90, 100, 15, 5, 45, 35, 25, 5, 15, 80, 20, 500]
           }
       ]

    },   {
        labels: labels,
        datasets: [
            {
               label: "Blizzard",
               //backgroundColor: "rgb(1,29,156)",
               borderColor: "rgb(1,29,156)",
                data: [90, 100, 15, 5, 25, 35, 25, 25, 35, 80, 10, 150]
            }
        ]
    },
    {
        labels: labels,
       datasets: [
           {
               label: "Google",
               //backgroundColor: "rgb(1,29,156)",
                borderColor: "rgb(1,29,156)",
                data: [90, 90, 15, 5, 25, 35, 25, 15, 15, 80, 10, 12]
          }
        ]

    },
    {
        labels: labels,
       datasets: [
           {
               label: "Netflix",
             //backgroundColor: "rgb(1,29,156)",
               borderColor: "rgb(1,29,156)",
               data: [90, 100, 25, 5, 25, 35, 25, 5, 25, 80, 20, 12]
            }
        ]
    },
    ];
    
    const input = parseInt(i)


    const config = {
        type: "line",
        data: data[input - 1],
        options: {},
    };

    const myChart = new Chart(document.querySelector(".dashboard"), config);


}