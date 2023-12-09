using btg_testes_auto;

namespace btg_test
{
    public class LucroTest
    {
        [Fact]
        public void Calcular_ValorDaCompra19_RetornaValorDaVendaComLucroDe45Porcento()
        {
            //Arrange
            decimal valorProduto = 19;
            Lucro lucro = new Lucro();

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            //Assert
            Assert.Equal((decimal)27.55, resultado);
        }

        [Fact]
        public void Calcular_ValorDaCompra21_RetornaValorDaVendaComLucroDe30Porcento()
        {
            //Arrange
            decimal valorProduto = 21;
            Lucro lucro = new Lucro();

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            //Assert
            Assert.Equal((decimal)27.3, resultado);
        }

        [Fact]
        public void Calcular_ValorDaCompraZero_RetornaZero()
        {
            //Arrange
            decimal valorProduto = 0;
            Lucro lucro = new Lucro();

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            //Assert
            Assert.Equal(0, resultado);
        }

    }
}