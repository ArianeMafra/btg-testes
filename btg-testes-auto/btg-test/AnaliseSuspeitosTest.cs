using btg_testes_auto;

namespace btg_test
{
    public class AnaliseSuspeitosTest
    {
        [Theory]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, false, false, false, false)]
        [InlineData(false, true, false, false, false)]
        [InlineData(false, false, true, false, false)]
        [InlineData(false, false, false, true, false)]
        [InlineData(false, false, false, false, true)]
        public void ExecutarQuestionarioSuspeito_RecebeZeroOuUmaRespostaPositiva_RetornaInocente
            (bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Inocente", resultado);
        }

        [Theory]
        [InlineData(true, true, false, false, false)]
        [InlineData(false, true, true, false, false)]
        [InlineData(false, false, true, true, false)]
        [InlineData(false, false, false, true, true)]
        [InlineData(true, false, false, false, true)]
        [InlineData(true, false, true, false, false)]
        [InlineData(true, false, false, true, false)]

        public void ExecutarQuestionarioSuspeito_RecebeDuasRespostasPositivas_RetornaSuspeita
            (bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Suspeita", resultado);
        }

        [Theory]
        [InlineData(true, true, true, false, false)]
        [InlineData(false, true, true, true, false)]
        [InlineData(false, false, true, true, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]

        public void ExecutarQuestionarioSuspeito_RecebeTresOuQuatroRespostasPositivas_RetornaCumplice
            (bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Cúmplice", resultado);
        }

        [Theory]
        [InlineData(true, true, true, true, true)]

        public void ExecutarQuestionarioSuspeito_RecebeCincoRespostasPositivas_RetornaAssassino
            (bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Assassino", resultado);
        }
    }
}

