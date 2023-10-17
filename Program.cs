using FonctionsApp;
using SessionAdminApp;
using EnterpriseApp;
using UserSessionApp;
public class Program
{
    public static void Main(String[] args){
        int choix = 0;
        Entreprise entreprise = new Entreprise("Not defined", 2000);  
    
        switch (Fonction.Menu())
        {
            case 1:
                //SessionAdmin.EntrerInformationsEntreprise(ref entreprise);           
                SessionAdmin.Action(entreprise);
                break;
            case 2:
                Console.WriteLine("Bienvenue dans la session Utilisateur pour edition");
                SessionUtilisateur.CreerEmployes(entreprise);
                break;
            default:
                Console.WriteLine("Sortie du Programme ! !!");
                break;
        }

    }
}