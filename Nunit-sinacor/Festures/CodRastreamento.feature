Feature: CodRastreamento

A short summary of the feature

@CodRastreamentoInvalido
Scenario: Consultar o rastreamento com código inválido
	Given Que eu acesse o site LinkCorreios
	When Preencha o campo de código de rastreamento com o valor "SS987654321BR"
	And Clique no botão de pesquisar
	Then A página retornará com o texto "O rastreamento não está disponível no momento"
