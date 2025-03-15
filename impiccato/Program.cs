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

void parole(string[] p, ref string[] pd)
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
            b += 20;
        }
        else if (d == "Normale" || d == "normale" || d == "2")
        {
            a = 20;
            b = 40;
        }
        else if (d == "Difficile" || d == "difficile" || d == "3")
        {
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
    string parola_con_trattino;
    if (p.Contains("Facile"))
    {
        parola_con_trattino = p.Substring(6);
    }
    else if (p.Contains("Normale"))
    {
        parola_con_trattino = p.Substring(7);
    }
    else
    {
        parola_con_trattino = p.Substring(9);
    }
    return parola_con_trattino.ToLower();
}

bool indovina(string p)
{
    Console.WriteLine("Adesso iniziamo a indovinare!");
    string parola_con_trattini = parola_da_indovina(p);
    return false;
}

string parola_casuale(string[] parole)
{
    int posizione = random.Next(0, 21);
    return parole[posizione];
}

string[] parole_scelte = new string[20];
string parola;

string filePath = tema_scelto();
if (filePath.Contains("Errore"))
{
    Console.WriteLine(filePath);
}
else
{
    string[] lines = File.ReadAllLines(filePath);
    parole(lines, ref parole_scelte);
    parola = parola_casuale(parole_scelte);
}