using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypotheekBerekening
{
    public class Hypotheek
    {
        public void HypotheekBerekening()
        {
            HypotheekCalculator calculator = new HypotheekCalculator();

            // Voorbeeld: Berekening starten met gebruikersinput
            Console.Write("Voer je jaarinkomen in: ");
            double jaarinkomen = double.Parse(Console.ReadLine());

            Console.Write("Heb je een studieschuld? (ja/nee): ");
            bool heeftStudieschuld = Console.ReadLine().ToLower() == "ja";

            Console.Write("Kies een rentevaste periode (1, 5, 10, 20, 30 jaar): ");
            int rentevastePeriode = int.Parse(Console.ReadLine());

            double rentePercentage = calculator.GetRentePercentage(rentevastePeriode);
            if (rentePercentage == 0)
            {
                Console.WriteLine("Ongeldige rentevaste periode.");
                return;
            }

            double maximaalTeLenen = calculator.BerekenMaximaalLening(jaarinkomen, heeftStudieschuld);
            Console.WriteLine($"Maximaal te lenen bedrag: €{maximaalTeLenen}");

            double maandlasten = calculator.BerekenMaandlasten(maximaalTeLenen, rentePercentage, rentevastePeriode);
            Console.WriteLine($"Maandelijkse hypotheeklasten: €{maandlasten}");

            double totaleBetaling = calculator.BerekenTotaleBetaling(maandlasten, rentevastePeriode);
            Console.WriteLine($"Totale betaling na {rentevastePeriode} jaar: €{totaleBetaling}");

            // Toon aflossingsplan (optioneel)
            calculator.ToonAflossingsplan(maximaalTeLenen, rentePercentage, rentevastePeriode, maandlasten);
        }
    }

}
