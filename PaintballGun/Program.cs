namespace PaintballGun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Liczba kulek");
            int magazineSize = ReadInt(16, "Pojemność magazynka");

            Console.Write($"Załadowany [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

            while (true)
            {
                Console.WriteLine($"Kulki: {gun.Balls}, załadowano: {gun.BallsLoaded}");
                if (gun.IsEmpty())
                    Console.WriteLine("OUT OF AMMO");

                Console.WriteLine("[spacja] strzał, [p]rzeładowanie, [+] dodaj amunicję, [k]oniec");
                char keyChar = Console.ReadKey(true).KeyChar;

                if (keyChar == ' ') Console.WriteLine($"Próba strzału: {gun.Shoot()}");
                else if (keyChar == 'p') gun.Reload();
                else if (keyChar == '+') gun.Balls += gun.MagazineSize;
                else if (keyChar == 'k') return;
            }
        }

        private static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();

            if (int.TryParse(line, out int intValue))
            {
                Console.WriteLine("\t użycie wartości " + intValue);
                return intValue;
            }
            else
            {
                Console.WriteLine("\t użycie wartości domyślnej " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }
}
