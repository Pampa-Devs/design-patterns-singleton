# Design Patterns - Singleton.

O Singleton também faz parte do grupo de padrões criacionais, tendo 2 objetivos:
* Garantir que um objeto tenha apenas uma única instância em todo o sistema
* Providenciar um ponto de acesso global para aquela instância.

Por resolver 2 problemas de uma única vez, ele acaba violando o princípio da responsabilidade única do SOLID, 
que prega que uma classe deve ter uma única responsabilidade.

Quando devemos usar Singleton? Bom, existem pouquissimas razões para tornar uma classe em um singleton e, 99% das vezes, essa necessidade
vem de uma falha na arquitetura de seu projeto.

Para verificar se uma classe é uma candidata válida para se tornar um singleton, verifique se ela atende os seguintes requisitos:
1. Controla acesso simultâneo para um recurso compartilhado.
2. O acesso ao recurso pode ser solicitado em qualquer parte do sistema.
3. Só pode haver um objeto.