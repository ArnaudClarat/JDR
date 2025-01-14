# The Qwest 

[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)  [![forthebadge](http://forthebadge.com/images/badges/powered-by-electricity.svg)](http://forthebadge.com)

Ce projet est une implémentation d'un jeu de rôle (JDR) développé en C#, contenant des classes, des ressources et un exécutable principal. Voici une vue d'ensemble pour vous guider dans l'installation, l'exécution et la personnalisation du jeu.

Liste base : 

    Un héro :
    - Point de vie (+-20PV)
    - Une attaque
    - Stat de défense (Réduction de dégat)

    Une map : 
    - Différents environnement (Forêt, prairie) (purement graphique)
    - Une zone de boss (ou deux)
    - Un endroit de spawn (respawn)

    Au moins 3 ennemis (par zone) et 1 boss:
    - Point de vie
    - Une attaque
    - Stat de défense

    Fontaine de vie :
    - Rend entre 5 et 15 PV
    - Visible sur la map
    - Placé aléatoirement sur la map
    
    Coffres
    - Bonus d'attaque (Différents types d'arme (Hache, épée, bois, bronze, or))
    - Bonus de défense (Type d'armure (Fer, tissu, cuir ..))


## Pour commencer

### Pré-requis

Avant de commencer, assurez-vous d'avoir installé les outils suivants :

.NET 8.0 SDK ou version ultérieure : Requis pour compiler et exécuter le projet.

Téléchargez-le depuis : https://dotnet.microsoft.com/

Un éditeur de code : Par exemple, Visual Studio ou Visual Studio Code.

### Installation

Clonez ce dépôt ou téléchargez-le sous forme d'archive ZIP :

git clone <https://github.com/ArnaudClarat/JDR.git>
cd JDR

Restaurez les dépendances avec le gestionnaire .NET si nécessaire :

dotnet restore

## Démarrage

Pour lancer le jeu, exécutez simplement la commande suivante :

dotnet run

Cela démarrera le programme principal défini dans Program.cs.

## Fabriqué avec

* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Framework front-end basé sur C#  
* [Blazor Web Assembly](http://materializecss.com) - Framework CSS (front-end)
* [Visual Studio Code](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Exécution d'applications web côté client avec .NET  

## Auteurs

* **Anthony Chang** _alias_ [@changzhiho](https://github.com/changzhiho)
* **Arnaud Clara** _alias_ [@ArnaudClarat](https://github.com/ArnaudClarat)
* **Kévin Goossens** _alias_ [@KGOx](https://github.com/KGOx)
* **Enzo Scarpa** _alias_ [@enzoscarpa-fnk](https://github.com/enzoscarpa-fnk)


