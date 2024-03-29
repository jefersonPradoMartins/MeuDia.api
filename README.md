# MeuDia API REST 

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

### Descrição do Projeto
O projeto MeuDia API REST é uma aplicação que foi desenvolvida visando aprimorar minhas habilidades na
implementação de classes abstratas junto de padrões criacionais, especialmente o Fluent Builder Pattern e o 
Factory Method. Para essa prova de conceito utilizei ORM Entity Framework, e System.Text.Json;


### Aprendizados: 
- Lidando com a herança no Entity Framework, existem formas diferentes de salvar os dados das classes concretas
  que implementam a classe abstrata, a **Table-per-concrete-type configuration**  salva cada classe concreta 
  em uma tabela diferente, já a maneira que utilizei nesse projeto  foi **Table-per-hierarchy and discriminator configuration**
  que salva os dados das classes concretas na mesma tabela, onde é necessário adicionar uma propriedade a mais para descriminar
  qual classe foi salva no banco de dados.
  
  > EF can map a .NET type hierarchy to a database. This allows you to write your .NET entities in code as usual, using base and derived types, and have EF seamlessly create the appropriate database schema, issue queries, etc. The actual details of how a type hierarchy is mapped are provider-dependent; this page describes inheritance support in the context of a relational database.
  > [Para mais informações](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance)

- Encontrei problema para descerealizar o arquivo JSON para o objeto concreto, para resolver tive que criar uma classe CustomJsonConverter que herda de
  JsonConverter da biblioteca System.Text.Json, onde sobrescrevi as funções de leitura e escrita, de forma que o resultado da descerealização do
  JSON me retorne um objeto da classe concreta que estou usando. Dessa forma não precisei criar um end-point para cada tipo de classe concreta.
  
  > [Para mais informações](https://code-maze.com/csharp-polymorphic-serialization-and-deserialization/)
- Em consultas ao banco que precisa retornar informações de uma entidade que possui relacionamento com a entidade abstrata acaba não retornando informação da entidade abstrata, para resolver utilizei include adicionando a relação entre as entidades.

  ```csharp
  var result = _context.Task.Include(x => x.Tags)
      .ThenInclude(x => x.Color).Where(x => x.TaskId == taskId).First(); 
    ```
   
### Conclusão
- É Possível utilziar herança em um projeto usando a blilioteca padrão de JSON do .Net e ORM Entity Framework, porem precisa realizar algumas alterações. 
