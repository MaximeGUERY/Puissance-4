using System;

namespace puissance4
{
    class Program
    {
        static int victoire_ligne(char[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < (grille.GetLength(1)-3); j++)
                {
                    if (grille[i, j] == grille[i, j + 1] && grille[i, j] == grille[i, j + 2]  && grille[i, j] == grille[i, j + 3])
                        if (grille[i, j] != '-')
                        {
                            if (grille[i, j] != 'X')
                                return 2;
                            if (grille[i, j] != '0')
                                return 1;
                        }
                }
            }
                    return 0;
;        }
        static int victoire_colonne(char[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < (grille.GetLength(1) ); j++)
                {
                    if (grille[i, j] == grille[i+1, j] && grille[i, j] == grille[i+2, j] && grille[i, j] == grille[i+3, j])
                        if (grille[i, j] != '-')
                        {
                            if (grille[i, j] != 'X')
                                return 2;
                            if (grille[i, j] != '0')
                                return 1;
                        }
                }
            }
            return 0;
            ;
        }
        static int victoire_diagonale (char[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < (grille.GetLength(1) - 3); j++)
                {
                    if (grille[i, j] == grille[i + 1, j+1] && grille[i, j] == grille[i + 2, j+2] && grille[i, j] == grille[i + 3, j+3])
                        if (grille[i, j] != '-')
                        {
                            if (grille[i, j] != 'X')
                                return 2;
                            if (grille[i, j] != '0')
                                return 1;
                        }
                }
            }
            for (int i = 0; i < grille.GetLength(0)-3; i++)
            {
                for (int j = 3; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == grille[i + 1, j - 1] && grille[i, j] == grille[i + 2, j - 2] && grille[i, j] == grille[i + 3, j - 3])
                        if (grille[i, j] != '-')
                        {
                            if (grille[i, j] != 'X')
                                return 2;
                            if (grille[i, j] != '0')
                                return 1;
                        }
                }
            }
            return 0;
        }
        static int detecter_victoire(char[,] grille)
        {
            int Joueur_victoire = 0;
            if (Joueur_victoire == 0)
                Joueur_victoire = victoire_ligne(grille);
            if (Joueur_victoire == 0)
                Joueur_victoire = victoire_colonne(grille);
            if (Joueur_victoire == 0)
                Joueur_victoire = victoire_diagonale(grille);
            return Joueur_victoire;
        }
        static int CaseLaPlusBas(char[,] grille, int colonne)
        {
            int ligne = 1;
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                if (grille[i, colonne] == '-') { ligne = i; }
            }
            return ligne;
        }
        static char[,] Jouer(int joueur,char[,] grille, int colonne)
        {
            int ligne = CaseLaPlusBas(grille, colonne);
            if (joueur==1)
            grille[ligne, colonne] = 'X';
            if (joueur == 2)
                grille[ligne, colonne] = '0';
            return grille;
        }
        static int return0()
        {
            return 0;
        }
        static bool VerifierPlaceColonne(char[,] grille, int colonne)
        {
            if (grille[0,colonne] != '-') { return false; }
            else { return true; }
        }
        static char[,] Jouercoup(int joueur, char[,] grille)
        {
            int colonne = 7;

            do { colonne = Demandercolonne(); } while (!VerifierPlaceColonne(grille, colonne));
            grille = Jouer(joueur,grille, colonne);

            return grille;

        }
        static int ChangerJoueur(int joueur)
        {
            int nouveaujoueur = 0;
            if (joueur == 1) { nouveaujoueur = 2; }
            if (joueur == 2) { nouveaujoueur = 1; }
            return nouveaujoueur;
        }
        static int Demandercolonne()
        {
            int colonne = 7;
            int entreeOK = 0;
            while (entreeOK != 1)
            {

                Console.WriteLine("Entrez une colonne pour jouer entre A et G");
                try
                {
                    string entree = Console.ReadLine();
                    switch (entree)
                    {
                        case "A":
                            colonne = 0;
                            break;
                        case "B":
                            colonne = 1;
                            break;
                        case "C":
                            colonne = 2;
                            break;
                        case "D":
                            colonne = 3;
                            break;
                        case "E":
                            colonne = 4;
                            break;
                        case "F":
                            colonne = 5;
                            break;
                        case "G":
                            colonne = 6;
                            break;
                        default:
                            break;
                    }
                }
                catch { Console.WriteLine("ERREUR! Veuillez uniquement taper une lettre entre A et G en majuscule SVP"); }
                if (colonne < 7) { entreeOK = 1; }
            }
            return colonne;
        }
        static char[,] CreerGrille()
        {
            Char[,] grille = new char[6, 7];

            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    grille[i, j] = '-';
                }
            }
            return grille;
        }
        static void AfficherGrille(char[,] grille)
        {
            Console.WriteLine("    A B C D E F G");
            Console.WriteLine("__________________");
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                Console.Write(i + 1 + " |");
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    Console.Write(" " + grille[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("__________________");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur le puissance 4");
            char[,] grille = CreerGrille();
            Console.WriteLine("Appuyez sur entrée pour continuer...");
            Console.ReadLine();

            int joueur = 1;
            int boucle = 1;
            int gagnant = 0;
            while (boucle !=0)
            {
                Console.Clear();
                Console.WriteLine("Au joueur " + joueur + " de jouer !");
                AfficherGrille(grille);

                grille = Jouercoup(joueur, grille);
                joueur = ChangerJoueur(joueur);
                gagnant = detecter_victoire(grille);
                if (gagnant != 0)
                    boucle = 0;
            }
            Console.Clear();
            Console.WriteLine("le joueur " + gagnant + " a gagné !");
            AfficherGrille(grille);
            Console.WriteLine("FIN DE PARTIE");
            Console.ReadLine();
            return0();
        }
    }
}
