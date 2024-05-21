#include<stdio.h>
#include<stdlib.h>

// Nombre de processus
#define PROCESS 5
// Nombre de types de ressources
#define RESSOURCE 3
// Fonction pour trouver le système sûr ou non

/// @brief Verifier si une il existe une sequence sure
/// @param avail les ressources disponibles
/// @param maxm  les ressources maximumale requises par chaque processus
/// @param allot  ressources alloue aux processus initialement
void isSafe(int avail[], int maxm[][RESSOURCE], int allot[][RESSOURCE]);

/// @brief Recuperer les valeur des ressources des processus dans un fichier
/// @param nom_fichier nom du fichier dans lequel lire les donnees correspondantes aux ressources
/// @param maxm  Ressources maximales requise par les processus
/// @param allot Ressources allouees aux processus a l'etat initial
void read_ressources_in_file(const char *nom_fichier, int maxm[][RESSOURCE], int allot[][RESSOURCE]);

int main()
{
    const char *nom_fichier = "process_ressources.txt";
    int proc[] = {0, 1, 2, 3, 4};
    int avail[] = {3, 3, 2};
    int maxm[PROCESS][RESSOURCE];
    int allot[PROCESS][RESSOURCE];

    read_ressources_in_file(nom_fichier, maxm, allot);

    // Vérifie si le système est sûr ou non
    isSafe(avail, maxm, allot);

    return 0;
}

void isSafe(int avail[], int maxm[][RESSOURCE], int allot[][RESSOURCE])
{
    int need[PROCESS][RESSOURCE];
    // Calcul des besoins de chaque processus
    for (int i = 0 ; i < PROCESS ; i++)
        for (int j = 0 ; j < RESSOURCE; j++)
            need[i][j] = maxm[i][j] - allot[i][j];

    int finish[PROCESS] = {0};
    // tableau pour stocker la séquence de sécurité
    int safeSeq[PROCESS];

    // copie des ressources disponibles
    int work[RESSOURCE];
    for (int i = 0; i < RESSOURCE; i++)
        work[i] = avail[i];
        // Tant qu'il reste des processus non terminés
    int count = 0;
    while (count < PROCESS)
    {
        // Trouver un processus qui peut être terminé
        int found = 0;
        for (int p = 0; p < PROCESS; p++)
        {

            if (finish[p] == 0)
            {
                int j;
                for (j = 0; j < RESSOURCE; j++)
                    if (need[p][j] > work[j])
                        break;
                // Si tous les besoins de p sont satisfaits
                if (j == RESSOURCE)
                {
                    printf("%d\n", p);
                    for (int k = 0 ; k < RESSOURCE; k++)
                        work[k] += allot[p][k];
                    // Ajouter ce processus à la séquence de sécurité
                    safeSeq[count++] = p;
                    // Marquer ce processus comme terminé
                    finish[p] = 1;
                    found = 1;
                }

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
    for (int i = 0; i < PROCESS ; i++)
        printf("PROCESS_%d ", safeSeq[i]);
}
void read_ressources_in_file(const char *nom_fichier, int maxm[][RESSOURCE], int allot[][RESSOURCE]) {
    FILE *fichier = fopen(nom_fichier, "r");
    if (fichier == NULL) {
        printf("Erreur lors de l'ouverture du fichier.\n");
        exit(1);
    }

    for (int i = 0; i < PROCESS; i++) {
        for (int j = 0; j < RESSOURCE; j++) {
            if (fscanf(fichier, "%d", &maxm[i][j]) != 1) {
                printf("Erreur lors de la lecture des données.\n");
                exit(1);
            }
        }
    }

    for (int i = 0; i < PROCESS; i++) {
        for (int j = 0; j < RESSOURCE; j++) {
            if (fscanf(fichier, "%d", &allot[i][j]) != 1) {
                printf("Erreur lors de la lecture des données.\n");
                exit(1);
            }
        }
    }

    fclose(fichier);
}