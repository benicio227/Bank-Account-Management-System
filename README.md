# Sistema de Gerenciamento de Conta Bancária  

Este é um projeto simples desenvolvido em C# para gerenciar contas bancárias. Ele implementa conceitos importantes como Programação Orientada a Objetos (POO), herança, polimorfismo, encapsulamento e o uso de interfaces.  

## Funcionalidades  
- Criar contas correntes e contas poupança.  
- Realizar depósitos e saques.  
- Verificar saldo e limites disponíveis.  
- Exibir extratos detalhados.  

## Estrutura do Projeto  
O projeto está dividido em duas pastas principais:  

1. **Entities**  
   - Contém as classes que representam os tipos de contas bancárias, como `ContaBancaria`, `ContaCorrente` e `ContaPoupanca`.  

2. **Services**  
   - Contém a classe `SistemaGestaoContaBancaria`, que gerencia as operações do sistema.  

## Conceitos Abordados  

- **Herança**: A classe base `ContaBancaria` serve como base para `ContaCorrente` e `ContaPoupanca`, permitindo reutilização de código.  
- **Polimorfismo**: O método abstrato `Sacar` permite que cada tipo de conta implemente sua própria lógica.  
- **Encapsulamento**: Propriedades como `LimiteChequeEspecial` têm proteção, garantindo que sejam alteradas apenas dentro de suas respectivas classes.  
- **Interfaces**: A interface `IContaBancaria` define um contrato comum para todas as contas, promovendo abstração.  

## Requisitos  
- .NET 6.0 ou superior.  
- IDE como Visual Studio ou Visual Studio Code.  

## Como Executar  

1. Clone o repositório:  
   ```bash  
   git clone https://github.com/seu-usuario/sistema-conta-bancaria.git  

2. Navegue até a pasta do projeto:
   ```bash
   cd sistema-conta-bancaria
3. Compile e execute o projeto:
   ```bash
   dotnet run
4. Utilize os menus para interagir com o sistema
   
