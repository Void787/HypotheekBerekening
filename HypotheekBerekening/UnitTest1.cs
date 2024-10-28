namespace HypotheekBerekening
{
    public class UnitTest1
    {
        private readonly HypotheekCalculator _calculator;
        private readonly Hypotheek hypotheek;

        public UnitTest1()
        {
            _calculator = new HypotheekCalculator();
            hypotheek = new Hypotheek();
        }

        [Fact]
        public void BerekenMaximaalLening_ZonderStudieschuld_CorrecteWaarde()
        {
            // Arrange
            double jaarinkomen = 50000;
            bool heeftStudieschuld = false;

            // Act
            double resultaat = _calculator.BerekenMaximaalLening(jaarinkomen, heeftStudieschuld);

            // Assert
            Assert.Equal(225000, resultaat);
        }

        [Fact]
        public void BerekenMaximaalLening_MetStudieschuld_CorrecteWaarde()
        {
            // Arrange
            double jaarinkomen = 50000;
            bool heeftStudieschuld = true;

            // Act
            double resultaat = _calculator.BerekenMaximaalLening(jaarinkomen, heeftStudieschuld);

            // Assert
            Assert.Equal(168750, resultaat); // 75% van 225000
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 3)]
        [InlineData(10, 3.5)]
        [InlineData(20, 4.5)]
        [InlineData(30, 5)]
        public void GetRentePercentage_VoorVerschillendePeriodes_CorrecteWaarde(int periode, double verwachtPercentage)
        {
            // Act
            double resultaat = _calculator.GetRentePercentage(periode);

            // Assert
            Assert.Equal(verwachtPercentage, resultaat);
        }

        [Fact]
        public void GetRentePercentage_OngeldigePeriode_ReturnsZero()
        {
            // Arrange
            int ongeldigPeriode = 15;

            // Act
            double resultaat = _calculator.GetRentePercentage(ongeldigPeriode);

            // Assert
            Assert.Equal(0, resultaat);
        }

        [Fact]
        public void BerekenMaandlasten_CorrecteBerekening()
        {
            // Arrange
            double lening = 225000;
            double rente = 3.5; // 10 jaar rente
            int jaren = 10;

            // Act
            double maandlasten = _calculator.BerekenMaandlasten(lening, rente, jaren);

            // Assert
            Assert.Equal(2224.93, maandlasten, 2); // Maandlasten tot op 2 decimalen nauwkeurig
        }

        [Fact]
        public void IsAardbevingsgebied_PostcodeInAardbevingsgebied_ReturnsTrue()
        {
            // Arrange
            string postcode = "9679";

            // Act
            bool resultaat = _calculator.IsAardbevingsgebied(postcode);

            // Assert
            Assert.True(resultaat);
        }

        [Fact]
        public void IsAardbevingsgebied_PostcodeNietInAardbevingsgebied_ReturnsFalse()
        {
            // Arrange
            string postcode = "1234";

            // Act
            bool resultaat = _calculator.IsAardbevingsgebied(postcode);

            // Assert
            Assert.False(resultaat);
        }

        [Fact]
        public void BerekenTotaleBetaling_CorrecteWaarde()
        {
            // Arrange
            double maandlasten = 2222.51;
            int jaren = 10;

            // Act
            double totaleBetaling = _calculator.BerekenTotaleBetaling(maandlasten, jaren);

            // Assert
            Assert.Equal(266701.2, totaleBetaling, 2); // Totale betaling tot op 2 decimalen nauwkeurig
        }

        [Fact]
        public void TestHyphoteek()
        {
            hypotheek.HypotheekBerekening();

            
        }
    }
}