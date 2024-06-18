## Contextualização

Diante da crescente demanda por uma alimentação saudável, enfrentar restrições alimentares pode ser especialmente desafiador. Este projeto apresenta uma plataforma online que oferece acesso facilitado a informações nutricionais detalhadas, além de um sistema de alerta para ingredientes específicos. A plataforma tem como objetivo capacitar pessoas com intolerâncias ou alergias alimentares, bem como outros interessados em uma dieta mais saudável, a fazer escolhas alimentares seguras e informadas. Ao fornecer uma base de dados abrangente de produtos alimentícios e educar os usuários sobre questões nutricionais, o projeto busca não apenas simplificar a vida daqueles com restrições, mas também promover maior transparência na indústria alimentícia.

## Conclusões dos Testes

Para garantir que todos os requisitos funcionais do projeto fossem atendidos, uma série de testes foi realizada. Cada teste foi cuidadosamente planejado e executado para validar diferentes aspectos da plataforma online. Abaixo estão os detalhes dos casos de teste realizados:

| **Caso de Teste** | **CT-01 – Na página inicial, o site deve permitir um cadastro de conta.** |
|:---:|:---:|
| **Requisito Associado** | RF-001 - Realizar cadastro na aplicação |
| **Objetivo do Teste** | Verificar inserção dos dados informados pelo usuário. |
| **Passos** | 1. Acessar a página principal da aplicação;<br>2. Clicar no botão "Cadastrar";<br>3. Preencher os campos obrigatórios;<br>4. Clicar no botão "Cadastrar". |
| **Critério de Êxito** | Persistência dos dados no BD |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema permite o cadastro de conta e os dados são corretamente persistidos no banco de dados. |

| **Caso de Teste** | **CT-02 – Na página inicial, o site deverá permitir a realização do login.** |
|:---:|:---:|
| **Requisito Associado** | RF-002 - Realizar login na aplicação |
| **Objetivo do Teste** | Verificar inserção dos dados informados pelo usuário. |
| **Passos** | 1. Acessar a página de Login da aplicação;<br>2. Preencher os campos obrigatórios;<br>3. Clicar no botão "Login". |
| **Critério de Êxito** | Login realizado |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema permite que os usuários façam login corretamente. |

| **Caso de Teste** | **CT-03 – A página inicial deve ter um botão no menu para a tela “Quem Somos”.** |
|:---:|:---:|
| **Requisito Associado** | RF-003 - Fornecer mais detalhes sobre o site e o grupo desenvolvido. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página principal da aplicação;<br>2. Clicar no botão "Quem somos" localizado no rodapé da aplicação. |
| **Critério de Êxito** | Mostrar detalhes da informação aplicada. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O botão "Quem Somos" exibe corretamente as informações sobre o site e o grupo desenvolvedor. |

| **Caso de Teste** | **CT-04 – No cadastro de novo usuário, o sistema deverá consultar a disponibilidade do nome de usuário desejado.** |
|:---:|:---:|
| **Requisito Associado** | RF-004 - Verificar disponibilidade para que não existam perfis com nomes de usuários repetidos. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página principal da aplicação;<br>2. Clicar no botão "Cadastrar";<br>3. Preencher os campos obrigatórios;<br>4. Clicar no botão "Cadastrar". |
| **Critério de Êxito** | O sistema valida e informa se existe dado |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema verifica corretamente a disponibilidade do nome de usuário e informa o usuário. |

| **Caso de Teste** | **CT-05 – Todos os campos no cadastro e login devem ser obrigatórios.** |
|:---:|:---:|
| **Requisito Associado** | RF-005 - Verificar se todos os campos são obrigatórios no cadastro e login. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página principal da aplicação;<br>2. Clicar no botão "Cadastrar";<br>3. Preencher os campos obrigatórios;<br>4. Clicar no botão "Cadastrar". |
| **Critério de Êxito** | Exigir todos os dados preenchidos. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. Todos os campos no cadastro e login são obrigatórios e a aplicação exige que sejam preenchidos corretamente. |

| **Caso de Teste** | **CT-06 – Todos os tipos de perfis após logados, na tela interna, terão um menu lateral direito, na parte superior esquerda deve ter o logotipo do site, na parte superior direita deve ter sobre o usuário logado: Nome de Usuário; Sair.** |
|:---:|:---:|
| **Requisito Associado** | RF-006 - Uma validação na parte superior direita, que deve ter informação sobre o usuário logado: Nome de Usuário; Sair. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página principal da aplicação;<br>2. Clicar no botão "Login";<br>3. Preencher os campos obrigatórios;<br>4. Clicar no botão "Login". |
| **Critério de Êxito** | Exibir informações do usuário logado e opção de sair. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. Após o login, a interface exibe corretamente o nome do usuário logado e a opção de sair no canto superior direito. |

| **Caso de Teste** | **CT-07 – A tela de alimentos deverá apresentar os botões: Filtrar por Nome, Maior Cal, Menor Cal.** |
|:---:|:---:|
| **Requisito Associado** | RF-007 - Filtrar por Ordem Alfabética. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página "Produtos e Alimentos" da aplicação;<br>2. Localizar na página onde está escrito "Ordenar por:";<br>3. Clicar em "Nome". |
| **Critério de Êxito** | Validação de lista alfabética. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. A funcionalidade de filtro ordena a lista de alimentos alfabeticamente conforme esperado. |

| **Caso de Teste** | **CT-08 – A tela de Adicionar Novo Item deverá ter os campos: Título do Item; Categoria; Inserir Imagem.** |
|:---:|:---:|
| **Requisito Associado** | RF-008 - Verificar todos os campos preenchidos. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página "Adicionar Novo Item";<br>2. Preencher os campos obrigatórios: Título do Item, Categoria, Inserir Imagem;<br>3. Clicar em "Adicionar". |
| **Critério de Êxito** | Exigir todos os dados preenchidos. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. Todos os campos na tela de Adicionar Novo Item/Produto/Alimento são obrigatórios e devem ser preenchidos. |

| **Caso de Teste** | **CT-09 – A tela de Visualizar Item permite ao usuário visualizar os campos: Imagem do item; Título do item; Categoria e permitir o mesmo editar.** |
|:---:|:---:|
| **Requisito Associado** | RF-009 - Verificar veracidade de ação. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página "Visualizar Item";<br>2. Verificar a exibição dos campos: Imagem do item, Título do item, Categoria;<br>3. Testar a funcionalidade de edição. |
| **Critério de Êxito** | Exigir exibição do artigo. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. A tela de Visualizar Item exibe corretamente as informações do item e permite edição. |

| **Caso de Teste** | **CT-10 – O botão Excluir Item deverá excluir o item da lista de favoritos.** |
|:---:|:---:|
| **Requisito Associado** | RF-010 - Verificar veracidade de ação. |
| **Objetivo do Teste** | Verificar inserção dos dados informados. |
| **Passos** | 1. Acessar a página de visualização de itens;<br>2. Clicar no botão "Excluir" do item desejado. |
| **Critério de Êxito** | Excluir o item com sucesso. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O botão "Excluir Item" remove corretamente o item selecionado do banco de dados e somente na lista de favoritos do usuário logado. |

## Registro de Testes Não Funcional

| **Caso de Teste** | **RNF-01 – Interface intuitiva e clara** |
|:---:|:---:|
| **Requisito Associado** | RNF-001 - O sistema deve ter interface de usuário intuitiva e clara. |
| **Objetivo do Teste** | Verificar se a interface do sistema é fácil de entender e usar para os usuários. |
| **Passos** | 1. Observar a disposição dos elementos na tela.<br>2. Interagir com os botões e menus para realizar tarefas comuns. |
| **Critério de Êxito** | Os usuários devem ser capazes de completar as tarefas designadas sem dificuldades significativas, demonstrando compreensão e eficiência na navegação. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. A interface do sistema é intuitiva e clara, permitindo que os usuários realizem tarefas comuns sem dificuldades significativas. |

| **Caso de Teste** | **RNF-02 – Compatibilidade com Navegadores** |
|:---:|:---:|
| **Requisito Associado** | RNF-002 - O sistema deve ser compatível com os principais navegadores (Google Chrome, Firefox, Microsoft Edge). |
| **Objetivo do Teste** | Verificar se o sistema é compatível com os navegadores especificados sem comprometer sua funcionalidade. |
| **Passos** | 1. Acessar o sistema utilizando Google Chrome, Firefox e Microsoft Edge.<br>2. Verificar se todas as funcionalidades do sistema estão disponíveis e operam corretamente em cada navegador. |
| **Critério de Êxito** | Todas as funcionalidades do sistema devem estar disponíveis e funcionar corretamente nos navegadores Google Chrome, Firefox e Microsoft Edge, sem apresentar problemas de compatibilidade. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema funciona corretamente e sem problemas de compatibilidade nos navegadores testados. |

| **Caso de Teste** | **RNF-03 – Boas Práticas de Codificação** |
|:---:|:---:|
| **Requisito Associado** | RNF-003 - O sistema deve ser desenvolvido seguindo boas práticas e convenções de codificação em C#. |
| **Objetivo do Teste** | Verificar se o código-fonte do sistema adere às boas práticas e convenções de codificação em C#. |
| **Passos** | 1. Revisar o código-fonte em busca de padrões de codificação consistentes e legíveis.<br>2. Verificar se foram aplicadas boas práticas de programação, como encapsulamento, modularidade e legibilidade. |
| **Critério de Êxito** | O código-fonte deve seguir as boas práticas e convenções de codificação em C#, demonstrando consistência, legibilidade e conformidade com os padrões estabelecidos. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O código-fonte segue as boas práticas e convenções de codificação em C#, mostrando consistência, legibilidade e conformidade com os padrões estabelecidos. |

| **Caso de Teste** | **RNF-04 – Autenticação** |
|:---:|:---:|
| **Requisito Associado** | RNF-004 - O sistema deve incluir medidas básicas de segurança, como autenticação de usuários. |
| **Objetivo do Teste** | Verificar se a autenticação permite acesso com as informações de login corretas. |
| **Passos** | 1. Acessar a página de login.<br>2. Completar os campos com informações de um usuário legítimo do sistema.<br>3. Fazer login na aplicação e verificar se foi redirecionado e possui acesso ao sistema. |
| **Critério de Êxito** | 1. Entrar com sucesso no sistema com as informações corretas de login.<br>2. Não conseguir entrar com informações incorretas ou vazias de login. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema permite o acesso com informações de login corretas e impede o acesso com informações incorretas ou vazias. |

| **Caso de Teste** | **RNF-05 – Responsividade** |
|:---:|:---:|
| **Requisito Associado** | RNF-005 - O sistema deve ser responsivo e se adaptar a diferentes tamanhos de tela (desktop, celular, tablet). |
| **Objetivo do Teste** | Verificar se o sistema pode ser utilizado em diferentes tamanhos de tela sem comprometer sua usabilidade. |
| **Passos** | 1. Acessar as diferentes páginas do sistema.<br>2. Alterar o tamanho da janela do navegador para testar tamanhos de tela similares a mobile, tablet e desktop.<br>3. Verificar se os componentes da página se adaptam às mudanças de tamanho de tela e se a usabilidade do sistema se mantém. |
| **Critério de Êxito** | A interface deve se adaptar a diferentes tamanhos de tela, de forma que os elementos continuem visíveis e utilizáveis. |
| **Resultado do Teste** | Sucesso |
| **Conclusão** | O objetivo foi alcançado. O sistema se adapta a diferentes tamanhos de tela, mantendo a visibilidade e usabilidade dos elementos. |

| **Caso de Teste** | **RNF-06 – Modularização** |
|:---:|:---:|
| **Requisito Associado** | RNF-006 - O sistema deve ser desenvolvido de forma modular. |
| **Objetivo do Teste** | Verificar se os módulos do sistema possuem funcionalidade bem definida, coesa e com baixo acoplamento. |
| **Passos** | 1. Para cada módulo, verificar o alinhamento de sua funcionalidade com os requisitos relacionados ao módulo.<br>2. Testar a funcionalidade dos módulos e verificar se realizam a funcionalidade esperada de forma eficaz.<br>3. Verificar se as operações do módulo estão trabalhando para um objetivo comum.<br>4. Verificar o nível de acoplamento entre os módulos e se o módulo depende de outros módulos para exercer sua funcionalidade. |
| **Critério de Êxito** | 1. O módulo deve realizar a funcionalidade esperada de forma eficaz.


