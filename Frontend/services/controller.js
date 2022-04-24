function update() {
    //Récupération de tous les poids (par les sliders)
    hypotheses.set("Q13", +document.getElementById('Q13').value);
    hypotheses.set("Q14", +document.getElementById('Q14').value);
    hypotheses.set("Q15", +document.getElementById('Q15').value);

    hypotheses.set("Q21", +document.getElementById('Q21').value);
    hypotheses.set("Q22", +document.getElementById('Q22').value);
    hypotheses.set("Q23", +document.getElementById('Q23').value);

    hypotheses.set("Q31", +document.getElementById('Q31').value);
    hypotheses.set("Q32", +document.getElementById('Q32').value);
    hypotheses.set("Q34", +document.getElementById('Q34').value);

    hypotheses.set("Q41", +document.getElementById('Q41').value);
    hypotheses.set("Q43", +document.getElementById('Q43').value);

    hypotheses.set("Q51", +document.getElementById('Q51').value);
    hypotheses.set("Q52", +document.getElementById('Q52').value);

    hypotheses.set("Q61", +document.getElementById('Q61').value);
    hypotheses.set("Q62", +document.getElementById('Q62').value);

    hypotheses.set("Q81", +document.getElementById('Q81').value);
    hypotheses.set("Q82", +document.getElementById('Q82').value);

    hypotheses.set("Q91", +document.getElementById('Q91').value);
    hypotheses.set("Q92", +document.getElementById('Q92').value);
    hypotheses.set("Q93", +document.getElementById('Q93').value);

    hypotheses.set("Q101", +document.getElementById('Q101').value);
    hypotheses.set("Q103", +document.getElementById('Q103').value);

    hypotheses.set("Q121", +document.getElementById('Q121').value);
    hypotheses.set("Q122", +document.getElementById('Q122').value);

    hypotheses.set("Q141", +document.getElementById('Q141').value);
    hypotheses.set("Q142", +document.getElementById('Q142').value);

    hypotheses.set("Q171", +document.getElementById('Q171').value);
    hypotheses.set("Q172", +document.getElementById('Q172').value);

    var scores = getscoreEtu();
    var resultScores = refreshCharts(scores);
    renderProportion(resultScores.nbreIps, resultScores.nbreAstre, resultScores.nbreNeutre);
    renderDetail(resultScores.ArrayETU, resultScores.arrayIPS, resultScores.arrayASTRE);
}

function changeView(page) {
    switch (page) {
        case "Formulaire":
            document.getElementById("Formulaire").classList.add("active");
            document.getElementById("Proportions").classList.remove("active");
            document.getElementById("Details").classList.remove("active");

            document.getElementById("formControls").classList.remove("hidepage");
            document.getElementById("detailChart").classList.add("hidepage");
             document.getElementById("proportionChart").classList.add("hidepage");
            break;
        case "Proportions":
            document.getElementById("Proportions").classList.add("active");
            document.getElementById("Formulaire").classList.remove("active");
            document.getElementById("Details").classList.remove("active");

            document.getElementById("formControls").classList.add("hidepage");

            document.getElementById("detailChart").classList.add("hidepage");
            document.getElementById("proportionChart").classList.remove("hidepage");
            break;
        case "Details":
            document.getElementById("Details").classList.add("active");
            document.getElementById("Proportions").classList.remove("active");
            document.getElementById("Formulaire").classList.remove("active");

            document.getElementById("formControls").classList.add("hidepage");

            
            document.getElementById("detailChart").classList.remove("hidepage");
            document.getElementById("proportionChart").classList.add("hidepage");
            

            break;
        default:
    }
}
