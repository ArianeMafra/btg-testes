using btg_testes_auto;
using FluentAssertions;

namespace btg_test
{
    public class VooTest
    {
        [Fact]
        public void ExibeInformacoesVoo_RecebeUmVoo_RetornaAsInformacoes()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));

            // Act
            string resultado = voo.ExibeInformacoesVoo();

            // Assert
            Assert.Contains("Aeronave Boing 767 registrada sob voo de número 11 para o dia e hora 11/09/2001 07:00:00", resultado);
        }

        [Fact]
        public void ProximoLivre_VerificaComNenhumAssentoDisponivel_RetornaZero()
        {
            // Arrange           
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));

            // Act
            int resultado = voo.ProximoLivre();

            // Assert
            resultado.Should().Be(0);
        }

        [Fact]
        public void ProximoLivre_VerificaComAssentosDisponiveis_RetornaProximoAssentoLivre()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));
            voo.OcupaAssento(0);

            // Act
            var resultado = voo.ProximoLivre();

            // Assert
            resultado.Should().BeGreaterThan(0);
        }

        [Fact]
        public void AssentoDisponivel_RecebeAssentoDisponivel_RetornaVerdadeiro()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));
            int posicao = 10;

            // Act
            bool resultado = voo.AssentoDisponivel(posicao);

            // Assert
            resultado.Should().BeTrue();
        }

        [Fact]
        public void AssentoDisponivel_RecebeAssentoIndisponivel_RetornaFalso()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));
            voo.OcupaAssento(10);
            int posicao = 10;

            // Act
            bool resultado = voo.AssentoDisponivel(posicao);

            // Assert
            resultado.Should().BeFalse();
        }

        [Fact]
        public void OcupaAssento_RecebeAssentoDisponivel_RetornaVerdadeiro()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));           
            int posicao = 10;

            // Act
            bool resultado = voo.OcupaAssento(posicao);

            // Assert
            resultado.Should().BeTrue();
        }

        [Fact]
        public void OcupaAssento_RecebeAssentoIndisponivel_RetornaFalso()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));
            voo.OcupaAssento(10);
            int posicao = 10;

            // Act
            bool resultado = voo.OcupaAssento(posicao);

            // Assert
            resultado.Should().BeFalse();
        }

        [Fact]
        public void QuantidadeVagasDisponivel_RecebeTresAssentosOcupados_RetornaNoventaESete()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));
            voo.OcupaAssento(10);
            voo.OcupaAssento(15);
            voo.OcupaAssento(20);

            // Act
            int resultado = voo.QuantidadeVagasDisponivel();

            // Assert
            Assert.Equal(97, resultado);
        }

        [Fact]
        public void QuantidadeVagasDisponivel_RecebeNenhumAssentoOcupado_RetornaCem()
        {
            // Arrange
            Voo voo = new Voo("Boing 767", "11", new DateTime(2001, 09, 11, 07, 00, 0));            

            // Act
            int resultado = voo.QuantidadeVagasDisponivel();

            // Assert
            Assert.Equal(100, resultado);
        }

    }
}
