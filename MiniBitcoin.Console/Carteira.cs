namespace MiniBitcoin.Console;

public class Carteira
{
    public decimal SaldoBRL { get; protected set; }
    public decimal SaldoBTC { get; protected set; }

    public Carteira(decimal saldoInicialBRL = 0)
    {
        if (saldoInicialBRL < 0) throw new ArgumentException("Saldo inicial não pode ser negativo.");
        SaldoBRL = saldoInicialBRL;
        SaldoBTC = 0m;
    }

    public virtual void ComprarBitcoin(decimal valorBRL, decimal cotacaoAtualBTC)
    {
        if (valorBRL <= 0) throw new ArgumentException("O valor de compra deve ser maior que zero.");
        if (valorBRL > SaldoBRL) throw new InvalidOperationException("Saldo em BRL insuficiente para compra.");
        if (cotacaoAtualBTC <= 0) throw new ArgumentException("A cotação do BTC deve ser maior que zero.");

        decimal btcComprado = valorBRL / cotacaoAtualBTC;
        SaldoBRL -= valorBRL;
        SaldoBTC += btcComprado;
    }

    public virtual void VenderBitcoin(decimal quantidadeBTC, decimal cotacaoAtualBTC)
    {
        if (quantidadeBTC <= 0) throw new ArgumentException("A quantidade de venda deve ser maior que zero.");
        if (quantidadeBTC > SaldoBTC) throw new InvalidOperationException("Saldo em BTC insuficiente para venda.");
        if (cotacaoAtualBTC <= 0) throw new ArgumentException("A cotação do BTC deve ser maior que zero.");

        decimal valorBRL = quantidadeBTC * cotacaoAtualBTC;
        SaldoBTC -= quantidadeBTC;
        SaldoBRL += valorBRL;
    }
}