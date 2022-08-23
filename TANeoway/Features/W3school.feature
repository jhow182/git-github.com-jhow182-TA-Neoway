Feature: W3school

@mytag
Scenario: Acesso à página: How To Make a Modal Box With CSS and JavaScript
	Given que acessei o site da WSchool
	#Teste 01
	And que usei a navegação principal para a modal Boxes
	And que usei a navegação lateral para a abrir modal Boxes
	Then verifico se a modal Boxes foi exibida
	And fecho a modal boxes	
	Then verifico se a modal boxes não está mais visível

Scenario: Acesso à página: HTML Color Groups
	Given que acessei o site da WSchool
	And que usei a navegação principal para a abrir Grupos de Cores
	And que usei a navegação lateral para a abrir Grupo de Cores
	Then verifico se a "Cor" está igual  a "Hexadecimal"
	
	Examples: 
	| Cor        | Hexadecimal |
	| Black      |   #000000   |
	| Maroon     |   #800000   |
	| Gold       |   #FFD700   |
	| Cyan       |   #00FFFF   |
	| Blue       |   #0000FF   |
	| Silver     |   #C0C0C0   |
	| BlueViolet |   #8A2BE2   |


Scenario: Acesso à página: HTML Forms e Tryit Editor v3.7 - HTML Forms
	Given que acessei o site da WSchool
	And que usei a navegação principal para a formulários HTML
	And que usei a navegação lateral para a abrir formulários HTML
	Then na nova aba aberta, envio meu nome "Jonathan" e sobrenome "Coelho"
	Then verifico se o meu nome "Jonathan" e sobrenome "Coelho" foram enviados corretamente