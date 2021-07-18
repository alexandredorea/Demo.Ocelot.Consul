## O que temos? 

Neste repositório você irá encontrar:

1. API Gateway com Ocelot;
2. Microsserviços (apenas uma simulação);
3. Serviço do Consul para Service Discovery;

## Como rodar tudo?

O arquivo `docker-compose.yml`, contém as definições e configuração dos serviços descritos acima.
Será necessário usar a Docker Compose p'ra configurar e executar aplicativos em container, usando o seguinte comando:

```PowerShell

docker-compose -f .\docker-compose.yml up -d

```

Ao concluir o processo, sugiro que verifique se as imagens foram criadas em seu container local:

```PowerShell

docker images

```

Em caso haver imagens varias (referências vinculadas às imagens rodando), você pode limpá-las:

```PowerShell

docker image prume -f

```

## E os dados como vejo que funcionou?

Ao configurar o ambiente, será necessário utilizar alguma Ferramenta de Teste de APIs Restful, como o [Postman](https://www.postman.com/downloads/).
A unica porta exposta é a do API Gateway [`Porta 9011 (SSL)`], as demais não irão responder (esta era a intenção dos estudos). Então os Endpoint são:

* **Endpoint de produtos (exemplos):**

```json

GET:METHOD
https://localhost:9011/api/gateway/produto/obtertodos

POST:METHOD
https://localhost:9011/api/gateway/produto/criar
{
  "Id": "2cefe46c-305e-4a4b-9e96-928b60b5c5b7",
  "Nome": "Produto 001",
  "Preco": 10.11,
}

PUT:METHOD
https://localhost:9011/api/gateway/produto/atualizar
{
  "Id": "2cefe46c-305e-4a4b-9e96-928b60b5c5b7",
  "Nome": "Produto 001",
  "Preco": 20.11,
}

DELETE:METHOD
https://localhost:9011/api/gateway/produto/remover/{id}

```

* **Endpoint de catalogos (exemplos):**

```json

GET:METHOD
https://localhost:9011/api/gateway/catalogo/obtertodos

```

## Existe opção de roda sem conteiner?

Para ter acesso as portas dos "microserviços" e testar acessando-os diretamente, você vai precisar:

1. Fazer um clone deste repositório em algum lugar de sua preferência:

```
git clone https://github.com/myrp-alexandre/Demo.Microservicos.git
```

2. Baixar o [binário do Consul](https://www.consul.io/downloads) e executar o binário;
   - Sugestão usar em modo desenvolvedor para simplificar tudo:

```PowerShell

consul agent -dev

```

   - Mas, se preferir colocar apenas o Serviço do Consul em Container Docker:

```PowerShell

docker run -d -p 8500:8500 -p 8600:8600/udp --name=servico-consul consul agent -server -ui -node=server-1 -bootstrap-expect=1 -client="0.0.0.0"

```  
  
3. Rodas todas as APIs:
   - Ou usando o Visual Studio;
   - Ou linha de comando.

```PowerShell

dotnet build
dotnet run --project .\src\Demo.Microservico.ApiGateway\Demo.Microservico.ApiGateway.csproj
dotnet run --project .\src\Demo.Microservico.Catalogos\Demo.Microservico.Catalogos.csproj
dotnet run --project .\src\Demo.Microservico.Produtos\Demo.Microservico.Produtos.csproj

```

4. Testar os endpoint como nos [exemplos anteriores acima.](https://github.com/myrp-alexandre/Demo.Microservicos/blob/main/README.md#e-os-dados-como-vejo-que-funcionou)
