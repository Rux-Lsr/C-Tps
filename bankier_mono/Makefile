bankier:algorithme_Banquier_une_ressource.c
	gcc -o bankier_mono algorithme_Banquier_une_ressource.c -g -O0 -lm -lpthread -fopenmp

run:bankier_mono
	./bankier_mono
run_valgrind:produit_matriciel
	valgrind  --tool=memcheck --leak-check=yes --leak-resolution=low --show-reachable=yes  ./bankier_mono
clean:
	rm  bankier_mono

profile:
	gcc -Wall -pg algorithme_Banquier_une_ressource.c -lm -lpthread -o bankier_mono
