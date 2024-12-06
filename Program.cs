namespace SistemaGestaoContaBancaria.Services;

class Program
{
    static void Main()
    {
        var sistema = new SistemaGestaoContaBancaria();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema de gestão de contas bancárias");
            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Exibir Contas");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("6 - Sair");
            Console.WriteLine("Escolha a opção: ");

            string opcao = Console.ReadLine()!;


            switch (opcao)
            {
                case "1":
                    CriarConta(sistema);
                    break;
                case "2":
                    sistema.ExibirContas();
                    break;
                case "3":
                    Depositar(sistema);
                    break;
                case "4":
                    Sacar(sistema);
                    break;
                case "5":
                    Transferir(sistema);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

        }
    }

    static void CriarConta(SistemaGestaoContaBancaria sistema)
    {
        Console.Write("Tipo da conta (corrente/poupança): ");
        string tipoConta = Console.ReadLine()!;

        Console.Write("Numero da conta: ");
        string numeroConta = Console.ReadLine()!;

        Console.Write("Titular: ");
        string titular = Console.ReadLine()!;

        Console.Write("Saldo inicial: ");
        decimal saldoInicial = decimal.Parse(Console.ReadLine()!);

        if (tipoConta.Equals("corrente", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Limite de cheque especial: ");
            decimal limiteChequeEspecial = decimal.Parse(Console.ReadLine()!);

            sistema.CriarConta(tipoConta, numeroConta, titular, saldoInicial, limiteChequeEspecial);
        }
        else if (tipoConta.Equals("poupança", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Taxa de rendimento mensal: ");
            decimal taxaRedimentoMensal = decimal.Parse(Console.ReadLine()!);

            sistema.CriarConta(tipoConta, numeroConta, titular, saldoInicial, taxaRedimentoMensal);
        }
        else
        {
            Console.WriteLine("Tipo de conta inválido.");
        }
    }

    static void Depositar(SistemaGestaoContaBancaria sistema)
    {
        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine()!;

        Console.Write("Valor a depositar: ");
        decimal valor = decimal.Parse(Console.ReadLine()!);

        sistema.Depositar(numeroConta, valor);
    }

    static void Sacar(SistemaGestaoContaBancaria sistema)
    {
        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine()!;

        Console.Write("Valor a sacar: ");
        decimal valor = decimal.Parse(Console.ReadLine()!);

        sistema.Sacar(numeroConta, valor);
    }

    static void Transferir(SistemaGestaoContaBancaria sistema)
    {
        Console.Write("Número da conta de origem: ");
        string numeroContaOrigem = Console.ReadLine()!;

        Console.Write("Número da conta de destino: ");
        string numeroContaDestino = Console.ReadLine()!;

        Console.Write("Valor a transferir: ");
        decimal valor = decimal.Parse(Console.ReadLine()!);

        sistema.Transferir(numeroContaOrigem, numeroContaDestino, valor);
    }
}
