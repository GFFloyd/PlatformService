# PlatformService

## Descrição

Este projeto tem como objetivo de estudar como criar uma aplicação baseada em microsserviços em .NET, baseado em um curso de Les Jackson. 
O curso usa o .NET versão 5 e neste projeto estou usando as versões mais novas do .NET (versão 9) e das dependências, como o Entity Framework e o AutoMapper.

## Conceitos Usados no Projeto
Alguns conceitos essenciais deste projeto são:
- Construir dois microsserviços .NET usando o padrão REST API;
- Trabalhar com camadas dedicadas de persistência para ambos serviços;
- Implantar os serviços em um Cluster Kubernetes;
- Empregar o padrão API Gateway para rotear os serviços;
- Construir mensageria síncrona entre os serviços (HTTP e gRPC);
- Construir mensageria assíncrona entre os serviços usando barramento de eventos (RabbitMQ).

### Observações do Projeto
Como usarei Kubernetes neste projeto, deixei um diretório chamado K8s dentro do projeto PlatformService, este diretório ficarão os manifestos
YAML do Kubernetes, como o Visual Studio não tem muita compatibilidade com Kubernetes (até onde eu sei), eu só deixei os manifests ali para
versionamento, pois uso o Kubernetes via WSL e faço as mudanças dentro do cluster por terminal no WSL.