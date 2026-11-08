using Xunit;
using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class CarteiraTests
{
    [Fact]
    public void CriarCarteira_DeveLancarExcecao_QuandoSaldoInicialNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Carteira(-100m));
    }

    [Fact]
    public void CriarCarteira_DeveIniciarComSaldosCorretos_QuandoValorValido()
    {
        var carteira = new Carteira(1000m);
        Assert.Equal(1000m, carteira.SaldoBRL);
        Assert.Equal(0m, carteira.SaldoBTC);
    }
}