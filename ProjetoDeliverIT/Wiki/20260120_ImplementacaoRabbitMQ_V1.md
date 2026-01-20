# RabbitMQ Implementation – Ver. 1.0

## Objetivo

Estudar e implementar RabbitMQ em um projeto .NET.  
Foco em comunicação assíncrona básica.  
Envio e consumo de mensagens.  
Base para escalabilidade futura.

---

## Escopo

- Projeto produtor em ASP.NET
- Fila simples sem exchange customizada
- Publicação de evento após sucesso na regra de negócio
- Consumer separado para leitura das mensagens

---

## O que foi implementado

- RabbitMQ executando em container Docker
- Publicação de mensagens após insert bem-sucedido
- Uso do pacote RabbitMQ.Client 7.x
- Comunicação baseada em fila durável

---

## Arquitetura

- API REST  
  - POST cria a entidade  
  - Publica evento `bill_created`

- RabbitMQ  
  - Gerencia fila e entrega de mensagens

- Consumer  
  - Não realizado, mas previsto para ler e gerar novas tabelas no banco

---

## Tecnologias

- .NET
- Docker
- RabbitMQ
- RabbitMQ.Client 7.x



