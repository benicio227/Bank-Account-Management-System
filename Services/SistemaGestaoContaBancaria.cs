using SistemaGestaoContaBancaria.Entities;

namespace SistemaGestaoContaBancaria.Services;
public class SistemaGestaoContaBancaria
{
    // Lista para armazenar todas as contas bacárias
    private List<ContaBancaria> contas = new List<ContaBancaria>();

    // Operação para criar uma nova conta (corrente ou poupança)
    public void CriarConta(string tipoConta, string numeroConta, string titular, decimal saldoInicial,
                           decimal? limiteChequeEspecial = null, decimal? taxaRendimentoMensal = null)
    {
        ContaBancaria conta;

        if (tipoConta.Equals("corrente", StringComparison.OrdinalIgnoreCase))
        {
            if (limiteChequeEspecial.HasValue)
            {
                conta = new ContaCorrente(numeroConta, titular, saldoInicial, limiteChequeEspecial.Value);
            }
            else
            {
                Console.WriteLine("Limite de cheque especial não pode ser nulo para conta corrente.");
                return;
            }
        }
        else if (tipoConta.Equals("poupanca", StringComparison.OrdinalIgnoreCase))
        {
            if (taxaRendimentoMensal.HasValue)
            {
                conta = new ContaPoupanca(numeroConta, titular, saldoInicial, taxaRendimentoMensal.Value);
            }
            else
            {
                Console.WriteLine("Taxa de rendimento mensal não pode ser nula para conta poupança.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Tipo de conta inválido. Escolha entre 'corrente' ou 'poupanca'.");
            return;
        }

        contas.Add(conta);
        Console.WriteLine("Conta criada com sucesso");
    }

    // Exibir todas as contas cadastradas

    public void ExibirContas()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("Não há contas cadastradas.");
        }

        foreach (var conta in contas)  // Percorre cada objeto de conta(conta-corrente/conta-poupança) e exibe o extrato
        {
            conta.ExibirExtrato();
            Console.WriteLine("------------------");

        }
    }

    // Operação para depositar dinheiro em uma conta

    public void Depositar(string numeroConta, decimal valor)
    {
        var conta = BuscarConta(numeroConta);

        if (conta != null)
        {
            conta.Depositar(valor);
        }
    }

    // Operação para sacar dinheiro em uma conta

    public void Sacar(string numeroConta, decimal valor)
    {
        var conta = BuscarConta(numeroConta);

        if (conta != null)
        {
            conta.Sacar(valor);
        }
    }

    // Operação para transferir dinheiro entre contas

    public void Transferir(string numeroContaOrigem, string numeroContaDestino, decimal valor)
    {
        var contaDeOrigem = BuscarConta(numeroContaOrigem);
        var contaDeDestino = BuscarConta(numeroContaDestino);

        if (contaDeOrigem != null && contaDeDestino != null)
        {
            contaDeOrigem.Sacar(valor);
            contaDeDestino.Depositar(valor);
            Console.WriteLine($"Transferência de {valor:C} realizada com sucesso.");
        }
    }



    // Método para buscar uma conta pelo número da conta
    private ContaBancaria? BuscarConta(string numeroConta)
    {
        var conta = contas.Find(conta => conta.NumeroConta == numeroConta);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada.");
        }

        return conta;
    }

}
