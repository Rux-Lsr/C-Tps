using AppSalaire;
namespace App
{
   
    public class Program
    {
       public static bool TestOnName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Vous n'avez point entré de nom !!! -> ");
                return true;
            }else
            {
                Console.WriteLine("ok");    
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
                Console.WriteLine("ok");
                ValidYear = R.Year;
                return false;
            }
        }
        public static bool TestOnNumber(string Number, ref int number)
        {
            int R;
            if (!int.TryParse(Number, out R))
            {
                Console.WriteLine("Veuillez entrer un nombre  : ");
                return true;
            }
            else
            {
                if (R == 0)
                {
                    Console.WriteLine("entrez une valeur supperieure à 0: ");
                    return true;
                }
                Console.WriteLine("ok");
                number = R;
                return false;
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine($"**********************************LONTSI SONWA RUSSEL - 22V2254 - {DateTime.Now}**********************************");
            Console.WriteLine("Entrez l'annee de creation de l'entreprise");
            int CreationDate = 0;
            while (TestOnNumber(Console.ReadLine(), ref CreationDate) || CreationDate > DateTime.Now.Year){
                if( CreationDate > DateTime.Now.Year)
                Console.WriteLine("Entrez une annee inferieure à celle actuelle");
            }
             
            Console.Write("Quel Nombre d'employés voulez vous ? \n>");
            int EmployeeNumber = 0;
            while (TestOnNumber(Console.ReadLine(), ref EmployeeNumber)) ;
            List<Salaire>Employees = new List<Salaire>();

            Console.WriteLine($"\"*******************Creation de {EmployeeNumber} Employé(s) Date de creation entreprise = {CreationDate}*******************");
            for (int i = 0; i < EmployeeNumber; i++)
            {
                string nom, sexe, date;
                int poste, ValidYear = 0;
                Console.WriteLine($"*********Salaire N° {i + 1}*********");

                      Console.Write("Entrez le nom\n>");
                  while (TestOnName(nom = Console.ReadLine()));

                 
                      Console.Write("Entrez le sexe\n>");  
                  while (TestOnSex(sexe = Console.ReadLine()));

                
                    Console.Write("Entrez la date de recrutement (Format: jj/mm/aaaa) : \n>");
                  while (TestOnDate(date = Console.ReadLine(), ref ValidYear) || !InTheInterval(CreationDate, DateTime.Now.Year, ValidYear)) ;


                do
                {
                        Console.Write("Entrez le poste: 0 - Comptable, 1 - Secretaire, 2 - Informatitien\n>");
                        
                    } while (!int.TryParse(Console.ReadLine(), out poste) || (poste > 2 || poste < 0));

                Employees.Add(new Salaire(nom, sexe, date, poste));
            }
            Console.WriteLine($"\"*******************Affichage des informations de employés ({EmployeeNumber} employé(s))*******************");
            foreach (var item in Employees)
            {
                item.CalculSalaire();
                Console.WriteLine(item.ToString());
            }
        }
    }
}