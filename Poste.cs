public class Poste
{
    public string NomPoste { get; set; }
    public double SalaireDeBase { get; set; }
    public double TauxAugmentation { get; set; }
    public double DiviseurSalaire { get; set; }

    // Constructeur
    public Poste(string nomPoste, double tauxAugmentation, double diviseurSalaire, double SalaireDeBase)
    {
        NomPoste = nomPoste;
        this.SalaireDeBase = SalaireDeBase;
        TauxAugmentation = tauxAugmentation;
        DiviseurSalaire = diviseurSalaire;
    }
}
