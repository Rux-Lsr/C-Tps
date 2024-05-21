#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>


bool estSur(int disponible[], int allocation[], int besoin[], int n, int m) {
    int travail[m];  // Création du tableau travail.
    bool termine[n];  // Création du tableau termine.
    for (int i = 0; i < m; i++) {  // Pour chaque ressource...
        travail[i] = disponible[i];  // Initialiser le tableau travail avec les ressources disponibles.
    }
    for (int i = 0; i < n; i++) {  // Pour chaque processus...
        termine[i] = false;  // Initialiser le tableau termine à false.
    }

    // Boucle principale pour vérifier si le système est dans un état sûr.
    for (int i = 0; i < n; i++) {
        bool trouve = false;  // Variable pour vérifier si un processus peut terminer.
        for (int j = 0; j < n; j++) {  // Pour chaque processus...
            if (!termine[j] && besoin[j] <= travail[0]) {  // Si le processus n'a pas encore terminé et que son besoin est inférieur ou égal à la ressource disponible...
                travail[0] += allocation[j];  // Ajouter l'allocation du processus à la ressource disponible.
                termine[j] = true;  // Marquer le processus comme terminé.
                trouve = true;  // Un processus a été trouvé qui peut terminer.
                break;  // Sortir de la boucle.
            }
        }
        if (!trouve) {  // Si aucun processus n'a été trouvé qui peut terminer...
            return false;  // Le système n'est pas dans un état sûr.
        }
    }

    return true;  // Le système est dans un état sûr.
}

char** banquierRessourceUnique(char* processus[], int disponible, int besoinMax[], int n) {
    int allocation[n];  // Création du tableau allocation.
    int besoin[n];  // Création du tableau besoin.
    for (int i = 0; i < n; i++) {  // Pour chaque processus...
        allocation[i] = 0;  // Initialiser le tableau allocation à zéro.
        besoin[i] = besoinMax[i];  // Initialiser le tableau besoin avec le besoin maximum de chaque processus.
    }

    // Vérifier si le système est dans un état sûr.
    if (estSur(&disponible, allocation, besoin, n, 1)) {
        char** sequenceSure = malloc(sizeof(char*) * n);  // Création du tableau sequenceSure.
        int index = 0;  // Initialisation de l'index pour le tableau seq
// Fonction principale.uenceSure.
        for (int i = 0; i < n; i++) {  // Pour chaque processus...
            for (int j = 0; j < n; j++) {  // Pour chaque processus...
                if (besoin[j] <= disponible) {  // Si le besoin du processus est inférieur ou égal à la ressource disponible...
                    disponible += allocation[j];  // Ajouter l'allocation du processus à la ressource disponible.
                    allocation[j] = 0;  // Réinitialiser l'allocation du processus à zéro.
                    besoin[j] = 0;  // Réinitialiser le besoin du processus à zéro.
                    sequenceSure[index++] = processus[j];  // Ajouter le processus à la séquence sûre.
                    break;  // Sortir de la boucle.
                }
            }
        }
        return sequenceSure;  // Retourner la séquence sûre.
    } else {
        char** message = malloc(sizeof(char*) * 1);  // Création du tableau message.
        message[0] = "Le système n'est pas dans un état sûr.";  // Ajouter le message d'erreur au tableau message.
        return message;  // Retourner le message d'erreur.
    }
}

int main() {
    char* processus[] = {"P0", "P1", "P2", "P3"};  // Définition des processus.
    int disponible = 3;  // Définition de la ressource disponible.
    int besoinMax[] = {3, 2, 2, 1};  // Définition du besoin maximum de chaque processus.
    int n = sizeof(processus) / sizeof(processus[0]);  // Calcul du nombre de processus.

    // Exécution de l'algorithme du banquier pour une ressource unique.
    char** resultat = banquierRessourceUnique(processus, disponible, besoinMax, n);
    if (resultat[0][0] == 'L') {  // Si le premier caractère du résultat est 'L'...
        printf("%s\n", resultat[0]);  // Afficher le message d'erreur.
    } else {
        for (int i = 0; i < n; i++) {  // Pour chaque processus...
            printf("%s ", resultat[i]);  // Afficher le processus dans la séquence sûre.
        }
        printf("\n");  // Ajouter une nouvelle ligne à la fin de l'affichage.
    }

    free(resultat);  // Libérer la mémoire allouée pour le tableau resultat.
    return 0;  // Terminer le programme avec le code de sortie 0.
}
