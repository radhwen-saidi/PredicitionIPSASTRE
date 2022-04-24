function renderProportion(nbreIps, nbreAstre, nbreNeutre) {
    Highcharts.chart('container1', {

        chart: {
            type: 'item'
        },

        title: {
            text: 'Les proportions des etudiants'
        },

        subtitle: {
            text: 'Repartition des etudiants en se basant sur leurs scores'
        },

        legend: {
            labelFormat: '{name} <span style="opacity: 0.4">{y}</span>'
        },

        series: [{
            name: 'Representatives',
            keys: ['name', 'y', 'color', 'label'],
            data: [
                ['nombre des etudiants IPS', nbreIps, '#b50000', 'IPS'],
                ['nombre des etudiants ASTRE', nbreAstre, '#070082', 'ASTRE'],
                ['nombre des etudiants NEUTRE', nbreNeutre, '#969696', 'NEUTRE']
            ],
            dataLabels: {
                enabled: true,
                format: '{point.label}'
            },

            // Circular options
            center: ['50%', '88%'],
            size: '170%',
            startAngle: -100,
            endAngle: 100
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 600
                },
                chartOptions: {
                    series: [{
                        dataLabels: {
                            distance: -30
                        }
                    }]
                }
            }]
        }
    });

}