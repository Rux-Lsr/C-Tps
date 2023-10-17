using FonctionsApp;
using SessionAdminApp;
using EnterpriseApp;
public class Program
{
    public static void Main(String[] args){
        int choix = 0;
        Entreprise entreprise = new Entreprise("Not defined", 2000);  
    
        SessionAdmin.EntrerInformationsEntreprise(ref entreprise);           


        SessionAdmin.GetEnterpriseInformationAsString(entreprise);
        SessionAdmin.printPostesInformations(entreprise);
    }
}