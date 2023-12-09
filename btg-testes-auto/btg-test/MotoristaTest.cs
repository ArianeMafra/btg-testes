using btg_testes_auto;

namespace btg_test
{
    public class MotoristaTest
    {
        [Fact]
        public void EncontrarMotoristas_RecebeListaVazia_RetornaException()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>();
            Motorista motorista = new Motorista();

            // Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Throws<Exception>(resultado);
        }

        [Fact]
        public void EncontrarMotoristas_RecebeListaDePessoasMenoresDe18_RetornaException()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Ana", Idade = 17, PossuiHabilitaçãoB = false},
                new Pessoa { Nome = "Pedro", Idade = 15, PossuiHabilitaçãoB = false},
                new Pessoa { Nome = "João", Idade = 16, PossuiHabilitaçãoB = false},

            };
            Motorista motorista = new Motorista();

            // Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Throws<Exception>(resultado);
        }

        [Fact]
        public void EncontrarMotoristas_RecebeListaDePessoasMaioresDe18SemHabilitacao_RetornaException()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = false},
                new Pessoa { Nome = "Pedro", Idade = 20, PossuiHabilitaçãoB = false},
                new Pessoa { Nome = "João", Idade = 35, PossuiHabilitaçãoB = false},

            };
            Motorista motorista = new Motorista();

            // Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Throws<Exception>(resultado);
        }

        [Fact]
        public void EncontrarMotoristas_RecebeListaDePessoasMaioresDe18ComHabilitacao_RetornaNomeMotoristas()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = true},
                new Pessoa { Nome = "Pedro", Idade = 20, PossuiHabilitaçãoB = true},

            };
            Motorista motorista = new Motorista();

            // Act
            string resultado = motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Contains("Uhuu! Os motorista são", resultado);
            Assert.Contains("Ana", resultado);
            Assert.Contains("Pedro", resultado);
        }

    }
}