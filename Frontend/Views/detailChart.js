function renderDetail(etu, result_ips, result_astre) {

    var categories = etu;
    console.log("etu", etu);
    Highcharts.chart('container2', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Detail de prediction des etudiants'
        },
        subtitle: {
            text: ''
        },
        accessibility: {
            point: {
                valueDescriptionFormat: '{index}. Étudiant {xDescription}, {value}.'
            }
        },
        xAxis: [{
            categories: categories,
            reversed: false,
            labels: {
                step: 1
            },
        }, { // mirror axis on right side
            opposite: true,
            reversed: false,
            categories: categories,
            linkedTo: 0,
            labels: {
                step: 1
            },
        }],
        yAxis: {
            title: {
                text: null
            },
            labels: {
                formatter: function () {
                    return Math.abs(this.value);
                }
            },
            accessibility: {
                description: 'Percentage population',
                rangeDescription: 'Range: 0 to 5%'
            }
        },

        plotOptions: {
            series: {
                stacking: 'normal'
            }
        },

        tooltip: {
            formatter: function () {
                return '<b>' + this.series.name + ', Étudiant ' + this.point.category + '</b><br/>' +
                    'Score: ' + Highcharts.numberFormat(Math.abs(this.point.y), 1) + '';
            }
        },

        series: [{
            name: 'ASTRE',
            data: result_astre
        }, {
            name: 'IPS',
            data: result_ips
        }]
    });

}