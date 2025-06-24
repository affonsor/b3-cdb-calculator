# b3-cdb-calculator

Projeto full stack para simulação de investimentos em **CDB (Certificado de Depósito Bancário)**, utilizando **.NET 8** no backend e **Angular 20** no frontend. Estruturado com **arquitetura em camadas**, o sistema promove separação de responsabilidades e facilita a evolução e manutenção do código.

---

## 📁 Estrutura da Solução

A solução backend é composta pelos seguintes projetos:

* `B3.Cdb.Calculator.Api`: API REST com os endpoints públicos.
* `B3.Cdb.Calculator.Application`: Camada de aplicação com lógica de negócio.
* `B3.Cdb.Calculator.Domain`: Entidades de domínio, contratos e DTOs.
* `B3.Cdb.Calculator.Tests`: Projeto dedicado aos testes automatizados.
* **Frontend Angular**: Aplicação web externa à solução .NET, utilizada para interação com o usuário.

---

## 🧰 Tecnologias Utilizadas

### Backend (.NET)

* .NET 8 (C#)
* ASP.NET Core
* Padrão arquitetural por camadas
* Logging com `ILogger`
* xUnit para testes unitários
* Docker para empacotamento e deploy da aplicação

### Frontend (Angular)

* Angular 20
* Comunicação com API via `HttpClient`

---

## ▶️ Executando a Aplicação

### Requisitos

* .NET SDK 8.0 ou superior
* Node.js 18+ (para executar o frontend)

### Backend

1. Clone este repositório.
2. Acesse o diretório `B3.Cdb.Calculator.Api`.
3. Execute:

```bash
dotnet run
```

4. A API estará disponível em: `https://localhost:7005`

---

### Frontend

1. Navegue até a pasta do projeto Angular.
2. Instale as dependências:

```bash
npm install
```

3. Inicie o servidor de desenvolvimento:

```bash
ng serve
```

4. Acesse via navegador: [http://localhost:52126/](http://localhost:52126/)

---

## 📌 Funcionalidades

### Endpoint da API

* **POST** `/api/Cdb/calculate`: Recebe o valor inicial e o prazo (em meses), retornando o rendimento bruto e líquido do investimento.

**Exemplo de requisição:**

```json
{
  "initialValue": 100,
  "months": 12
}
```

**Exemplo de resposta:**

```json
{
  "statusCode": 200,
  "message": "Cálculo concluído com sucesso.",
  "data": {
    "grossReturn": 112.31,
    "netReturn": 109.85
  }
}
```

### Interface Web

* Permite o envio de dados de simulação.
* Apresenta o resultado com os rendimentos ou exibe mensagens de erro.

---

## 📅 Testes Automatizados

Os testes estão localizados no projeto `B3.Cdb.Calculator.Tests`.

Para rodá-los:

```bash
dotnet test
```

---

## 📩 Contato

Dúvidas ou sugestões? Fique à vontade para entrar em contato:

**Rafael Affonso**
📧 [affonso.dev@gmail.com](mailto:affonso.dev@gmail.com)