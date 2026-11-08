using Xunit;
using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class TransacaoTests
{
    [Fact]
    public void ComprarBitcoin_DeveAtualizarSaldos_QuandoSaldoBRLSuficiente()
    {
        var carteira = new Carteira(500000m); // 500 mil reais
        carteira.ComprarBitcoin(250000m, 500000m); // Compra com 250k a cotação de 500k = 0.5 BTC

        Assert.Equal(250000m, carteira.SaldoBRL);
        Assert.Equal(0.5m, carteira.SaldoBTC);
    }

    [Fact]
    public void VenderBitcoin_DeveLancarExcecao_QuandoSaldoBTCInsuficiente()
    {
        var carteira = new Carteira(1000m);
        Assert.Throws<InvalidOperationException>(() => carteira.VenderBitcoin(1m, 500000m));
    }
}