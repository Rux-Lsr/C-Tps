import 'package:flutter/material.dart';

class MyBottomNavigationBar extends StatefulWidget {
  const MyBottomNavigationBar({super.key});

  @override
  State<MyBottomNavigationBar> createState() => _MyBottomNavigationBarState();
}

class _MyBottomNavigationBarState extends State<MyBottomNavigationBar> {
  int _selectedIndex = 0; // Index de l'élément sélectionné

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
      // Ajoutez ici la navigation vers la page correspondante à l'index
    });
  }

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
      selectedItemColor: Colors.white,
      backgroundColor: Colors.black,
      unselectedItemColor: Colors.grey,
      currentIndex: _selectedIndex,
      onTap: _onItemTapped,
      type: BottomNavigationBarType
          .fixed, // Important pour afficher tous les éléments
      items: const <BottomNavigationBarItem>[
        BottomNavigationBarItem(
          icon: Icon(Icons.home),
          label: 'Accueil',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.explore),
          label: 'Découvrir',
        ),
        BottomNavigationBarItem(
          icon: Icon(
              Icons.add_circle), // Vous pouvez remplacer par un autre icône
          label: 'Plus',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.message_rounded),
          label: 'Boîte',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.person_outlined),
          label: 'Moi',
        ),
      ],
    );
  }
}
