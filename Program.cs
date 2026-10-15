using OOP_Gyakorlas_Dolgozatra;
List<Konyvek> konyv = new List<Konyvek>();

if (File.Exists("konyvek.txt"))
{
    foreach (string sor in File.ReadAllLines("konyvek.txt"))
    {
        if (string.IsNullOrWhiteSpace(sor)) continue;
        string[] adatok = sor.Split(";");
        if (adatok.Count() < 5) continue;
        if (int.TryParse(adatok[3], out int ar) && int.TryParse(adatok[4], out int keszlet))
        {
            Konyvek aktualis = new Konyvek(adatok[0], adatok[1], adatok[2], ar, keszlet);
            konyv.Add(aktualis);
        }
        else
        {
            Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú sor adata hibás, átugorva!");
        }

    }
}
else
{
    Console.WriteLine("A konyv.txt fájl nem található.");
    return;
}
Console.WriteLine("\n=== BEOLVASOTT KÖNYVEK ===");
foreach (Konyvek konyvek in konyv) Console.WriteLine(konyvek);
Console.WriteLine($"\nRegisztrált könyvek száma a rendszerben: {Konyvek.OsszesRegisztraltKonyv} db");
double rKeszlet = 0;
foreach (Konyvek k in konyv) rKeszlet +=k.RaktarKeszlet*k.Ar;
Console.WriteLine($"A raktárkészlet teljes bruttó értéke (5% ÁFA-val): {Penzugy.BruttoArSzamitas(rKeszlet)} ");
Console.WriteLine($"Legolcsóbb könyv: {konyv.MinBy(k => k.Ar)?.Cim} ({konyv.MinBy(k => k.Ar)?.Ar} Ft)");