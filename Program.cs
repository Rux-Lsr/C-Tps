using FonctionsApp;
using SessionAdminApp;
using EnterpriseApp;
using UserSessionApp;
public class Program
{
    public static void Main(String[] args){
        Entreprise entreprise = new Entreprise("Not defined", 2000);  
        Console.CursorVisible = false;
        do
        {
            switch (Fonction.Menu())
            {
                case 0:          
                    SessionAdmin.Action(entreprise);
                    break;
                case 1:
                    Console.WriteLine("Bienvenue dans la session Utilisateur");
                    SessionUtilisateur.Action(entreprise);
                    break;
                default:
                    break;     
            }
                Console.Clear();
                Console.WriteLine("Touche 'entrer' pour continuer et 'echap' pour Sortir de la session principale...");
                Console.CursorVisible = true;
                ConsoleKeyInfo touche = Console.ReadKey();

                if (touche.Key == ConsoleKey.Escape)
                    break;
        } while (true);
            Console.WriteLine("Fin du Programme !!!");
    }
}