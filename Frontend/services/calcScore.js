
function refresh() {
    let scores = getscoreEtu();
    refreshCharts(scores);
}



function convertToMap(dataetu) {
    var map = new Map();
    dataetu.forEach(function (etudiant) {
        let key = etudiant["numEtu"];
        map.set(key, etudiant);
    });
    return map;
}


//set scores pour tous les �tudiants
function getscoreEtu() {
    let mapEtu = convertToMap(etudata);
    var MapScores = new Map();
    var etudiants = mapEtu.keys();
    for (var i of etudiants) {
        let score = scoreEtu(mapEtu.get(i));
        MapScores.set(i, score);
    }
    console.log("map etu", MapScores);
    return MapScores;
}

function getListEtu() {
    let mapEtu = convertToMap(etudata);
    var etudiants = mapEtu.keys();
    return etudiants;
}

function scoreEtu(ach) {
    var result = 0;

    var questions = hypotheses.keys();
    for (var j of questions) {
        if (ach[j] != undefined) {
            result += ach[j] * hypotheses.get(j);
        }
    }
    result += ach['Bonus'];

    return result;
}


function refreshCharts(scores) {
    var nbreAstre = 0;
    var nbreIps = 0;
    var nbreNeutre = 0;
    var ArrayETU = [];
    var arrayIPS = [];
    var arrayASTRE = [];
    console.log("size", scores);
    var etu = scores.keys();
    for (var i of etu) {
        var sc = scores.get(i);
        if ((sc >= -50) && (sc <= -20)) {
            nbreNeutre += 1;
        }
        else if (sc > -20) {
            nbreIps += 1;
            ArrayETU.push(i);
            arrayIPS.push(sc);
            arrayASTRE.push(0);
        }
        else if (sc < -50){
            nbreAstre += 1;
            ArrayETU.push(i);
            arrayIPS.push(0);
            arrayASTRE.push(sc);
        }
    }
    console.log("ips", nbreIps);
    var result = {
        "nbreIps": nbreIps,
        "nbreAstre": nbreAstre,
        "nbreNeutre": nbreNeutre,
        "ArrayETU": ArrayETU,
        "arrayIPS": arrayIPS,
        "arrayASTRE": arrayASTRE
    }
    
    window.onload = function () {
        renderProportion(nbreIps, nbreAstre, nbreNeutre);
        let etu = getListEtu();
        renderDetail(ArrayETU, arrayIPS, arrayASTRE);
    }
    return result;
}

refresh();