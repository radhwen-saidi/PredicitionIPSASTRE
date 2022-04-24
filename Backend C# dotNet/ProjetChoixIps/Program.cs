using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetChoixIps
{
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    class Program
    {
        static void Main(string[] args)
        {
            // Read File 
            //TODO : put your json file path locally 
            string path = @"C:\Users\labie\Desktop\Nouveau dossier\ProjetChoixIps-2\PATH\DATASET.json";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine("Cannot read the file.");
                return;
            }

            //Import Json Data
            var jsonText = File.ReadAllText(path);
            var studentsList = JsonConvert.DeserializeObject<IList<Etudiant>>(jsonText);

            //Create new file structure
            var list = new List<JObject>();
            foreach (var student in studentsList)
            {
                list.Add(StudentPropertyModifier(student));
            }

            var data = JsonConvert.SerializeObject(list, Formatting.Indented);

            //write string to file
            File.WriteAllText(@"C:\Users\labie\Desktop\Nouveau dossier\ProjetChoixIps-2\PATH\newStudentsFile.json", data);
        }


        private static JObject StudentPropertyModifier(Etudiant student)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("numEtu", student.Matricule);

            var bonus = 0;
            // before ensim
            if (string.Equals(student.BeforeEnsim, "prepa integre", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q11", "0");
            }
            else if (!string.Equals(student.BeforeEnsim, "prepa integre", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q11", "0");
            }
            else if (string.Equals(student.BeforeEnsim, "prepa classique", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q12", "0");
            }
            else if (!string.Equals(student.BeforeEnsim, "prepa classique", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q12", "0");
            }
            else if (string.Equals(student.BeforeEnsim, "prepa bl", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q13", "4");
            }
            else if (!string.Equals(student.BeforeEnsim, "prepa bl", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q13", "0");
            }
            else if (string.Equals(student.BeforeEnsim, "Dut", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q14", "-4");
            }
            else if (!string.Equals(student.BeforeEnsim, "Dut", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q14", "0");
            }
            else if (string.Equals(student.BeforeEnsim, "BTS", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q15", "-2");
            }
            else if (!string.Equals(student.BeforeEnsim, "BTS", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q15", "0");
            }
            else if (string.Equals(student.BeforeEnsim, "License", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q16", "0");
            }
            else if (!string.Equals(student.BeforeEnsim, "License", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q16", "0");
            }



            //ACT tech
            if (student.ActTech == 4)
            {
                bonus += -2;
                jsonObject.Add("Q21", "-4");
            }
            else if (student.ActTech != 4)
            {
                bonus += 0;
                jsonObject.Add("Q21", "0");
            }
            else if (student.ActTech == 3)
            {
                jsonObject.Add("Q22", "-2");
            }
            else if (student.ActTech != 3)
            {
                jsonObject.Add("Q22", "0");
            }
            else if (student.ActTech == 2)
            {
                jsonObject.Add("Q23", "2");
            }
            else if (student.ActTech != 2)
            {
                jsonObject.Add("Q23", "0");
            }

            //Tmp art
            if (student.TmpsArt == 4)
            {
                bonus += 2;
                jsonObject.Add("Q31", "4");
            }
            else if (student.TmpsArt != 4)
            {
                bonus += 0;
                jsonObject.Add("Q31", "0");
            }
            if (student.TmpsArt == 3)
            {
                jsonObject.Add("Q32", "2");
            }
            else if (student.TmpsArt != 3)
            {
                jsonObject.Add("Q32", "0");
            }
             if (student.TmpsArt == 2)
            {
                jsonObject.Add("Q34", "-2");
            }
            else if (student.TmpsArt != 2)
            {
                jsonObject.Add("Q34", "0");
            }

            //Creatif
            if (student.Creatif == 4)
            {
                bonus += 2;
                jsonObject.Add("Q41", "3");
            }
            else if (student.Creatif != 4)
            {
                bonus += 0;
                jsonObject.Add("Q41", "0");
            }
            else if (student.Creatif == 3)
            {
                jsonObject.Add("Q42", "1.5");
            }
            else if (student.Creatif != 3)
            {
                jsonObject.Add("Q42", "0");
            }
            else if (student.Creatif == 2)
            {
                jsonObject.Add("Q43", "0");
            }
            else if (student.Creatif != 2)
            {
                jsonObject.Add("Q43", "0");
            }

            //Asso etudiant
            if (student.AssosEtu.Contains("EnsimElec") || student.AssosEtu.Contains("Enigma"))
            {
                bonus += -2;
                jsonObject.Add("Q51", "-5");
            }

            else if (!(student.AssosEtu.Contains("EnsimElec") && student.AssosEtu.Contains("Enigma")))
            {
                bonus += 0;
                jsonObject.Add("Q51", "0");
            }
            if (student.AssosEtu.Contains("Jensim") || student.AssosEtu.Contains("BDE") || student.AssosEtu.Contains("BDLC"))
            {
                bonus += 2;
                jsonObject.Add("Q52", "3");
            }
            else if (!(student.AssosEtu.Contains("Jensim") && student.AssosEtu.Contains("BDE") && student.AssosEtu.Contains("BDLC")))
            {
                bonus += 0;
                jsonObject.Add("Q52", "0");
            }


            //Soir Ensim
            if (student.SoirEnsim > 2)
            {
                jsonObject.Add("Q61", "2.5");
            }

            else if (student.SoirEnsim <= 2)
            {
                jsonObject.Add("Q61", "0");
            }

            // sit classe
            if (string.Equals(student.SitClasse, "plutot devant", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q71", "2");
            }
            else if (!string.Equals(student.SitClasse, "plutot devant", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q71", "0");
            }
            else if (string.Equals(student.SitClasse, "plutot milieu", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q72", "0");
            }
            else if (!string.Equals(student.SitClasse, "plutot milieu", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q72", "0");
            }
            else if (string.Equals(student.SitClasse, "plutot derriere", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q73", "-2");
            }
            else if (!string.Equals(student.SitClasse, "plutot derriere", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q73", "0");
            }

            // NetflixAmazon
            if (string.Equals(student.NetflixAmazon, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q81", "3");
            }
            else if (!string.Equals(student.NetflixAmazon, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q81", "0");
            }
            else if (string.Equals(student.NetflixAmazon, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q82", "-3");
            }
            else if (!string.Equals(student.NetflixAmazon, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q82", "0");
            }

            //winlinux
            if (string.Equals(student.SystExpl, "Windows", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q91", "3");
            }
            else if (!string.Equals(student.SystExpl, "Windows", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q91", "0");
            }
            else if (string.Equals(student.SystExpl, "Mac", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q92", "5");
            }
            else if (!string.Equals(student.SystExpl, "Mac", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 0;
                jsonObject.Add("Q92", "0");
            }
            else if (string.Equals(student.SystExpl, "Linux", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q93", "-5");
            }
            else if (!string.Equals(student.SystExpl, "Linux", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 0;
                jsonObject.Add("Q93", "0");
            }

            // MontPC
            if (string.Equals(student.MonterPc, "Plus d'une fois", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q101", "-5");
            }

            else if (!string.Equals(student.MonterPc, "Plus d'une fois", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 0;
                jsonObject.Add("Q101", "0");
            }

            else if (string.Equals(student.MonterPc, "jamais", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q102", "3");
            }
            else if (string.Equals(student.MonterPc, "jamais", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q102", "0");
            }
            else if (string.Equals(student.MonterPc, "1 fois pour tester", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q103", "-2");
            }
            else if (!string.Equals(student.MonterPc, "1 fois pour tester", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q103", "0");
            }


            //nbEcran
            if (string.Equals(student.NbEcran, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q111", "3");
            }
            else if (!string.Equals(student.NbEcran, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q111", "0");
            }
            else if (!string.Equals(student.NbEcran, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q112", "-3");
            }
            else if (!string.Equals(student.NbEcran, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q112", "0");
            }


            //cpuGraph
            if (string.Equals(student.CpuGraph, "Performances", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q121", "-4");
            }
            else if (!string.Equals(student.CpuGraph, "Performances", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q121", "0");
            }
            else if (string.Equals(student.CpuGraph, "Graphismes", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q122", "5");
            }
            else if (!string.Equals(student.CpuGraph, "Graphismes", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q122", "0");
            }

            //rien base
            if (string.Equals(student.RienBase, "A partir de rien", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q131", "3");
            }
            else if (!string.Equals(student.RienBase, "A partir de rien", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q131", "0");
            }

            else if (string.Equals(student.RienBase, "A partir d'une base", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q132", "-3");
            }

            else if (!string.Equals(student.RienBase, "A partir d'une base", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q132", "0");
            }

            //Equipe
            if (student.Equipe == 4)
            {
                bonus += 2;
                jsonObject.Add("Q141", "4");
            }
            else if (student.Equipe != 4)
            {
                bonus += -2;
                jsonObject.Add("Q141", "-4");
            }

            //Dirige
            if (string.Equals(student.Dirige, "Diriger", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q151", "3");
            }
            if (!string.Equals(student.Dirige, "Diriger", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q151", "0");
            }

            else if (string.Equals(student.Dirige, "etre dirige", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q152", "-3");
            }
            else if (!string.Equals(student.Dirige, "etre dirige", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q152", "0");
            }

            //Colocation
            if (string.Equals(student.Colocation, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q161", "1");
            }
            else if (!string.Equals(student.Colocation, "oui", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q161", "0");
            }
            if (string.Equals(student.Colocation, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q162", "-1");
            }
            else if (!string.Equals(student.Colocation, "non", StringComparison.InvariantCultureIgnoreCase))
            {
                jsonObject.Add("Q162", "0");
            }


            //Keymouse
            if (string.Equals(student.KeyMouse, "Clavier", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += -2;
                jsonObject.Add("Q171", "-5");
            }
            else if (!string.Equals(student.KeyMouse, "Clavier", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 0;
                jsonObject.Add("Q171", "0");
            }
            else if (string.Equals(student.KeyMouse, "Souris", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q172", "5");
            }
            else if (!string.Equals(student.KeyMouse, "Souris", StringComparison.InvariantCultureIgnoreCase))
            {
                bonus += 2;
                jsonObject.Add("Q172", "0");
            }

            jsonObject.Add("Bonus", bonus);
            return jsonObject;
        }
    }
}
