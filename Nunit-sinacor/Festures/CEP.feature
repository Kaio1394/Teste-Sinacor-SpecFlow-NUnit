Feature: CEP

A short summary of the feature

Background: 
	Given Navegar para o site dos correios

@CEP_Invalido
Scenario: Consultar CEP com dados inválidos
	And Preencher o campo do CEP com valor "80700000"
	And Clique em buscar CEP
	Then A página irá retornar a mensagem "Dados não encontrado"

@CEP_Valido
Scenario: Consultar CEP com dados válidos	
	And Preencher o campo do CEP com valor "01013-001"
	And Clique em buscar CEP
	Then O campo "street" da tabela retornará o valor "Rua Quinze de Novembro - lado ímpar"
	And O campo "uf" da tabela retornará o valor "São Paulo/SP"