namespace SistemaGestaoContaBancaria.Interfaces;
public interface IContaBancaria // Essa interface define as operações básicas que toda conta bancária deve suportar
{
    string NumeroConta {  get; }
    string Titular {  get; }
    decimal Saldo {  get; }

    void Depositar(decimal valor);
    void Sacar(decimal valor);
    string ExibirExtrato();
}
