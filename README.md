# FraudWatch API

## Integrantes do Grupo

## Definição da Arquitetura da API e Justificativa da Escolha

### Arquitetura Monolítica
A arquitetura escolhida para esta API é monolítica, pois o projeto em questão é pequeno e não apresenta requisitos que justifiquem a complexidade adicional de uma abordagem baseada em microsserviços.

#### Monolítico vs. Microsserviços
Ao definir a arquitetura de um sistema, é essencial considerar fatores como escalabilidade, manutenção e complexidade.

- **Arquitetura Monolítica**: Toda a aplicação é construída como um único sistema, onde todos os módulos compartilham um mesmo código-base e banco de dados.
- **Arquitetura de Microsserviços**: O sistema é dividido em pequenos serviços independentes, cada um responsável por uma funcionalidade específica, geralmente com seu próprio banco de dados e comunicação via APIs ou mensageria.

Embora microsserviços sejam úteis para sistemas altamente escaláveis e distribuídos, eles também trazem desafios como a necessidade de orquestração, comunicação entre serviços, deploys independentes e aumento da complexidade geral do sistema.

#### Justificativa para a Arquitetura Monolítica
A escolha da arquitetura monolítica se deve ao fato de que este é um projeto pequeno, onde uma abordagem baseada em microsserviços representaria overengineering. Ou seja, estaríamos adicionando uma complexidade desnecessária sem trazer benefícios reais para o desenvolvimento e manutenção do sistema.

Os principais motivos para manter a arquitetura monolítica são:
- **Menor complexidade**: O desenvolvimento e a manutenção são mais simples, pois toda a aplicação reside em um único código-base.
- **Menos Overhead**: Em um monolito, os módulos se comunicam internamente, enquanto em microsserviços seria necessário implementar comunicação via HTTP ou mensageria.
- **Facilidade de Deploy**: Um único deploy facilita a gestão de versões e a integração contínua, sem necessidade de pipelines separados para diferentes serviços.
- **Menos Custos Operacionais**: Microsserviços exigiram uma infraestrutura mais robusta, como Kubernetes e gerenciamento de múltiplos bancos de dados, o que não é necessário para este projeto.
- **Escalabilidade Controlada**: Mesmo em uma arquitetura monolítica, é possível otimizar o desempenho e escalar a aplicação horizontalmente caso necessário.

#### Conclusão
Dado o escopo do projeto, a adoção de uma arquitetura de microsserviços não traria vantagens significativas, mas aumentaria a complexidade do desenvolvimento e da manutenção. Assim, a escolha pela arquitetura monolítica é a mais adequada, pois proporciona simplicidade, eficiência e fácil gerenciamento, garantindo que o sistema possa crescer de maneira estruturada sem introduzir desafios desnecessários.

Se, no futuro, o projeto precisar escalar significativamente, a modularização do código permitirá uma transição gradual para uma abordagem de microsserviços, sem a necessidade de uma refatoração completa.

## Design Patterns Utilizados
- **Dependency Injection**: Utilizado para gerenciar dependências e promover a inversão de controle.
- **Repository Pattern**: Para abstrair a lógica de acesso a dados e facilitar a manutenção e testes.
- **Factory Pattern**: Para a criação de objetos complexos, promovendo a reutilização de código e a separação de responsabilidades.

## Instruções para Rodar a API

### Pré-requisitos
- .NET 8 SDK
- Oracle Database (ou outro banco de dados configurado)

### Passos
1. Clone o repositório:
    
