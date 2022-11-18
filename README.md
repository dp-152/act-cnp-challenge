
  
#  Desafio Act Digital / CNP Brasil Holding

Projeto desenvolvido em .NET 7

##  Desenvolvimento
Este projeto requer [.NET](https://dotnet.microsoft.com/) 7.0.x.

O projeto possui um Makefile para ambientes que suportam make.

Targets disponíveis:
```sh
# Build
make build				# executa a build do projeto
make publish			# publica a build do projeto

# Docker
make compose			# inicializa os serviços por docker-compose
make compose-cleanbuild	# executa a build dos containers sem cache e inicializa os serviços

# Dependências
make restore			# restaura as dependências do projeto

# Limpeza
make clean				# limpa os artefatos de build do projeto
```

### Instale todas as dependências do projeto
```sh
dotnet restore CnpChallenge.sln
```
### Ajuste as configurações do projeto
Inicialize um user-settings em sua máquina local:
```sh
dotnet user-secrets init
```

(Opcional) Mova a referência aos user-secrets para um arquivo .csproj.user\
Adicione as connection strings necessárias ao user-secrets:
```sh
dotnet user-secrets set ConnectionStrings:Default "<connection-string>"
dotnet user-secrets set ConnectionStrings:Testing "<connection-string>"
```
As connection strings também podem ser passadas por variáveis de ambiente:
```env
SQLCONNSTR_Default="<connection-string>"
SQLCONNSTR_Testing="<connection-string>"
```
A connection string "Default" é utilizada pelo aplicativo em produção e desenvolvimento.\
A connection string  "Testing" é utilizada pelos testes de integração.

### Execute o projeto
```sh
# Executar normalmente
dotnet run --project CnpChallenge.API

# Executar com hot reload habilitado
dotnet watch --project CnpChallenge.API run
```
\
O projeto possui configuração de debug para [Visual Studio](https://visualstudio.microsoft.com/). Basta importar a solução e utilizar uma das configurações de debug disponíveis.

##  Deploy
### Deploy por Docker
O projeto inclui Dockerfile para deployment por docker.\
É possível deployar o projeto utilizando o arquivo docker-compose existente, caso haja suporte no ambiente:
```sh
docker-compose up
```
Caso contrário, é possível utilizar os Dockerfiles existentes.\
Ajuste as [configurações](#ajuste-as-configurações-do-projeto) conforme necessário.

Crie a imagem:
```sh
docker build -t cnp-challenge:<versão> .
```
Execute a imagem:
```sh
docker run -d -p <porta-externa>:80 --name cnp-challenge cnp-challenge:<versão>
```

###  Deploy Manual
Este projeto requer [.NET](https://dotnet.microsoft.com/) 7.0.x.\
Ajuste as [configurações](#ajuste-as-configurações-do-projeto) conforme necessário.

Instale as dependências do projeto:
```sh
dotnet restore CnpChallenge.sln
```
Publique o projeto:
```sh
dotnet publish CnpChallenge.sln -c Release -o ./out
```
Execute a API:
```sh
cd out
dotnet CnpChallenge.API.dll
```
## Referência da API
Quando em ambiente de desenvolvimento, a API disponibiliza a documentação dos endpoints em OpenAPI/Swagger.\
A Swagger UI pode ser encontrada em http://\<URL>/swagger.\
As definições de OpenAPI podem ser encontradas em http://\<URL>/swagger/v1/swagger.json
