using FonctionsApp;
using SessionAdminApp;
using EnterpriseApp;
using UserSessionApp;
public class Program
{
    public static void Main(String[] args){
        string choix;
        Entreprise entreprise = new Entreprise("Not defined", 2000);  
    
        do
        {
            switch (Fonction.Menu())
            {
                case 1:          
                    SessionAdmin.Action(entreprise);
                    break;
                case 2:
                    Console.WriteLine("Bienvenue dans la session Utilisateur");
                    SessionUtilisateur.Action(entreprise);
                    break;
                default:
                    Console.WriteLine("Sortie du Programme ! !!");
                    break;
            }
                Console.WriteLine("Tapez Q pour quitter le programme...  ");
                choix = Console.ReadLine() ;
        } while (choix.ToLower() != "q");

    }
}