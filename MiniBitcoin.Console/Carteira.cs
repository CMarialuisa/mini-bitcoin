namespace MiniBitcoin.Console;

public class Carteira
{
    public decimal SaldoBRL { get; protected set; }
    public decimal SaldoBTC { get; protected set; }

    public Carteira(decimal saldoInicialBRL = 0)
    {
        if (saldoInicialBRL < 0) 
            throw new ArgumentException("O saldo inicial em BRL não pode ser negativo.");
            
        SaldoBRL = saldoInicialBRL;
        SaldoBTC = 0m;
    }
}