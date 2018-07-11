#language: pt-br

Funcionalidade: Acesso
	Realizar acesso ao sistema

@CT001_RealizarLoginDadosValidos
Cenario: CT001-Realiza login dados validos
	Dado que forneço os dados válidos de usuário "Admin" e senha "admin123"
	Quando efetuo click no botão login
	Entao o usuário deve ser redirecionado para home page

@CT002_RealizarLoginComSenhaIncorreta
Cenario: CT002-Realiza login com senha incorreta
	Dado que forneço os dados válidos de usuário "Admin" e senha "admin"
	Quando efetuo click no botão login
	Entao é apresentada a mensagem "Invalid credentials"