using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypotheekBerekening
{
    public class HypotheekCalculator
    {
        // Functie om het maximale te lenen bedrag te berekenen op basis van jaarinkomen
        public double BerekenMaximaalLening(double jaarinkomen, bool heeftStudieschuld)
        {
            double maximaalLening = jaarinkomen * 4.5;
            if (heeftStudieschuld)
            {
                maximaalLening *= 0.75; // Verminder lening met 25% door studieschuld
            }
            return maximaalLening;
        }

        // Functie om de maandelijkse hypotheeklasten te berekenen
        public double BerekenMaandlasten(double lening, double rente, int jaren)
        {
            double maandRente = rente / 100 / 12;
            int aantalMaanden = jaren * 12;
            return lening * maandRente / (1 - Math.Pow(1 + maandRente, -aantalMaanden));
        }

        // Functie om het rentepercentage op te halen op basis van de rentevaste periode
        public double GetRentePercentage(int periode)
        {
            switch (periode)
            {
                case 1:
                    return 2;
                case 5:
                    return 3;
                case 10:
                    return 3.5;
                case 20:
                    return 4.5;
                case 30:
                    return 5;
                default:
                    return 0; // Ongeldige invoer
            }
        }

        // Functie om te controleren of de postcode in een aardbevingsgebied valt
        public bool IsAardbevingsgebied(string postcode)
        {
            return postcode == "9679" || postcode == "9681" || postcode == "9682";
        }

        // Functie om het aflossingsplan te tonen
        public void ToonAflossingsplan(double lening, double rente, int jaren, double maandlasten)
        {
            double maandRente = rente / 100 / 12;
            double resterendeLening = lening;

            for (int maand = 1; maand <= jaren * 12; maand++)
            {
                double renteDeel = resterendeLening * maandRente;
                double aflossingDeel = maandlasten - renteDeel;
                resterendeLening -= aflossingDeel;

                Console.WriteLine($"Maand {maand}: Rente: €{renteDeel:F2}, Aflossing: €{aflossingDeel:F2}, Resterende lening: €{resterendeLening:F2}");
            }
        }

        // Functie om de totale betaling na de volledige looptijd te berekenen
        public double BerekenTotaleBetaling(double maandlasten, int jaren)
        {
            return maandlasten * 12 * jaren;
        }
    }
}
