using System;
using System.Globalization;
using Prämienrechner.ViewModel;

namespace Prämienrechner.Model
{
    public class Person : ViewModelBase
    {
        #region Eigenschaften

        private int personId;

        public int PersonId
        {
            get => personId;
            set => SetProperty(ref personId, value);
        }

        private string vorname;

        public string Vorname
        {
            get => vorname;
            set => SetProperty(ref vorname, value);
        }

        private string nachname;

        public string Nachname
        {
            get => nachname;
            set => SetProperty(ref nachname, value);
        }

        private string franchise;

        public string Franchise
        {
            get => franchise;
            set
            {
                SetProperty(ref franchise, value);
                Monatspraemie = GetMonatsPraemie(franchise, vModell).ToString(CultureInfo.InvariantCulture);
                Jahrespraemie = GetJahresPraemie(franchise, vModell).ToString(CultureInfo.InvariantCulture);
            } 
        }

        private string vModell;

        public string VModell
        {
            get => vModell;
            set
            {
                SetProperty(ref vModell, value);
                Monatspraemie = GetMonatsPraemie(franchise, vModell).ToString(CultureInfo.InvariantCulture);
                Jahrespraemie = GetJahresPraemie(franchise, vModell).ToString(CultureInfo.InvariantCulture);
            } 
        }


        private string monatspraemie;

        public string Monatspraemie
        {
            get => monatspraemie;
            set => SetProperty(ref monatspraemie, value);
        }

        private string jahrespraemie;

        public string Jahrespraemie
        {
            get => jahrespraemie;
            set => SetProperty(ref jahrespraemie, value);
        }

        #endregion

        #region Franchise Modell

        public Array FranchiseValue
        {
            get
            {
                string[] arr = {"300", "500", "1000", "1500", "2000", "2500"};
                return arr;
            }
        }

        #endregion

        #region Rechnung Monatsprämie

        public static double GetMonatsPraemie(string a, string b)
        {
            double praemie = 0;
            double rabatt;

            #region If statement Modell = Keine

            if (a == "300" && b == "Keine")
            {
                praemie = 302;
            }
            else if (a == "500" && b == "Keine")
            {
                praemie = 293;
            }
            else if (a == "1000" && b == "Keine")
            {
                praemie = 266;
            }
            else if (a == "1500" && b == "Keine")
            {
                praemie = 239;
            }
            else if (a == "2000" && b == "Keine")
            {
                praemie = 211;
            }
            else if (a == "2500" && b == "Keine")
            {
                praemie = 184;
            }

            #endregion

            #region If statement Modell = Hmo

            else if (a == "300" && b == "Hmo")
            {
                rabatt = 302 * 0.06;
                praemie = 302 - rabatt;
            }
            else if (a == "500" && b == "Hmo")
            {
                rabatt = 293 * 0.06;
                praemie = 293 - rabatt;
            }
            else if (a == "1000" && b == "Hmo")
            {
                rabatt = 266 * 0.06;
                praemie = 266 - rabatt;
            }
            else if (a == "1500" && b == "Hmo")
            {
                rabatt = 239 * 0.06;
                praemie = 239 - rabatt;
            }
            else if (a == "2000" && b == "Hmo")
            {
                rabatt = 211 * 0.06;
                praemie = 211 - rabatt;
            }
            else if (a == "2500" && b == "Hmo")
            {
                rabatt = 184 * 0.06;
                praemie = 184 - rabatt;
            }

            #endregion

            #region If statement Modell = Hausarzt

            else if (a == "300" && b == "Hausarzt")
            {
                rabatt = 302 * 0.12;
                praemie = 302 - rabatt;
            }
            else if (a == "500" && b == "Hausarzt")
            {
                rabatt = 293 * 0.12;
                praemie = 293 - rabatt;
            }
            else if (a == "1000" && b == "Hausarzt")
            {
                rabatt = 266 * 0.12;
                praemie = 266 - rabatt;
            }
            else if (a == "1500" && b == "Hausarzt")
            {
                rabatt = 239 * 0.12;
                praemie = 239 - rabatt;
            }
            else if (a == "2000" && b == "Hausarzt")
            {
                rabatt = 211 * 0.12;
                praemie = 211 - rabatt;
            }
            else if (a == "2500" && b == "Hausarzt")
            {
                rabatt = 184 * 0.12;
                praemie = 184 - rabatt;
            }

            #endregion

            #region If statement Modell = Telmed

            else if (a == "300" && b == "Telmed")
            {
                rabatt = 302 * 0.15;
                praemie = 302 - rabatt;
            }
            else if (a == "500" && b == "Telmed")
            {
                rabatt = 293 * 0.15;
                praemie = 293 - rabatt;
            }
            else if (a == "1000" && b == "Telmed")
            {
                rabatt = 266 * 0.15;
                praemie = 266 - rabatt;
            }
            else if (a == "1500" && b == "Telmed")
            {
                rabatt = 239 * 0.15;
                praemie = 239 - rabatt;
            }
            else if (a == "2000" && b == "Telmed")
            {
                rabatt = 211 * 0.15;
                praemie = 211 - rabatt;
            }
            else if (a == "2500" && b == "Telmed")
            {
                rabatt = 184 * 0.15;
                praemie = 184 - rabatt;
            }

            #endregion

            return praemie;
        }

        #endregion

        #region Rechnung Jahresprämie

        public static double GetJahresPraemie(string a, string b)
        {
            return GetMonatsPraemie(a, b) * 12;
        }

        #endregion
    }
}
