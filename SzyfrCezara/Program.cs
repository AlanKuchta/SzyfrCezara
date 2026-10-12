using System;
using System.Text;

class SzyfrCezaraPL
{
    private const string Alfabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

    public static string Szyfruj(string tekst, int przesuniecie)
    {
        StringBuilder wynik = new StringBuilder();
        int dlugosc = Alfabet.Length;
        string tekstLower = tekst.ToLower();

        for (int i = 0; i < tekst.Length; i++)
        {
            char znak = tekstLower[i];
            int indeks = Alfabet.IndexOf(znak);

            if (indeks >= 0)
            {
                int nowyIndeks = ((indeks + przesuniecie) % dlugosc + dlugosc) % dlugosc;
                char nowyZnak = Alfabet[nowyIndeks];

                wynik.Append(char.IsUpper(tekst[i])
                    ? char.ToUpper(nowyZnak)
                    : nowyZnak);
            }
            else
            {
                wynik.Append(tekst[i]);
            }
        }

        return wynik.ToString();
    }

    public static string Deszyfruj(string tekst, int przesuniecie)
    {
        return Szyfruj(tekst, -przesuniecie);
    }

    static void Main()
    {
        string tekst = "gruszka banan jabłko";
        int klucz = 3;

        string zaszyfrowany = Szyfruj(tekst, klucz);
        string odszyfrowany = Deszyfruj(zaszyfrowany, klucz);

        Console.WriteLine($"Oryginał:     {tekst}");
        Console.WriteLine($"Zaszyfrowany: {zaszyfrowany}");
        Console.WriteLine($"Odszyfrowany: {odszyfrowany}");
    }
}