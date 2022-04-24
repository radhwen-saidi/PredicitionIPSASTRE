

namespace ProjetChoixIps
{
    using Newtonsoft.Json;

    public class Etudiant
    {
        [JsonProperty("numEtu")]
        public string Matricule { get; set; }

        [JsonProperty("beforeEnsim")]
        public string BeforeEnsim { get; set; }

        [JsonProperty("actTech")]
        public int ActTech { get; set; }

        [JsonProperty("tmpsArt")]
        public int TmpsArt { get; set; }

        [JsonProperty("creatif")]
        public int Creatif { get; set; }

        [JsonProperty("assosEtu")]
        public string AssosEtu { get; set; }

        [JsonProperty("soirEnsim")]
        public double SoirEnsim { get; set; }

        [JsonProperty("sitClasse")]
        public string SitClasse { get; set; }

        [JsonProperty("netflixAmazon")]
        public string NetflixAmazon { get; set; }

        [JsonIgnore]
        public string Animes { get; set; }

        [JsonProperty("systExpl")]
        public string SystExpl { get; set; }

        [JsonProperty("monterPc")]
        public string MonterPc { get; set; }

        [JsonProperty("nbEcran")]
        public string NbEcran { get; set; }

        [JsonProperty("cpuGraph")]
        public string CpuGraph { get; set; }

        [JsonProperty("rienBase")]
        public string RienBase { get; set; }

        [JsonProperty("equipe")]
        public int Equipe { get; set; }

        [JsonProperty("dirige")]
        public string Dirige { get; set; }

        [JsonProperty("colocation")]
        public string Colocation { get; set; }

        [JsonProperty("keyMouse")]
        public string KeyMouse { get; set; }
    }
}
