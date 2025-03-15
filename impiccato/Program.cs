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

    string tema = Console.ReadLine();

    if (tema != null)
    {
        if (tema == "Animale" || tema == "animale" || tema == "1")
        {
            return "impiccato_animale.txt";
        }
        else if (tema == "Oggetto" || tema == "oggetto" || tema == "2")
        {
            return "impiccato_oggetto.txt";
        }
        else if (tema == "Paese" || tema == "paese" || tema == "3")
        {
            return "impiccato_paese.txt";
        }
        else if (tema == "Piante" || tema == "piante" || tema == "4")
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

void parole(string[] p, ref string[] pd, ref int n)
{
    int a = 0, b = 0, c = 0;
    Console.WriteLine("Scegli la difficoltà del gioco:" +
        "\n1. Facile - Parole corte, più tentativi disponibili." +
        "\n2. Normale - Parole di lunghezza media, tentativi moderati." +
        "\n3. Difficile - Parole lunghe, pochi tentativi.");
    string d = Console.ReadLine();

    if (d != null)
    {
        if (d == "Facile" || d == "facile" || d == "1")
        {
            n = 15;
            b += 20;
        }
        else if (d == "Normale" || d == "normale" || d == "2")
        {
            n = 10;
            a = 20;
            b = 40;
        }
        else if (d == "Difficile" || d == "difficile" || d == "3")
        {
            n = 5;
            a = 20;
            b = 60;
        }
        else
        {
            Console.WriteLine("Errore! La difficoltà sbagliata");
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
        parola = p.Substring(6);
    }
    else if (p.Contains("Normale"))
    {
        parola = p.Substring(7);
    }
    else
    {
        parola = p.Substring(9);
    }
    return parola.ToLower();
}

bool indovina(string p, ref int n)
{
    Console.WriteLine("Adesso indovina la parola nascosta una lettera alla volta!");
    string parola = parola_da_indovina(p);
    char[] parola_segreta = parola.ToCharArray();
    char[] parola_con_trattini = new char[parola_segreta.Length];
    for (int i = 0; i < parola_con_trattini.Length; i++)
    {
        parola_con_trattini[i] = '_';
    }

    char lettera = '0';
    int numero_lettere_indovinata = 0, a = 0;
    char[] lettere_indovinata = new char[parola_segreta.Length];

    while (numero_lettere_indovinata < parola_con_trattini.Length)
    {
        Console.WriteLine("Inserisci una lettera");
        lettera = Console.ReadKey().KeyChar;

        for (int i = 0; i < parola_segreta.Length; i++)
        {
            if (parola_segreta[i] == lettera)
            {
                numero_lettere_indovinata++;
                lettere_indovinata[a++] = lettera;
            }
            else
            {
                
            }
        }
    }
        
    return false;
}

string parola_casuale(string[] parole)
{
    int posizione = random.Next(0, 21);
    return parole[posizione];
}

string[] parole_scelte = new string[20];
string parola;

int num_tentativi = 0;
string filePath = tema_scelto();
if (filePath.Contains("Errore"))
{
    Console.WriteLine(filePath);
}
else
{
    string[] lines = File.ReadAllLines(filePath);
    parole(lines, ref parole_scelte, ref num_tentativi);
    parola = parola_casuale(parole_scelte);
}