namespace SistemaGestaoContaBancaria.Entities;
public class ContaPoupanca : ContaBancaria
{
    public decimal TaxaRendimentoMensal {  get; set; }

    public ContaPoupanca(string numeroDaConta, string titular, decimal saldo, decimal taxaDeRendimento) : base(numeroDaConta, titular, saldo)
    {
        TaxaRendimentoMensal = taxaDeRendimento;
    }

    public void CalcularRendimento()
    {
        decimal rendimento = Saldo * (TaxaRendimentoMensal / 100);
        Saldo += rendimento;
        Console.WriteLine($"Rendimento de {TaxaRendimentoMensal}% aplicado. Saldo atual: {Saldo:C}");
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo.");
            return;
        }

        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
            return;
        }

        Saldo -= valor;
        Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo:C}");
    }

    public override void ExibirExtrato()
    {
        base.ExibirExtrato();
        Console.WriteLine($"Taxa de rendimento mensal: {TaxaRendimentoMensal}%");
    }
}
