namespace FonctionsApp
{
    interface Fonction
    {
        public static bool TestOnName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Le champ est vide !!! -> ");
                return true;
            }else
            { 
                return false;
            }
        }
        
        
        public static bool TestOnSex(string sex){
            if (sex != "m" && sex != "f")
            {
                Console.WriteLine("Sexe non valide (m/f) : ");
                return true;
            }else{
                Console.WriteLine("ok");
                return false;
            }

        }

        public static bool InTheInterval(int MinYear, int MaxYear, int currentYear)
        {
            if(currentYear < MinYear)
            {
                Console.WriteLine($"Annee non valide min = {MinYear} : ");
                return false;
            }
            else if(currentYear > MaxYear)
            {
                Console.WriteLine($"Annee non valide max = {MaxYear} : ");
                return false;
            }else
            {
                Console.WriteLine("ok");
                return true;
            }
        }
        public static bool TestOnDate(string Date, ref int ValidYear){
            
            if (!DateTime.TryParseExact(Date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime R))
            {
                
                Console.WriteLine("date invalide : ");
                return true;
            }else
            {
                ValidYear = R.Year;
                return false;
            }
        }
        public static bool TestOnNumber(string Number, ref int number)
        {
            int R;
            if (!int.TryParse(Number, out R))
            {
                Console.WriteLine("Veuillez entrer un nombre valide: ");
                return true;
            }
            else
            {
                if (R <= 0)
                {
                    Console.WriteLine("entrez une valeur supperieure à 0: ");
                    return true;
                }
                number = R;
                return false;
            }
        }
        
        public static bool TestOnDecimalNumber(string Number, ref decimal number)
        {
            decimal R;
            if (!Decimal.TryParse(Number, out R))
            {
                Console.WriteLine("Veuillez entrer un nombre valide: ");
                return true;
            }
            else
            {
                if (R <= 0)
                {
                    Console.WriteLine("entrez une valeur supperieure à 0: ");
                    return true;
                }

                number = R;
                return false;
            }
        }
        public static bool TestOnDoubleNumber(string Number, ref double number)
        {
            double R;
            if (!Double.TryParse(Number, out R))
            {
                Console.WriteLine("Veuillez entrer un nombre valide: ");
                return true;
            }
            else
            {
                if (R <= 0)
                {
                    Console.WriteLine("entrez une valeur supperieure à 0: ");
                    return true;
                }
                number = R;
                return false;
            }
        }

        public static int Menu(){
            string msg = "MENU-General";
            int choix = 0;
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
            
            Console.WriteLine("1 - Session Administrateur\n2 - Session Utilisateur\n0 - Quitter");
            while (TestOnNumber(Console.ReadLine(), ref choix) || !Fonction.InTheInterval(0, 2, choix));

            return choix;
        }
    }
}