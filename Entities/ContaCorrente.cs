namespace SistemaGestaoContaBancaria.Entities;
public class ContaCorrente : ContaBancaria
{
    public decimal LimiteChequeEspecial {  get; protected set; } // Não quero que ninguém altere o valor do limite de cheque especial fora da classe
    
    public ContaCorrente(string numeroDaConta, string titular, decimal saldo, decimal limiteChequeEspecial) : base(numeroDaConta, titular, saldo)
    {
        NumeroConta = numeroDaConta;
        Titular = titular;
        Saldo = saldo;
        LimiteChequeEspecial = limiteChequeEspecial;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo.");
            return;
        }

        decimal saldoDisponivel = Saldo + LimiteChequeEspecial;

        if (valor > saldoDisponivel)
        {
            Console.WriteLine("Saldo insuficiente, incluindo o limite de cheque especial.");
            return;
        }

        if (valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo:C}");
        }
        else
        {
            decimal diferenca = valor - Saldo;
            Saldo = 0;
            LimiteChequeEspecial -= diferenca;

            if(LimiteChequeEspecial < 0)
            {
                Console.WriteLine("Cheque especial insuficiente.");
                return;
            }

            Console.WriteLine($"Saque realizado utilizando o cheque especial. Limite de cheque especial restante: {LimiteChequeEspecial:C}");
        }
    }
}
