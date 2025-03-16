Console.WriteLine("Benvenuto nel Gioco dell'Impiccato!");
Console.WriteLine("In questo gioco, il tuo obiettivo è indovinare una parola segreta, lettera per lettera, prima che l'impiccato venga completato.");
Console.WriteLine("Ogni volta che indovini una lettera correttamente, la parola si aggiornerà. Se invece sbagli, una parte dell'impiccato apparirà. Hai un numero limitato di tentativi, quindi fai attenzione!");

Random random = new Random();
string tema_scelto()
{
    Console.WriteLine("Sei pronto a iniziare? Scegli una tema per la parola!" +
    "\n1. Animale" +
    "\n2. Oggetto" +
    "\n3. Paese" +
    "\n4. Piante");

    string tema = Console.ReadLine().ToLower();

    if (tema != null)
    {
        if (tema == "animale" || tema == "1")
        {
            return "impiccato_animale.txt";
        }
        else if (tema == "oggetto" || tema == "2")
        {
            return "impiccato_oggetto.txt";
        }
        else if (tema == "paese" || tema == "3")
        {
            return "impiccato_paese.txt";
        }
        else if (tema == "piante" || tema == "4")
        {
            return "impiccato_piante.txt";
        }
        else
        {
            return "Errore! La tema non valida";
        }
    }
    return "Errore! Perfavore inserisci la tema valida";
}

void parole(string[] p, ref string[] pd, int n)
{
    int a = 0, b = 0, c = 0;
    Console.WriteLine("Scegli la difficoltà del gioco:" +
        "\n1. Facile - Parole corte, più tentativi disponibili (il numero dei tentativi: 10)." +
        "\n2. Normale - Parole di lunghezza media, tentativi moderati (il numero dei tentativi: 8)." +
        "\n3. Difficile - Parole lunghe, pochi tentativi (il numero dei tentativi: 5).");
    string d = Console.ReadLine().ToLower();

    if (d != null)
    {
        if (d == "facile" || d == "1")
        {
            n = 10;
            b = 20;
        }
        else if (d == "normale" || d == "2")
        {
            n = 8;
            a = 20;
            b = 40;
        }
        else if (d == "difficile" || d == "3")
        {
            n = 5;
            a = 40;
            b = p.Length;
        }
        else
        {
            Console.WriteLine("Errore! La difficoltà sbagliata");
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
        Console.WriteLine("Errore! Perfavore inserisci la tema valida");
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

bool indovina(string p, int n)
{
    Console.WriteLine("Adesso indovina la parola nascosta una lettera alla volta!");
    char[] lettere_parola_segreta = p.ToCharArray();
    char[] parola_con_trattini = new char[lettere_parola_segreta.Length];
    for (int i = 0; i < parola_con_trattini.Length; i++)
    {
        parola_con_trattini[i] = '_';
    }

    char lettera = '0';
    int numero_lettere_indovinata = 0;
    int tentativi = 0;
    int tentativi_per_indovinare_parola = 2;
    char[] lettere_indovinata = new char[lettere_parola_segreta.Length];

    while (numero_lettere_indovinata < parola_con_trattini.Length)
    {
        Console.WriteLine(new string(parola_con_trattini));

        Console.WriteLine("Inserisci una lettera");
        lettera = Console.ReadKey().KeyChar;

        Console.WriteLine();

        if (lettere_parola_segreta.Contains(lettera))
        {
            numero_lettere_indovinata++;

            for (int i = 0; i < lettere_parola_segreta.Length; i++)
            {
                if (lettere_parola_segreta[i] == lettera)
                {
                    parola_con_trattini[i] = lettere_parola_segreta[i];
                }
            }

            Console.WriteLine("Bravo! Hai indovinato una lettera!");
        }
        else
        {
            Console.WriteLine("Oops! La lettera che hai scelto non è corretta. Riprova! Hai ancora tempo, non arrenderti!");
        }

        tentativi++;

        if (tentativi > tentativi_per_indovinare_parola)
        {
            Console.WriteLine(new string(parola_con_trattini));
            Console.WriteLine("Vuoi provare a indovinare la parola completa? (si/no)");
            string risposta = Console.ReadLine().ToLower();

            if (risposta == "si")
            {
                if (indovina_parola(p))
                {
                    return true;
                }
            }
            else if (risposta != "si" && risposta != "no")
            {
                Console.WriteLine("Errore! La scelta sbagliata");
            }
        }
        if(!new string(parola_con_trattini).Contains("_"))
        {
            return true;
        }
        Console.WriteLine($"Il numero dei tentativi: {tentativi}");
    }

    return false;
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

    int num_tentativi = 0;
    string filePath = tema_scelto();

    if (filePath.Contains("Errore"))
    {
        Console.WriteLine(filePath);
    }
    else
    {
        string[] lines = File.ReadAllLines(filePath);
        parole(lines, ref parola_scelte, num_tentativi);
        parola = parola_casuale(parola_scelte);
        parola_segreta = parola_da_indovina(parola);

        if (indovina(parola_segreta, num_tentativi) == true)
        {
            Console.WriteLine("Congratulazioni! Hai indovinato la parola!");
        }
        else
        {
            Console.WriteLine($"Oops! Hai esaurito tutti i tentativi, ma non preoccuparti! La parola segreta era: {parola_segreta}." +
                $"\nNon arrenderti! Prova a fare meglio la prossima volta, ricordati che ogni tentativo è un passo più vicino alla vittoria! Ci vediamo al prossimo gioco!");
        }

        Console.WriteLine("Vuoi provare di nuovo con una nuova parola? (si/no)");
        ris = Console.ReadLine().ToLower();
        if (ris == "si")
        {
            return true;
        }
    }
    return false;
}

string parola_casuale(string[] parole)
{
    int posizione = random.Next(0, 21);
    return parole[posizione];
}

if(gioco() == true)
{
    Console.WriteLine("Fantastico! Sei pronto per un nuovo giro! Adesso, scegli una nuova parola e preparati a mettere alla prova le tue abilità! Ricorda, ogni errore è solo un passo verso la vittoria. Buona fortuna!");
    gioco();
}
