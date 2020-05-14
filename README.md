

# Design Patterns - Singleton.

O Singleton é um anti-padrão, pois ele resolve dois problemas de uma única vez, violando o princípio
da responsabilidade única.

* Ele garante que a classe tenha apenas uma única instância.
* Ele fornece um ponto de acesso global para aquela instância.

Quando devemos usar Singleton? Bom, a resposta para isso é não devemos. 

Existem pouquissimas razões para tornar uma classe em um singleton e, 99% das vezes, essa necessidade
vem de uma falha na arquitetura de seu projeto.

Para verificar se uma classe é uma candidata válida para se tornar um singleton, verifique se ela atende os seguintes requisitos:
1. Controla acesso simultâneo para um recurso compartilhado.
2. O acesso ao recurso pode ser solicitado em qualquer parte do sistema.
3. Só pode haver um objeto.


