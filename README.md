# PlatformService

## Descri��o

Este projeto tem como objetivo de estudar como criar uma aplica��o baseada em microsservi�os em .NET, baseado em um curso de Les Jackson. 
O curso usa o .NET vers�o 5 e neste projeto estou usando as vers�es mais novas do .NET (vers�o 9) e das depend�ncias, como o Entity Framework e o AutoMapper.

## Conceitos Usados no Projeto
Alguns conceitos essenciais deste projeto s�o:
- Construir dois microsservi�os .NET usando o padr�o REST API;
- Trabalhar com camadas dedicadas de persist�ncia para ambos servi�os;
- Implantar os servi�os em um Cluster Kubernetes;
- Empregar o padr�o API Gateway para rotear os servi�os;
- Construir mensageria s�ncrona entre os servi�os (HTTP e gRPC);
- Construir mensageria ass�ncrona entre os servi�os usando barramento de eventos (RabbitMQ).

### Observa��es do Projeto
Como usarei Kubernetes neste projeto, deixei um diret�rio chamado K8s dentro do projeto PlatformService, este diret�rio ficar�o os manifestos
YAML do Kubernetes, como o Visual Studio n�o tem muita compatibilidade com Kubernetes (at� onde eu sei), eu s� deixei os manifests ali para
versionamento, pois uso o Kubernetes via WSL e fa�o as mudan�as dentro do cluster por terminal no WSL.