const labels = ["January", "February", "March", "April", "May", "June"];

const data = {
    labels: labels,
    datasets: [
        {
            label: "Stock",
            backgroundColor: "rgb(1, 29, 156)",
            borderColor: "rgb(1, 29, 156)",
            data: [0, 10, 5, 2, 20, 30, 45],
        },
    ],
};

const config = {
    type: "line",
    data: data,
    options: {},
};

const myChart = new Chart(document.querySelector(".dashboard"), config);
