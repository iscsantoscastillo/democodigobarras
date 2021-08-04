using Telecomm.Helper;
using Telecomm.Model;
using Xunit;

namespace UnitTesting.Tests
{
    public class UtilTestingShould
    {
        [Theory]
        [InlineData("733607112023", "C00017336071120230376785")]
        public void ValidateValidStringBase97TelecommBanco(string referencia, string expected) {
            //Arrange
            Base97TelecommBanco base97 = new Base97TelecommBanco();

            base97.Convenio = "C0001";            
            base97.Referencia = referencia;
            base97.Fecha = "05/01/2021";
            base97.Importe = "450";

            //Act
            Util.CalcularBase97TelecommBanco(base97);
            //Asert
            //"C00017336071120230376785"
            Assert.Equal(expected, base97.CadenaFinal);

        }

        [Fact]
        public void ValidateValidStringBase97TelecommBanco2() {
            //Arrange
            Base97TelecommBanco base97 = new Base97TelecommBanco();

            base97.Convenio = "C0001";
            base97.Referencia = "733607112023";
            base97.Fecha = "05/01/2021";
            base97.Importe = "450";

            string expected = "C00017336071120230376785";

            //Act
            Util.CalcularBase97TelecommBanco(base97);
            
            //Asert            
            Assert.Equal(expected, base97.CadenaFinal);
        }

        
        [Fact]
        public void ValidateValidStringBase97TelecommBanco3()
        {
            //Arrange
            Base97TelecommBanco base97 = new Base97TelecommBanco();

            base97.Convenio = "C0001";
            base97.Referencia = "SL202100020903";
            base97.Fecha = "31/07/2021";
            base97.Importe = "189.90";

            string expected = "C0001852021000209030588578";

            //Act
            Util.CalcularBase97TelecommBanco(base97);

            //Asert            
            Assert.Equal(expected, base97.CadenaFinal);
        }
    }
}
