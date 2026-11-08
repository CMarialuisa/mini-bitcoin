using MiniBitcoin.Console;

var carteira = new ExtratoCarteira(10000m); // Inicia com 10.000 BRL
decimal cotacaoAtual = 350000m; // Cotação simulada do BTC
bool executando = true;

while (executando)
{
    Console.WriteLine($"\n=== MINI BITCOIN WALLET ===");
    Console.WriteLine($"💰 Cotação Atual BTC: {cotacaoAtual:C}");
    Console.WriteLine($"1. Ver Saldos e Patrimônio");
    Console.WriteLine($"2. Comprar Bitcoin");
    Console.WriteLine($"3. Vender Bitcoin");
    Console.WriteLine($"4. Extrato de Transações");
    Console.WriteLine($"5. Atualizar Cotação (Simular Mercado)");
    Console.WriteLine($"0. Sair");
    Console.Write("Escolha: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine($"\nSaldo em BRL: {carteira.SaldoBRL:C}");
            Console.WriteLine($"Saldo em BTC: {carteira.SaldoBTC:F8} BTC");
            Console.WriteLine($"Patrimônio Total Estimado: {carteira.CalcularPatrimonioTotalEmBRL(cotacaoAtual):C}");
            break;

        case "2":
            Console.Write("Quantos Reais (BRL) deseja utilizar para comprar BTC? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valorCompra))
            {
                try { carteira.ComprarBitcoin(valorCompra, cotacaoAtual); Console.WriteLine("[SUCESSO] Compra efetuada."); }
                catch (Exception ex) { Console.WriteLine($"[ERRO] {ex.Message}"); }
            }
            break;

        case "3":
            Console.Write("Qual quantidade de BTC deseja vender? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal qtdVenda))
            {
                try { carteira.VenderBitcoin(qtdVenda, cotacaoAtual); Console.WriteLine("[SUCESSO] Venda efetuada."); }
                catch (Exception ex) { Console.WriteLine($"[ERRO] {ex.Message}"); }
            }
            break;

        case "4":
            Console.WriteLine("\n--- EXTRATO DE TRANSAÇÕES ---");
            if (carteira.Historico.Count == 0) Console.WriteLine("Nenhuma transação efetuada.");
            foreach (var t in carteira.Historico)
            {
                Console.WriteLine($"[{t.Data:g}] {t.Tipo}: {t.QuantidadeBTC:F8} BTC | Valor BRL: {t.ValorBRL:C} | Cotação: {t.CotacaoAplicada:C}");
            }
            break;

        case "5":
            Console.Write("Nova cotação do BTC em BRL: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal novaCotacao)) cotacaoAtual = novaCotacao;
            break;

        case "0":
            executando = false;
            Console.WriteLine("A sair...");
            break;

        default:
            Console.WriteLine("[ERRO] Opção inválida.");
            break;
    }
}
