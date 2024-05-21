#include<stdio.h>
#include<stdlib.h>
// Nombre de processus
#define P 5
void isSafe(int avail, int maxm[], int allot[]);
void read_ressources_in_file(const char *nom_fichier, int maxm[], int allot[]);

int main()
{
     // Ressources disponibles
    int avail = 10;
    // Ressources maximales requises par les processus
    int maxm[P];
    // Ressources allouées aux processus
    int allot[P];

    // Lecture des données depuis le fichier
    read_ressources_in_file("process_ressources.txt", maxm, allot);

    // Vérifie si le système est sûr ou non
    isSafe(avail, maxm, allot);
}
/// @brief Verifier si une il existe une sequence sure
/// @param avail les ressources disponibles
/// @param maxm  les ressources maximumale requises par chaque processus
/// @param allot  ressources alloue aux processus initialement
void isSafe( int avail, int maxm[], int allot[])
{
    int need[P];
    // Calcul des besoins de chaque processus
    for (int i = 0 ; i < P ; i++)
        need[i] = maxm[i] - allot[i];
    int finish[P] = {0};
    // Pour stocker la séquence de sécurité
    int safeSeq[P];
    // Travaillez avec une copie des ressources disponibles
    int work = avail;
    // Tant qu'il reste des processus non terminés
    int count = 0;
    while (count < P)
    {
        // Trouver un processus qui peut être terminé
        int found = 0;
        for (int p = 0; p < P; p++)
        {
            if (finish[p] == 0 && need[p] <= work)
            {
                work += allot[p];
                safeSeq[count++] = p;
                finish[p] = 1;
                found = 1;
            }
        }
        // Si nous ne pouvons pas trouver un processus suivant dans la séquence de sécurité
        if (found == 0)
        {
            printf("Le système n'est pas en état sûr");
            return;
        }
    }
    // Si le système est en état sûr
    printf("Le système est en état sûr.\nLa séquence de sécurité est : ");
    for (int i = 0; i < P ; i++)
        printf("PROCESS_%d ", safeSeq[i]);
}

/// @brief lires les donnes representant les ressources dans un fichier
/// @param nom_fichier  chemin d'access au fichier dans le quel lire
/// @param maxm ressources maximale a utiliser par les  processus
/// @param allot ressources initiale affectees au processus
void read_ressources_in_file(const char *nom_fichier, int maxm[], int allot[])
{
    FILE *fichier = fopen(nom_fichier, "r");
    if (fichier == NULL)
    {
        printf("Erreur lors de l'ouverture du fichier.\n");
        exit(1);
    }

    for (int i = 0; i < P; i++)
    {
        if (fscanf(fichier, "%d %d", &maxm[i], &allot[i]) != 2)
        {
            printf("Erreur lors de la lecture des données.\n");
            exit(1);
        }
    }

    fclose(fichier);
}
