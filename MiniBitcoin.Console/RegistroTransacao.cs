namespace MiniBitcoin.Console;

public class RegistroTransacao
{
    public DateTime Data { get; } = DateTime.Now;
    public string Tipo { get; }
    public decimal ValorBRL { get; }
    public decimal QuantidadeBTC { get; }
    public decimal CotacaoAplicada { get; }

    public RegistroTransacao(string tipo, decimal valorBRL, decimal quantidadeBTC, decimal cotacao)
    {
        Tipo = tipo; ValorBRL = valorBRL; QuantidadeBTC = quantidadeBTC; CotacaoAplicada = cotacao;
    }
}