# FraudWatch API

## Integrantes do Grupo
- RM553542 Luiz Otávio - 2tdspr
- RM553483 Vitor de Melo - 2tdspr
- RM553748 Mauricio Pereira - 2tdspc

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
- **Menos Custos Operacionais**: Microsserviços exigem uma infraestrutura mais robusta, como Kubernetes e gerenciamento de múltiplos bancos de dados, o que não é necessário para este projeto.
- **Escalabilidade Controlada**: Mesmo em uma arquitetura monolítica, é possível otimizar o desempenho e escalar a aplicação horizontalmente caso necessário.

#### Conclusão
Dado o escopo do projeto, a adoção de uma arquitetura de microsserviços não traria vantagens significativas, mas aumentaria a complexidade do desenvolvimento e da manutenção. Assim, a escolha pela arquitetura monolítica é a mais adequada, pois proporciona simplicidade, eficiência e fácil gerenciamento, garantindo que o sistema possa crescer de maneira estruturada sem introduzir desafios desnecessários.

Se, no futuro, o projeto precisar escalar significativamente, a modularização do código permitirá uma transição gradual para uma abordagem de microsserviços, sem a necessidade de uma refatoração completa.

## Design Patterns Utilizados
- **Dependency Injection**: Utilizado para gerenciar dependências e promover a inversão de controle.
- **Repository Pattern**: Para abstrair a lógica de acesso a dados e facilitar a manutenção e testes.
- **Factory Pattern**: Para a criação de objetos complexos, promovendo a reutilização de código e a separação de responsabilidades.

## Testes

Este projeto inclui um projeto de testes que valida o comportamento e a funcionalidade das principais partes do sistema. Os testes cobrem diferentes cenários para garantir a qualidade e a confiabilidade do código.

## Práticas de Clean Code

Este projeto segue princípios de Clean Code para garantir legibilidade, manutenibilidade e qualidade do código. Algumas das práticas aplicadas incluem:

- **Nomes Significativos**: Variáveis, métodos e classes possuem nomes claros e descritivos, refletindo sua intenção.
- **Funções Simples e Pequenas**: Métodos foram projetados para realizar apenas uma tarefa, facilitando a compreensão e reutilização.
- **Organização do Código**: Estrutura do projeto bem definida, com separação de responsabilidades e uso de padrões de projeto quando necessário.
- **Evitar Código Duplicado**: Reutilização de lógica comum para reduzir redundância.
- **Comentários Relevantes**: Apenas comentários necessários foram adicionados para explicar partes complexas do código.
- **Tratamento de Erros**: Uso adequado de exceções e validações para garantir a robustez do sistema.
- **Formatação Consistente**: Código formatado de maneira uniforme para facilitar a leitura e colaboração.

Essas práticas ajudam a manter o código limpo, eficiente e fácil de evoluir.

## SentimentAnalysisApplicationService

A classe `SentimentAnalysisApplicationService` é responsável por realizar análises de sentimento em textos utilizando o framework **ML.NET**. Ela treina um modelo de aprendizado de máquina com base em dados de treinamento e realiza previsões para classificar textos como "Positivo" ou "Negativo". 

### Funcionalidades principais:
- **Treinamento do Modelo**: 
  - Carrega dados de treinamento a partir de um arquivo CSV.
  - Aplica transformações de texto, normalização e treinamento usando o algoritmo `SdcaMaximumEntropy`.
- **Previsão de Sentimento**:
  - Recebe um texto como entrada, realiza pré-processamento (remoção de acentos, pontuações e normalização) e utiliza o modelo treinado para prever o sentimento.
  - Retorna a classificação ("Positivo" ou "Negativo") com base na pontuação mais alta.
- **Pré-processamento de Texto**:
  - Limpa e normaliza o texto de entrada para melhorar a precisão do modelo.

### Estrutura:
- **Dependências**:
  - `MLContext` para gerenciar o pipeline de aprendizado de máquina.
  - `ITransformer` para armazenar o modelo treinado.
- **Entrada e Saída**:
  - Entrada: Texto a ser analisado.
  - Saída: Objeto `SentimentPrediction` contendo o rótulo previsto e as pontuações associadas.

Essa classe é essencial para automatizar a análise de sentimentos, sendo útil em cenários como monitoramento de feedbacks, análises de redes sociais ou qualquer aplicação que exija classificação de texto.


## Instruções para Rodar a API (LocalHost)

### Pré-requisitos
- .NET 8 SDK
- Oracle Database (ou outro banco de dados configurado)

### Passos
1. Clone o repositório:
    ```bash
    git clone https://github.com/Luiz1614/Csharp-FraudWatch.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd FraudWatch
    ```

3. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

4. Crie o banco de dados (se necessário):
    - Certifique-se de ter o Oracle Database ou outro banco de dados configurado corretamente.
    - Se estiver usando Oracle, crie um banco de dados e configure as credenciais no arquivo de configuração `appsettings.json`.

5. Execute a aplicação:
    ```bash
    dotnet run
    ```

## Endpoints da API

### URLs Base

- Local: https://localhost:7299
- Web: https://fraudwatch-devops-a6fbf8fvegfde9ef.eastus-01.azurewebsites.net/

### Analista

- **GET** `/api/Analista`
  - Retorna uma lista de todos os analistas.

- **POST** `/api/Analista`
  - Adiciona um novo analista.

- **GET** `/api/Analista/{id}`
  - Retorna um analista pelo ID.

- **PUT** `/api/Analista/{id}`
  - Atualiza um analista pelo ID.

- **DELETE** `/api/Analista/{id}`
  - Deleta um analista pelo ID.

- **GET** `/api/Analista/departamento/{departamento}`
  - Retorna um analista pelo departamento.

### Dentista

- **GET** `/api/Dentista`
  - Retorna uma lista de todos os dentistas.

- **POST** `/api/Dentista`
  - Adiciona um novo dentista.

- **GET** `/api/Dentista/{id}`
  - Retorna um dentista pelo ID.

- **PUT** `/api/Dentista/{id}`
  - Atualiza um dentista pelo ID.

- **DELETE** `/api/Dentista/{id}`
  - Deleta um dentista pelo ID.

- **GET** `/api/Dentista/cro/{cro}`
  - Retorna um dentista pelo CRO.

### Address
- **GET** `/api/address/{cep}`
  - Retorna um endereço pelo CEP
 
### FeedBack
- **POST** `/api/sentment/feedback`
  - Retorna se o feedback do paciente foi positivo ou negativo.
