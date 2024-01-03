using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTests
{
    private CalculadoraImp _calc;

    public CalculadoraTests()
    {
        _calc = new CalculadoraImp();
    }

    [Fact] // essa declaração significa que este é um cenário de testes e deve ser validado
    public void DeveSomar5com10ERetornar15()
    {
        // Arrange -> montar um cenário
        //
        int num1 = 5;
        int num2 = 10;

        // Act -> definir uma ação para o cenário criado
        //
        int resultado = _calc.Somar(num1, num2);

        // Assert -> validar se o resultado chegou no esperado
        //
        Assert.Equal(15, resultado); // -> .Equal("Valor esperado", "Valor a ser comparado")

        // Após definido o tipo de teste no terminal da CalculadoraTestes use o comando: dotnet test
        // O terminal te retornara o resultado do teste descrito acima.
    }

    [Fact]
    public void DeveSomar10com10ERetornar20()
    {
        // Arrange
        int num1 = 10;
        int num2 = 10;

        // Act
        int resultado = _calc.Somar(num1, num2);

        // Assert
        Assert.Equal(20, resultado);

    }

     [Fact]
     public void DeveVerificarSe4EhParERetornarVerdadeiro()
     {
         // Arrange
         int numero = 4;

         // Act
         bool resultado = _calc.EhPar(numero);

         // Assert
         // Assert.Equal(true, resultado); -> poderia ser validado dessa forma mas não é das melhores formas, outro jeito é da seguinte maneira:

         Assert.True(resultado);

     }

    // [Theory]            //-> Theory serve para caso eu queria que meu validador coloque a prova mais de um valor
    // [InlineData(2)]     //-> InlineData servirá como meu arrange,no caso vou colocar em cenário tudo que estiver aqui dentro
    // [InlineData(4)]
    // [InlineData(6)]
    // [InlineData(8)]
    // [InlineData(10)]
    // public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int numero)
    // {

    //     // Act
    //     bool resultado = _calc.EhPar(numero);

    //     // Assert
    //     Assert.True(resultado);

    // }

    [Theory]            
    [InlineData(new int[] { 2, 4 })]        //-> é possivel incluirmos dentro de uma lista os valores desejados para que poupe repetição no código
    [InlineData(new int[] { 6, 8, 10 })]
    public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int[] numeros)
    {

        // Act / Assert

        // foreach (var item in numeros)
        // {
        //     Assert.True(_calc.EhPar(item));
        // }

        // Essa pode ser uma das maneiras de fazer essa validação, mas existe outra forma:
        
        Assert.All(numeros, num => Assert.True(_calc.EhPar(num)));
        // Assert.All -> Realiza uma validação para todos elementos da lista
        //.all("Lista desejada", "Ação a ser realizada")
    }
}