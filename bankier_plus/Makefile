bankier:algorithme_Banquier_plrs_ressource.c
	gcc -o bankier_plus algorithme_Banquier_plrs_ressource.c -g -O0 -lm -lpthread -fopenmp

run:bankier_plus
	./bankier_plus
run_valgrind:produit_matriciel
	valgrind  --tool=memcheck --leak-check=yes --leak-resolution=low --show-reachable=yes  ./bankier_plus
clean:
	rm  bankier_plus

profile:
	gcc -Wall -pg algorithme_Banquier_plrs_ressource.c -lm -lpthread -o bankier_plus
