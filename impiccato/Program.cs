Console.WriteLine("Benvenuto nel Gioco dell'Impiccato!");
Console.WriteLine("In questo gioco, il tuo obiettivo è indovinare una parola segreta, lettera per lettera, prima che l'impiccato venga completato.");
Console.WriteLine("Ogni volta che indovini una lettera correttamente, la parola si aggiornerà. Se invece sbagli, una parte dell'impiccato apparirà. Hai un numero limitato di tentativi, quindi fai attenzione!");

Random random = new Random();
string tema_scelto()
{
    bool s = false;
    Console.WriteLine("Sei pronto a iniziare? Scegli una tema per la parola!" +
    "\n1. Animale" +
    "\n2. Oggetto" +
    "\n3. Paese" +
    "\n4. Piante");

    while (s == false)
    {
        string tema = Console.ReadLine().ToLower();
        if (tema != null)
        {
            if (tema == "animale" || tema == "1")
            {
                s = true;
                return "impiccato_animale.txt";
            }
            else if (tema == "oggetto" || tema == "2")
            {
                s = true;
                return "impiccato_oggetto.txt";
            }
            else if (tema == "paese" || tema == "3")
            {
                s = true;
                return "impiccato_paese.txt";
            }
            else if (tema == "piante" || tema == "4")
            {
                s = true;
                return "impiccato_piante.txt";
            }
            else
            {
                Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
            }
        }
        else
        {
            Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
        }
    }
    return "Errore";
}

void parole(string[] p, ref string[] pd, ref int nt)
{
    bool s = false;
    int a = 0, b = 0, c = 0;
    Console.WriteLine("Scegli la difficoltà del gioco:" +
        "\n1. Facile - Parole corte, più tentativi disponibili (il numero dei tentativi: 10)." +
        "\n2. Normale - Parole di lunghezza media, tentativi moderati (il numero dei tentativi: 8)." +
        "\n3. Difficile - Parole lunghe, pochi tentativi (il numero dei tentativi: 5).");
    
    while (s == false)
{
    string d = Console.ReadLine().ToLower();

        if (d != null)
        {
            if (d == "facile" || d == "1")
            {
                nt = 10;
                b = 20;
                s = true;
            }
            else if (d == "normale" || d == "2")
            {
                nt = 8;
                a = 20;
                b = 40;
                s = true;
            }
            else if (d == "difficile" || d == "3")
            {
                nt = 5;
                a = 40;
                b = p.Length;
                s = true;
            }
            else
            {
                Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
            }
            if (b > p.Length)
            {
                b = p.Length;
            }
            for (int i = a; i < b; i++)
            {
                pd[c++] = p[i];
            }
        }
        else
        {
            Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
        }
    }
}

string parola_da_indovina(string p)
{
    string parola = null;
    if (p.Contains("Facile"))
    {
        parola = p.Substring(7);
    }
    else if (p.Contains("Normale"))
    {
        parola = p.Substring(8);
    }
    else
    {
        parola = p.Substring(10);
    }
    return parola.ToLower();
}

bool indovina(string p, int tentativi_max)
{
    Console.WriteLine("Adesso indovina la parola nascosta una lettera alla volta!");
    char[] lettere_parola_segreta = p.ToCharArray();
    char[] parola_con_trattini = new char[lettere_parola_segreta.Length];

    for (int i = 0; i < parola_con_trattini.Length; i++)
    {
        parola_con_trattini[i] = '_';
    }

    char lettera;
    int tentativi = 0, nTentativi_lettere_indovinate = 0;
    char[] lettere_indovinate = new char[26];
    bool game_over = false;
    string risposta;

    while (!game_over)
    {
        Console.WriteLine(new string(parola_con_trattini));
        Console.WriteLine($"le lettere provate: {new string(lettere_indovinate)}");
        Console.WriteLine($"Tentativi rimasti: {tentativi_max - tentativi}");
        Console.WriteLine("Inserisci una lettera:");
        lettera = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (lettere_indovinate.Contains(lettera))
        {
            Console.WriteLine("Hai già scelto questa lettera! Prova con una lettera diversa.");
            continue;
        }

        bool lettera_corretta = false;
        for (int i = 0; i < lettere_parola_segreta.Length; i++)
        {
            if (lettere_parola_segreta[i] == lettera)
            {
                parola_con_trattini[i] = lettera;
                lettera_corretta = true;
            }
        }

        if (lettera_corretta)
        {
            nTentativi_lettere_indovinate++;
            Console.WriteLine("Bravo! Hai indovinato una lettera.");
        }
        else
        {
            Console.WriteLine("Oops! La lettera che hai scelto non è corretta.");
        }

        tentativi++;

        lettere_indovinate[tentativi] = lettera;

        if (!new string(parola_con_trattini).Contains("_"))
        {
            Console.WriteLine("Congratulazioni! Hai indovinato la parola!");
            game_over = true;
        }
        else if (tentativi >= tentativi_max)
        {
            Console.WriteLine($"Hai esaurito i tentativi. La parola segreta era: {p}");
            game_over = true;
        }
        else if (nTentativi_lettere_indovinate > 2)
        {
            Console.WriteLine(new string(parola_con_trattini));
            Console.WriteLine("Sei pronto a indovinare la parola completa? (si/no)");
            risposta = Console.ReadLine().ToLower();

            if (risposta == "si")
            {
                if (indovina_parola(p))
                {
                    game_over = true;
                }
            }
            else
            {
                Console.WriteLine("Va bene! Continui a indovinare le lettere!");
            }
        }
    }
    return game_over;
}

bool indovina_parola(string p)
{
    Console.WriteLine("Perfetto! Hai deciso di provarci. Scrivi la tua risposta e vediamo se hai indovinato!");
    string parola_provata = Console.ReadLine();
    if (parola_provata == p)
    {
        return true;
    }
    else
    {
        Console.WriteLine("Oops! La parola che hai provato non è corretta. Non preoccuparti, puoi continuare a giocare! Prova a indovinare un’altra lettera o riprova a indovinare la parola!");
        return false;
    }
}

bool gioco()
{
    string[] parola_scelte = new string[20];
    string parola, parola_segreta, ris;
    string[] parole_indovinate = new string[60];
    string[] parole_non_indovinate = new string[60];

    int num_tentativi = 0, posizione_non_indovinate = 0, posizione_indovinate = 0;
    string filePath = tema_scelto();

    bool risposta = false;

    string[] lines = File.ReadAllLines(filePath);
    parole(lines, ref parola_scelte, ref num_tentativi);
    parola = parola_casuale(parola_scelte);
    parola_segreta = parola_da_indovina(parola);

    if (indovina(parola_segreta, num_tentativi) == true)
    {
        Console.WriteLine("Congratulazioni! Hai indovinato la parola!");
        parole_indovinate[posizione_indovinate++] = parola_segreta;
    }
    else
    {
        Console.WriteLine($"Oops! Hai esaurito tutti i tentativi, ma non preoccuparti! La parola segreta era: {parola_segreta}." +
            $"\nNon arrenderti! Prova a fare meglio la prossima volta, ricordati che ogni tentativo è un passo più vicino alla vittoria!");
        parole_non_indovinate[posizione_non_indovinate++] = parola_segreta;
    }

    while (risposta == false)
    {
        Console.WriteLine("Vuoi provare di nuovo con una nuova parola? (si/no)");
        ris = Console.ReadLine().ToLower();
        if (ris == "si")
        {
            risposta = true;
            return true;
        }
        else if (ris == "no")
        {
            risposta = true;

            Console.Write("Le parole indovinate sono: ");
            for (int i = 0; i < parole_indovinate.Length; i++)
            {
                if (parole_indovinate[i] != null)
                {
                    Console.Write($"{parole_indovinate[i]}, ");
                }
            }

            Console.Write("Le parole non indovinate sono: ");
            for (int i = 0; i < parole_non_indovinate.Length; i++)
            {
                if (parole_non_indovinate[i] != null)
                {
                    Console.Write($"{parole_non_indovinate[i]} ");
                }
            }
        }
        else
        {
            Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
        }
    }
    return false;
}

string parola_casuale(string[] parole)
{
    int posizione = random.Next(0, 20);
    return parole[posizione];
}

if (gioco() == true)
{
    Console.WriteLine("Fantastico! Sei pronto per un nuovo giro! Adesso, scegli una nuova parola e preparati a mettere alla prova le tue abilità! Ricorda, ogni errore è solo un passo verso la vittoria. Buona fortuna!");
    gioco();
}
