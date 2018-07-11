#language: pt-br

Funcionalidade: Cadastrar
	Realiza cadastro de usuários

Contexto: Efetua login no sistema
	Dado que forneço os dados válidos de usuário "Admin" e senha "admin123"
	Quando efetuo click no botão login
	Entao o usuário deve ser redirecionado para home page

@CT003_CadastrarUsuarios
Cenario: CT003-CadastrarUsuarios
	Dado que acesso o menu "Admin"
	Quando efetuo click no botão Add
	Entao cadastro e valido inclusão do(s) usuário(s)
	| UserRole | EmployeeName | UserName | Status  | Password |
	| ESS      | Fiona Grace  | teste1   | Enabled | 12345678 |
	| ESS      | Fiona Grace  | teste2   | Enabled | 12345678 |
	| ESS      | Fiona Grace  | teste3   | Enabled | 12345678 |
	| ESS      | Fiona Grace  | teste4   | Enabled | 12345678 |