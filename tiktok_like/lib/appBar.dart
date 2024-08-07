import 'package:flutter/material.dart';

AppBar homeAppBar() {
  return AppBar(
    backgroundColor: Colors.transparent,
    elevation: 0,
    title: const Row(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        Text(
          'Abonnement',
          style: TextStyle(
              fontSize: 15, color: Colors.white, fontWeight: FontWeight.bold),
        ),
        Text(
          'Amis',
          style: TextStyle(
              fontSize: 15, color: Colors.white, fontWeight: FontWeight.bold),
        ),
        Text(
          'Pour toi',
          style: TextStyle(
              fontSize: 15, color: Colors.white, fontWeight: FontWeight.bold),
        )
      ],
    ),
  );
}
