namespace MiniBitcoin.Console;

public class ExtratoCarteira : Carteira
{
    private readonly List<RegistroTransacao> _historico = new();
    public IReadOnlyCollection<RegistroTransacao> Historico => _historico.AsReadOnly();

    public ExtratoCarteira(decimal saldoInicialBRL = 0) : base(saldoInicialBRL) { }

    public override void ComprarBitcoin(decimal valorBRL, decimal cotacaoAtualBTC)
    {
        base.ComprarBitcoin(valorBRL, cotacaoAtualBTC);
        decimal btcComprado = valorBRL / cotacaoAtualBTC;
        _historico.Add(new RegistroTransacao("COMPRA", valorBRL, btcComprado, cotacaoAtualBTC));
    }

    public override void VenderBitcoin(decimal quantidadeBTC, decimal cotacaoAtualBTC)
    {
        base.VenderBitcoin(quantidadeBTC, cotacaoAtualBTC);
        decimal valorBRL = quantidadeBTC * cotacaoAtualBTC;
        _historico.Add(new RegistroTransacao("VENDA", valorBRL, quantidadeBTC, cotacaoAtualBTC));
    }

    public decimal CalcularPatrimonioTotalEmBRL(decimal cotacaoAtualBTC)
    {
        return SaldoBRL + (SaldoBTC * cotacaoAtualBTC);
    }
}