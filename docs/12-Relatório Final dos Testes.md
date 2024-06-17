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

