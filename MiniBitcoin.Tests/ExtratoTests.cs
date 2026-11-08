using Xunit;
using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class ExtratoTests
{
    [Fact]
    public void PatrimonioTotal_DeveSerCalculadoCorretamente_ComBaseNaCotacao()
    {
        var carteira = new ExtratoCarteira(10000m);
        carteira.ComprarBitcoin(5000m, 250000m); // Saldo: 5000 BRL + 0.02 BTC
        
        // Se a cotação subir para 300000
        decimal patrimonio = carteira.CalcularPatrimonioTotalEmBRL(300000m); 
        // 5000 + (0.02 * 300000) = 5000 + 6000 = 11000
        
        Assert.Equal(11000m, patrimonio);
        Assert.Single(carteira.Historico);
    }
}