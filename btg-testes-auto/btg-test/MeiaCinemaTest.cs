using btg_testes_auto;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Theory]
        [InlineData(true, false, false, false)]  // Estudante
        [InlineData(false, true, false, false)]  // Doador de sangue
        [InlineData(false, false, true, true)]   // Trabalhador da prefeitura com contrato
        public void VerificarMeiaCinema_RecebeEstudanteOuDoadorOuTrabalhadorComContrato_RetornaVerdadeiro(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool result = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(false, false, true, false)] // Trabalhador da prefeitura sem contrato
        [InlineData(false, false, false, false)] // Nenhum benefício
        public void VerificarMeiaCinema_RecebeTrabalhadorPrefeituraSemContratoOuSemBeneficio_RetornaFalso(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool result = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(result);
        }
    }
}

