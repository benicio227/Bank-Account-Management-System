namespace SistemaGestaoContaBancaria.Entities;
public abstract class ContaBancaria
{
    public string NumeroConta { get; protected set; } = string.Empty; // Quando você define o setter como protegido, a propriedade pode ser acessada diretamente dentro da classe e em classes derivadas (heranças), mas não pode ser alterada diretamente fora da classe ou de subclasses. Isso ajuda a proteger a integridade dos dados.
    public string Titular {  get; protected set; } = string.Empty;
    public decimal Saldo {  get; protected set; }

    protected ContaBancaria(string numeroDaConta, string titular, decimal saldo)
    {
        NumeroConta = numeroDaConta;
        Titular = titular;
        Saldo = saldo;
    }

    public void Depositar(decimal valor) // Como tanto as classes conta-corrente como a conta-poupança tem a mesma implementação de Depósito, eu posso criar ela na classe base(pai) e apneas reutilizar nas classes filhas
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser positivo.");

        }

        Saldo += valor;
    }

    public abstract void Sacar(decimal valor); // O método Sacar é abstrato, significando que as classes conta-corrente e conta-poupanca precisam obrigatoriamente implementar esse método

    public virtual void ExibirExtrato() // O método ExibirExtrato é virtual porque as classes conta-corrente e conta-poupança vão poder sobrescrever esse método
    {
        Console.WriteLine($"Número da Conta: {NumeroConta}");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo Atual: {Saldo:C}"); //Formata o saldo atuaç como moeda;
    }
}








// 1 - Herança e Polimorfismo

// HERANÇA:  A classe base ContaBancaria define propriedades e métodos que são comuns a todas as contas bancárias, permitindo reutilização e evitando duplicação de código.
// POLIMORFISMO: O método Sacar é abstrato, garantindo que cada tipo de conta implemente sua própria lógica de saque.

// 2 - Reutilização do Método Depositar

// Como a lógica de depósito é igual para todas as contas, centralizá-la na classe base faz sentido.

// 3 - Uso de Métodos Virtuais

// O método ExibirExtrato é virtual, o que permite às classes filhas (como ContaCorrente e ContaPoupanca) sobrescrevê-lo se quiserem fornecer um extrato mais detalhado.