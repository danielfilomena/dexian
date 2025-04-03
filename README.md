<h1>Dexian</h1>
<h2>Avaliação Angular Full-Stack</h2>


<h3>Objetivo</h3>
<p>
Desenvolver uma aplicação CRUD utilizando o framework Angular para o front-end e .NET para o back-end. O armazenamento dos dados será feito em memória, sem necessidade de banco de dados.  
</p>

<h3>1 - Back-end</h3>
<h4>Requisitos</h4>
<p>
Criar uma API utilizando .NET.
Implementar endpoints para manipulação de dados de Alunos e Escolas.
Os dados deverão ser armazenados em memória.
No endpoint de login, criar um token JWT para acesso aos endpoints internos de Alunos e Escolas.  
</p>

Modelos de Dados
Alunos
iCodAluno (número inteiro, identificador único)
sNome (string, nome do aluno)
dNascimento (data, data de nascimento)
sCPF (string, CPF do aluno)
sEndereco (string, endereço)
sCelular (string, telefone celular)
iCodEscola (número inteiro, identificador da escola associada)
Escolas
iCodEscola (número inteiro, identificador único)
sDescricao (string, descrição da escola)
Usuários
iCodUsuario (número inteiro, identificador único)
sNome (string, nome do usuário)
sSenha (string, senha do usuário)
Ferramentas recomendadas
Visual Studio (opcional)
2 - Front-end
Requisitos
Desenvolver a interface utilizando Angular, consumindo a API criada.
Criar uma página de Login como tela inicial (credenciais fixas para acesso: USUÁRIO: TESTE, SENHA: 123).
Criar uma página de Listagem de alunos, acessada após o login.
Criar uma página de Listagem de escolas, associada aos alunos.
Implementar as operações CRUD (Incluir, Alterar e Excluir) para Alunos e Escolas.
Criar um menu de navegação para acesso às listas de Alunos e Escolas.
Incluir um botão de sair no menu para retornar à tela de login.
Implementar máscaras nos campos onde necessário (ex.: CPF, telefone, data de nascimento).
Criar um campo de pesquisa na lista de Alunos (busca por Nome e CPF).
Criar um campo de pesquisa na lista de Escolas (busca por Descrição).
Garantir que o layout seja responsivo (mobile) e amigável.
Utilizar Bootstrap, Material UI ou outro framework de componentes para estilização.
Organizar o projeto utilizando components, classes e services.
Aplicar boas práticas de estruturação de código e indentação.
Ferramentas recomendadas
Node.js
Gerenciador de pacotes (NPM)
Visual Studio Code (opcional)
3 - Observações sobre as aplicações criadas (opcional)
Caso tenha alguma observação sobre o desenvolvimento, descreva aqui.

4 - Portfólio e Experiência (opcional)
Coloque aqui seus projetos (GitHub, GitLab, entre outros) ou descreva projetos nos quais você tenha trabalhado.

Critérios de Avaliação
✅ Correta implementação dos requisitos.
✅ Boas práticas de desenvolvimento.
✅ Estrutura e organização do código.
✅ Layout responsivo e usabilidade.
✅ Uso adequado de componentes e serviços no Angular.
