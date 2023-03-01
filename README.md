
# Web API usando DDD em ASP.NET 6 para cadastro de notícias com sistema de usuário

OBS: Este projeto ainda está em andamento!

Este é um projeto de uma Web API em ASP.NET 6 utilizando a arquitetura DDD (Domain-Driven Design) para cadastro de notícias, com suporte a autenticação de usuários.

O objetivo deste projeto é fornecer uma estrutura sólida para o desenvolvimento de aplicações que envolvam o gerenciamento de notícias, permitindo uma fácil manutenção e escalabilidade.

## Como executar o projeto

1. Certifique-se de ter o .NET 6 SDK instalado em sua máquina.
2. Clone este repositório em sua máquina local.
3. Abra o terminal ou prompt de comando na pasta raiz do projeto.
4. Execute o seguinte comando para restaurar as dependências do projeto:
5. Em seguida, execute o seguinte comando para compilar o projeto:
6. Depois de compilado, execute o seguinte comando para executar o projeto:



## Tecnologias utilizadas

- ASP.NET 6
- Entity Framework Core
- AutoMapper
- Swagger
- JWT Authentication
- SQL Server

## Estrutura do projeto

O projeto foi organizado seguindo a arquitetura DDD, com a seguinte estrutura de pastas:

- **Api**: responsável pelos endpoints da aplicação;
- **Application**: contém as interfaces e implementações dos serviços da aplicação;
- **Domain**: contém as classes de domínio da aplicação, incluindo entidades, objetos de valor e serviços de domínio;
- **Infrastructure**: responsável por prover as implementações concretas dos serviços definidos na camada de Application, incluindo os repositórios e a infraestrutura de acesso a dados;
- **Presentation**: responsável por prover as funcionalidades de apresentação da aplicação, incluindo a configuração do Swagger e da autenticação JWT.

## Contribuindo

Este projeto ainda não está concluído, portanto, as contribuições são bem-vindas. Para contribuir, siga os seguintes passos:

1. Crie um fork deste repositório.
2. Crie um branch com o nome da sua feature ou correção.
3. Implemente suas mudanças.
4. Crie um pull request para o branch `main` deste repositório.

## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais informações.
