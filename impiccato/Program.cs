Console.WriteLine("Benvenuto nel Gioco dell'Impiccato!");
Console.WriteLine("In questo gioco, il tuo obiettivo è indovinare una parola segreta, lettera per lettera, prima che l'impiccato venga completato.");
Console.WriteLine("Ogni volta che indovini una lettera correttamente, la parola si aggiornerà. Se invece sbagli, una parte dell'impiccato apparirà. Hai un numero limitato di tentativi, quindi fai attenzione!");

Console.WriteLine("Usa queste funzioni quando ritieni che possano darti un vantaggio strategico, ma ricorda che ogni scelta ha un costo. Buona fortuna!");

Random random = new Random();
string tema_scelto()
{
    bool s = false;
    Console.WriteLine();
    Console.WriteLine("Sei pronto a iniziare? Scegli una tema per la parola!" +
    "\n1. Animale - Nomi di animali comuni ed esotici, dai più noti ai più rari." +
    "\n2. Oggetto - Oggetti di uso quotidiano, dai più semplici ai più tecnici." +
    "\n3. Paese - Nomi di nazioni, dai più facili ai più complessi da scrivere." +
    "\n4. Piante - Fiori, alberi e piante, dalle più comuni alle più difficili da ricordare.");

    while (!s)
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

void parole(string[] p, ref string[] pd, ref int nt, ref int monete)
{
    bool s = false;
    int a = 0, b = 0, c = 0;

    Console.WriteLine();

    Console.WriteLine("Scegli la difficoltà del gioco, ogni volta che indovinerai la parola, riceverai un premio in monete che dipende dalla difficoltà della parola." +
        "\n1. Facile: 2 monete - Parole corte, più tentativi disponibili (il numero dei tentativi: 10)." +
        "\n2. Normale: 5 monete - Parole di lunghezza media, tentativi moderati (il numero dei tentativi: 8)." +
        "\n3. Difficile: 8 monete - Parole lunghe, pochi tentativi (il numero dei tentativi: 5).");
    
    while (!s)
{
    string d = Console.ReadLine().ToLower();

        if (d != null)
        {
            if (d == "facile" || d == "1")
            {
                monete = 2;
                nt = 10;
                b = 20;
                s = true;
            }
            else if (d == "normale" || d == "2")
            {
                monete = 5;
                nt = 8;
                a = 20;
                b = 40;
                s = true;
            }
            else if (d == "difficile" || d == "3")
            {
                monete = 8;
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

bool indovina(string p, int tentativi_max, int ind)
{
    bool contains = false;
    char[] lettere_parola_segreta = p.ToCharArray();
    char[] parola_con_trattini = new char[lettere_parola_segreta.Length];
    char[] lettere_alfabeto = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    char lettera;
    int tentativi = 0, nTentativi_lettere_indovinate = 0, n_prove = 0;
    char[] lettere_provate = new char[26];
    bool game_over = false;
    string risposta;

    for (int i = 0; i < parola_con_trattini.Length; i++)
    {
        parola_con_trattini[i] = '_';
    }

    if (ind == 1)
    {
        Console.WriteLine("Hai acquistato un indizio!" +
            $"\nUna lettera è stata rivelata: {lettere_parola_segreta[0]}");
        parola_con_trattini[0] = lettere_parola_segreta[0];
        ind = 0;
    }
    else if (ind == 2)
    {
        int carattere = random.Next(1, 27);
        
        Console.WriteLine("Hai acquistato un indizio!" +
            $"\nUna lettera è stata rivelata: {lettere_alfabeto[carattere]}");

        lettere_provate[n_prove++] = lettere_alfabeto[carattere];

        if (lettere_parola_segreta.Contains(lettere_alfabeto[carattere]))
        {
            for (int i = 0; i < lettere_parola_segreta.Length; i++)
            {
                if (lettere_parola_segreta[i] == lettere_alfabeto[carattere])
                {
                    contains = true;
                    parola_con_trattini[i] = lettere_alfabeto[carattere];
                }
            }
            if (contains == true)
            {
                Console.WriteLine($"La lettera {lettere_alfabeto[carattere]} è presente nella parola segreta!");
            }
        }
        else
        {
            Console.WriteLine($"Purtroppo, la lettera {lettere_alfabeto[carattere]} non è presente nella parola segreta." +
                    "\nNon arrenderti, continua a provare!");
        }
        ind = 0;
    }
    Console.WriteLine();
    Console.WriteLine("Adesso indovina la parola nascosta una lettera alla volta!");

    while (!game_over)
    {
        Console.WriteLine(new string(parola_con_trattini));
        Console.WriteLine($"le lettere provate: {new string(lettere_provate)}");
        Console.WriteLine($"Tentativi rimasti: {tentativi_max - tentativi}");
        Console.WriteLine("Inserisci una lettera:");
        lettera = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (lettere_provate.Contains(lettera))
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
            tentativi++;
        }

        lettere_provate[n_prove++] = lettera;

        if (!new string(parola_con_trattini).Contains("_"))
        {
            game_over = true;
            return true;
        }
        else if (tentativi >= tentativi_max)
        {
            Console.WriteLine($"Hai esaurito i tentativi. La parola segreta era: {p}");
            game_over = true;
            return false;
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
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Va bene! Continui a indovinare le lettere!");
            }
        }
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

int indizi(ref int m)
{
    bool r1 = false, r2 = false;
    int sug = 0;

    Console.WriteLine();

    Console.WriteLine("Per rendere l'esperienza ancora più avvincente, hai a disposizione alcune funzioni speciali che possono aiutarti a risolvere il mistero. Ogni funzione può essere utilizzata con un piccolo sacrificio di monete, quindi scegli saggiamente quando usarle! Ecco le opzioni che hai a disposizione:" +
    "\n1. Dizionario - Scopri la prima lettera della parola." +
    "\n2. Sorgente - Ottieni una lettera casuale e ti dirà se è presente nella parola.");
    Console.WriteLine();

    Console.WriteLine("Per aiutarti a risolvere il mistero, puoi acquistare un indizio! (si/no)"); 

    while (!r1)
    {
        string scelta = Console.ReadLine().ToLower();
        if (scelta == "si")
        {
            Console.WriteLine("Perfetto! Hai deciso di acquistare un indizio. Ora, scegli quale opzione vuoi utilizzare:" +
                "\n1. Dizionario – 3 monete" +
                "\n2. Sorgente - 2 monete");

            r1 = true;

            while (!r2)
            {
                scelta = Console.ReadLine().ToLower();

                if (scelta == "1" || scelta == "indizio")
                {
                    m -= 3;
                    sug = 1;
                    r2 = true;
                }
                else if (scelta == "2" || scelta == "sorgente")
                {
                    m -= 2;
                    sug = 2;
                    r2 = true;
                }
                else
                {
                    Console.WriteLine("Errore! La risposta non valida" +
                            "\nPerfavore inserisci la risposta valida");
                }
            }
        }
        else if (scelta == "no")
        {
            Console.WriteLine("Hai deciso di non acquistare il suggerimento. La sfida continua senza aiuti esterni. Buona fortuna!");
            r1 = true;
        }
        else
        {
            Console.WriteLine("Errore! La risposta non valida" +
                            "\nPerfavore inserisci la risposta valida");
        }
    }

    return sug;
}

bool gioco(ref int posizione_non_indovinate, ref int posizione_indovinate, ref int posizione_parole_uscite, ref int monete, ref string[] parole_indovinate, ref string[] parole_non_indovinate, ref string[] parole_uscite)
{
    string[] parola_scelte = new string[20];
    string parola, parola_segreta, ris;

    int num_tentativi = 0, nm = 0;
    string filePath = tema_scelto();

    bool risposta = false;

    string[] lines = File.ReadAllLines(filePath);
    parole(lines, ref parola_scelte, ref num_tentativi, ref nm);
    parola = parola_casuale(parola_scelte, parole_uscite);
    parola_segreta = parola_da_indovina(parola);

    Console.WriteLine();
    Console.WriteLine($"il numero delle monete: {monete}");

    int indizio = indizi(ref monete);
    if(monete < 0)
    {
        if(indizio == 1)
        {
            monete += 3;
        }
        else
        {
            monete += 2;
        }
        indizio = 0;
        Console.WriteLine("Ops! Non hai abbastanza monete per acquistare un indizio.");
    }

    parole_uscite[posizione_parole_uscite++] = parola_segreta;

    if (indovina(parola_segreta, num_tentativi, indizio) == true)
    {
        monete += nm;
        Console.WriteLine("Congratulazioni! Hai indovinato la parola!");
        Console.WriteLine($"Ricevi {nm} monete!");
        parole_indovinate[posizione_indovinate++] = parola_segreta;
    }
    else
    {
        parole_non_indovinate[posizione_non_indovinate++] = parola_segreta;
    }

    while (!risposta)
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
                    Console.Write($"{parole_indovinate[i]} ");
                }
            }

            Console.WriteLine();

            Console.Write("Le parole non indovinate sono: ");
            for (int i = 0; i < parole_non_indovinate.Length; i++)
            {
                if (parole_non_indovinate[i] != null)
                {
                    Console.Write($"{parole_non_indovinate[i]} ");
                }
            }

            Console.WriteLine();

            return false;
        }
        else
        {
            Console.WriteLine("Errore! La risposta non valida" +
                    "\nPerfavore inserisci la risposta valida");
        }
    }
    return false;
}

string parola_casuale(string[] parole, string[] parole_uscite)
{
    int posizione = random.Next(0, 20);
    do
    {
        posizione = random.Next(0, 20);
    }
    while(parole_uscite.Contains(parole[posizione]));
    return parole[posizione];
}

int p_pn = 0, p_p = 0, p_pu = 0, monete = 10;
bool gameover = true;
string[] p = new string[60];
string[] pn = new string[60];
string[] pu = new string[60];

while (gameover == true)
{
    gameover = gioco(ref p_pn, ref p_p, ref p_pu, ref monete, ref p, ref pn, ref pu);
}
