# TP2


## I - Les difficultés liées à la validation

Dans l'ensemble, le jeu fonctionne correctement, bien que quelques bugs soient présents et peuvent être détectés dès la première utilisation. Cependant, la structure du code rend difficile toute évolution simple, voire l'intégration de tests automatisés pour une avoir une certaines couverture du code.

### Erreur détectés à l'utilisation

- La condition de victoire sur la première ligne du morpion est incorrecte.
- L'affichage de la grille du morpion est incorrect.
- Le Puissance 4 ne vérifie pas toutes les diagonales dans sa condition de victoire.

### Commentaires sur le code actuel

1. Les méthodes dans le code existant sont très longues, ce qui les rend difficiles à comprendre et à maintenir. Des méthodes trop longues sont souvent difficiles à tester et à réutiliser.

```c#
 public void tourJoueur() { ... } ~ 70 lignes
```

2. La complexité cyclomatique est important ce qui rent le code complexe et difficile à suivre. Les nombreux switch et if imbriqués augmentent cette complexité ainsi que l'utilisation de goto qui est une pratique à éviter.

```c#
static void Main(string[] args)
{
    Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
GetKey:
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.X:
            Morpion morpion = new Morpion();
            morpion.BoucleJeu();
            break;
        case ConsoleKey.P:
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
            puissanceQuatre.BoucleJeu();
            break;
        default:
            goto GetKey;
    }
    Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
GetKey1:
    switch (Console.ReadKey(true).Key)
    {...}
}
```

3. Les méthodes sans retour ne renvoient aucune valeur ce qui les rend difficiles à tester. Pour tester une méthode, il est souvent nécessaire de vérifier son effet sur l'état de l'application ou de vérifier la valeur qu'elle renvoie.

```c#
public void BoucleJeu() {...}
public void tourJoueur() {...}
public void tourJoueur2() {...}
public void affichePlateau() {...}
```

4. Du code dupliqué est souvent présent dans ce projet, ce qui augmente la maintenance nécessaire et rend le code plus fragile aux erreurs. Le code mort, qui ne contribue pas à la fonctionnalité de l'application, devrait être supprimé pour améliorer la lisibilité et la maintenabilité du code.

```c#
public void tourJoueur() {...}
public void tourJoueur2() {...}
```

5. Les classes du projet ont des dépendances fortes entre elles, ce qui les rend difficiles à réutiliser et à tester individuellement. Une dépendance forte augmente également le couplage entre les classes, ce qui rend le code plus rigide et moins flexible. Il faudrait priviligié l'injection de dépendance.

6. Le code utilise des types primitifs pour représenter des concepts métier, ce qui peut rendre le code moins expressif et plus sujet aux erreurs. Une meilleure utilisation des concepts de la programmation orientée objet pourrait améliorer la clarté et la maintenabilité du code.

```c#
 grille = new char[3, 3]
 {
     { ' ', ' ', ' '},
     { ' ', ' ', ' '},
     { ' ', ' ', ' '},
 };
```

7. Le code existant ne tire pas pleinement parti des avantages de la programmation orientée objet, tels que l'encapsulation, l'abstraction, l'héritage et le polymorphisme. Une utilisation plus efficace de ces concepts pourrait rendre le code plus modulaire, réutilisable et facile à comprendre.

8. Les interactions avec la console rendent le code difficile à tester automatiquement. Les méthodes qui dépendent de la console pour les entrées/sorties sont difficiles à tester car elles nécessitent une interaction humaine. Cette dépendance doit être réduite pour faciliter l'écriture de tests automatisés.


## II - Les méthodes de résolution de ces problèmes

### Objectifs

- Refactoriser une partie du code pour le rendre compatible avec des tests automatisés.
- Ajouter des tests sur le projet afin de vérifier si un changement n'a pas impacté le fonctionnement normal du projet

Avec les premiers tests sur le code de base (avant refactoring), on retrouve les erreurs remarquées lors de l'utilisation (condition de victoire incorrect pour le morpion et Puissance 4). Cependant, le problème d'affichage de la grille du morpion ne peut pas être remonté par les tests car l'erreur se situe au niveau de l'affichage dans la console, ce qui ne peut être testé.

### Solution de refactoring

Il faudrait mettre en place une interface en C# qui répertorie toutes les interactions entre l'utilisateur et l'application. Cette interface devrait retourner `void` pour les méthodes qui se contentent de mettre à jour l'interface utilisateur, et un `enum` pour les méthodes qui fournissent un retour sur une action de l'utilisateur. Ensuite, une classe de substitution dans nos tests implémentera cette interface, permettant ainsi de contrôler les actions que serait censé faire un utilisateur.

<br>

Pour les modes de jeu `Morpion` et `PuissanceQuatre`, il faudrait mettre en place une interface C# qui définit des méthodes de comportement telles que :
- La vérification de la victoire pour un joueur.
- La vérification de l'égalité.
- Vérifier si un placement est valide.
- Appliquer le changement de position d'un pion (faire tomber le pion dans le Puissance4).

Ces différentes méthodes prendront une grille en paramètre, ce qui permettra de vérifier leur bon fonctionnement avec des grilles prédéfinies dans nos tests.

<br>

Pour limiter l'utilisation de primitives, on peut mettre en place une classe représentant la grille de jeu avec des méthodes permettant de récupérer rapidement des informations sur la grille comme :
- Les valeurs sur une ligne/colonne,
- Les valeurs sur une diagonale,
-L es positions qui sont vides, etc.

La classe posséderait un tableau 2D avec comme type un `enum` composé de 3 valeurs : `Vide`, `X` et `O`.

<br>

Il y aura une classe principale chargée d'exécuter les différentes méthodes de notre mode de jeu en utilisant l'interface utilisateur fournie pour dérouler le jeu choisi.


## III - Le développement des fonctionnalités manquantes

### « Brancher » un joueur contrôlé par l’ordinateur

Pour l'ajout d'une IA, il faudra ajouter une méthode dans l'interface implémentée par les classes `Morpion` et `PuissanceQuatre` afin de gérer le placement du pion de l'IA en fonction du mode de jeu. 

On ajoutera un attribut à la classe représentant le joueur pour indiquer s'il s'agit d'un bot ou d'un joueur, puis on ajoutera la logique dans la classe responsable du déroulement du jeu afin d'appeler la méthode de placement classique du jeu (pour le joueur) ou le mode de placement pour l'IA.

### Système permettant l’historisation et la persistance

Pour la sauvegarde, il faudra créer une classe qui représente la structure d'une sauvegarde dans un fichier JSON. 

On ajoutera dans l'interface C# de l'interface utilisateur, les méthodes d'interaction avec l'utilisateur nécessaires pour gérer la sauvegarde et le chargement d'une ancienne sauvegarde. 

Il y aura une classe qui se chargera de l'écriture et de la lecture du fichier de sauvegarde. Puis on mettra à jour la logique du programme pour charger un fichier de sauvegarde au lancement de l'application et en sauvegarder un nouveau au moment de quitter une partie.