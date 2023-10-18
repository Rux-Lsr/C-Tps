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
                    goto End;
                    break;
            }
                Console.WriteLine("Tapez Q pour quitter le programme...  ");
                choix = Console.ReadLine() ;
        } while (choix.ToUpper() != "q");
            Console.WriteLine("Fin du Programme ! !!");
            End:
                Console.WriteLine("Fin du Programme ! !!");

    }
}