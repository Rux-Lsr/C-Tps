public class Poste
{
    public string NomPoste { get; set; }
    public decimal SalaireDeBase { get; set; }
    public decimal TauxAugmentation { get; set; }
    public decimal DiviseurSalaire { get; set; }

    // Constructeur
    public Poste(string nomPoste, decimal tauxAugmentation, decimal diviseurSalaire)
    {
        NomPoste = nomPoste;
        SalaireDeBase = 100000;
        TauxAugmentation = tauxAugmentation;
        DiviseurSalaire = diviseurSalaire;
    }
}
