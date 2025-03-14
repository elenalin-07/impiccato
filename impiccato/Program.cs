Console.WriteLine("Benvenuto nel Gioco dell'Impiccato!");
Console.WriteLine("In questo gioco, il tuo obiettivo è indovinare una parola segreta, lettera per lettera, prima che l'impiccato venga completato.");
Console.WriteLine("Ogni volta che indovini una lettera correttamente, la parola si aggiornerà. Se invece sbagli, una parte dell'impiccato apparirà. Hai un numero limitato di tentativi, quindi fai attenzione!");
Console.WriteLine("Sei pronto a iniziare? Scegli una tema per la parola!" +
    "\n1. Animale" +
    "\n2. Oggetto" +
    "\n3. Paese" +
    "\n4. Piante");

string tema = Console.ReadLine();
string filePath;

if (tema != null)
{
    if (tema == "Animale" || tema == "animale")
    {
        filePath = "impiccato_animale.txt";
    }
    else if (tema == "Oggetto" || tema == "oggetto")
    {
        filePath = "impiccato_oggetto.txt";
    }
    else if (tema == "Paese" || tema == "paese")
    {
        filePath = "impiccato_paese.txt";
    }
    else if (tema == "Piante" || tema == "piante")
    {
        filePath = "impiccato_piante.txt";
    }
    else
    {
        Console.WriteLine("Errore! La tema non valida");
    }
}
else
{
    Console.WriteLine("Errore! Perfavore inserisci la tema valida");
}