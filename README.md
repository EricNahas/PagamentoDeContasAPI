# PagamentoDeContasAPI

O projeto foi construído em **.NET 8** com **C#**, utilizando **Entity Framework Core** e **MySQL** para persistência de dados.  
O objetivo é gerenciar **Contas**, aplicando **regras parametrizadas** de multa e juros conforme o número de dias em atraso.

---

## 🧠 Objetivo

Implementar um serviço REST que permita:
- Cadastrar contas.  
- Calcular automaticamente multa e juros conforme regras cadastradas.  
- Listar todas as contas registradas.  
- Demonstrar conhecimento em abstração e expansabilidade

---

## ⚙️ Tecnologias Utilizadas

- **.NET 8 / ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **Pomelo.EntityFrameworkCore.MySql**
- **Swagger / OpenAPI**
- **Dependency Injection**
- **MySQL**

---

## 📦 Estrutura do Projeto
```
PagamentoDeContasAPI/
│
├── Controllers/
│ └── ContasController.cs → Endpoints principais da API
│
├── Data/
│ └── AppDbContext.cs → Contexto do banco (EF Core)
│
├── Models/
│ ├── Conta.cs → Entidade de conta a pagar
│ ├── ContaRegraAtraso.cs → Tabela parametrizada de regras
│ └── RetornoAPI.cs → Modelo padrão de resposta
│
├── Repositories/
│ ├── IContaRepository.cs
│ ├── ContaRepository.cs
│ ├── IContaRegraAtrasoRepository.cs
│ └── ContaRegraAtrasoRepository.cs
│
├── Services/
│ ├── IContaService.cs
│ └── ContaService.cs
│
├── Utils/
│ └── ResponseUtils.cs → Padroniza mensagens de retorno e Converte RetornoAPI em IActionResult
│
├── appsettings.json → Configuração do MySQL
└── Program.cs → Configuração da aplicação
```
---

## 🧩 Regras de Negócio

As regras de multa e juros são definidas na tabela `ContaRegrasAtraso` e **não estão fixas no código**.

| Dias em Atraso | Multa (%) | Juros ao Dia (%) |
|-----------------|------------|------------------|
| até 3 dias      | 2          | 0.1              |
| 4 a 5 dias      | 3          | 0.2              |
| acima de 5 dias | 5          | 0.3              |

---

## 🧪 Endpoints Principais

### `POST /api/contas`
Cria uma nova conta.

**Exemplo de request:**
```json
{
  "nome": "Energia Elétrica",
  "valorOriginal": 250.00,
  "dataVencimento": "2025-10-10T00:00:00Z",
  "dataPagamento": "2025-10-13T00:00:00Z"
}
```
Response:

```json
{
  "mensagemRetorno": "Conta inserida com sucesso.",
  "statusRetorno": 200,
  "dadosRetorno": {
    "id": 1,
    "nome": "Energia Elétrica",
    "valorOriginal": 250.00,
    "valorCorrigido": 252.25,
    "diasAtraso": 3
  }
}
```

---

### `GET /api/contas`

Lista todas as contas registradas.

---

✨ Diferenciais Implementados

- Padrão Repository + Service Layer

- Injeção de dependência 

- Tratamento centralizado de respostas

- Regras parametrizáveis via banco

- Documentação via Swagger

---

👤 Autor

Desenvolvido por Eric Nahas
para o processo seletivo da Deliver IT
