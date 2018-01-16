# Doa Nota Paraná

O que é?

	-Doa Nota Paraná é um programa para auxiliar no envio de chaves de Notas Fiscais de consumidor eletrônica (NFC-e) para doação a entidades beneficentes cadastradas no programa Nota Paraná. 
	-A ideia do programa é acelerar o processo de doação efetuando a leitura do QR Code presente nas notas e enviando automaticamente para o site do governo do estado. 
	-Anteriormente sem a utilização do programa os usuários precisavam digitar manualmente as chaves de 44 posições no site do governo, tornando o trabalho árduo e cansativo. 
	-Esta solução foi criada pela equipe do Sage Labs Curitiba utilizando o tempo fornecido pelo Sage Foundation, funcionários do gupo britânico Sage Software.

Como instalar:

	Os instaladores e executáveis estão no link:
	https://github.com/rdaron88/DoaNotaParana/releases

	Alternativa 1:
	-Baixe o arquivo setup.zip e descompacte o arquivo.
	-Execute o Setup.exe.
	-Clique em instalar.
	-Ao final da instalação o executável deve estar no menu iniciar.
	
	Alternativa 2:
	-Baixe o arquivo portable.zip e descompacte o arquivo.
	-Copie o executável "Doa Nota Parana.exe" para um local seguro.
	-Basta rodar o executável.

Como utilizar:
	
	-Configurar a entidade e o login na tela de configuração. (Clique na engrenagem no topo superior direito)
		-Basta buscar a entidade e seleciona-la.
		-Colocar o login e senha utilizado para acessar o portal da nota Paraná(ver http://www.notaparana.pr.gov.br/).
	-A imagem deve aparecer automaticamente se a camera estiver conectada corretamente. 	
		-Caso não esteja corretamente configurado clique na no menu de configuração da camera (icone de uma camera).
		-Configure corretamente a camera desejada.

	-Com a camera funcionando corretamente:
		-Posicione o cupom fiscal com o QRCode para a camera.
		-O programa irá tentar efetuar automaticamente a leitura.
		-Se aparecer um "OK" em verde é pq a nota foi lida com sucesso.
		-Se aparecer em vermelho, houve um problema na leitura, e o status do erro será apresentado abaixo da imagem da camera.
		-Obs: Nem todos os QRCodes são legiveis. Fatores como impressão, rasura, qualidade da camera podem interferir no bom funcionamento do programa.

	-Envio automático das notas(chave) para o governo.
		-Para habilitar/desabilitar basta clicar no botão com uma nuvem.
		-Para o envio correto é necessário que o botão de envio esteja ativado. (Nuvem com uma flecha para cima)
		-É possível deixar desabilitado, não efetuando o envio, neste caso o botão irá mostrar uma nuvem com um risco ao meio.
		-Uma exclamação ira aparecer caso exista um erro no envio. Clique no botão para ver mais detalhes.

	-Verificação do histórico de envio.
		-No menu com um grid é possível ver o histórico dos últimos 60 dias.
		-É possivel filtrar os dados desta tabela usando o menu acima da tabela.
		-E também exportar para CSV(Excel).
		-Nesta tabela mostra o status sendo ele:
			-Sucesso: Foi doada com sucesso.
			-Pendente: Ainda não foi enviada.
			-Erro: Não foi possível enviar ou não foi aceita pelo portal. 
		-Coluna “Mensagens de retorno” mostra mais informações do envio.

Informações Adicionais:

	-A nota deve ter sido emitida por uma empresa do Paraná.
	-A nota deve ter sido emitida há menos de 1 mês.
	-As notas aparecerão com erros caso, por algum motivo o estado recuse a doação.
	-O estado não válida se uma nota já foi doada anteriormente para outra instituição. 
	-Entretanto, segundo o regulamento, se a nota for doada para duas instituições distintas elas não terão valor e nenhuma receberá os créditos.

Dicas de uso:

	-As notas devem estar o mais perpendicular possível em relação a câmera. 
	-Algumas notas possuem o QRCode deslocado para um lado. Para melhor leitura dessas notas coloque um fundo que seja parecido com a cor do papel da nota. 


Para Desenvolvedores:

	-Para compilar é necessário remover o " - Sample Without Keys
" deixando apenas a extensão resx do arquivo abaixo.
		-DoaNota/Properties/Resources.resx - Sample Without Keys

	-Neste arquivo é necessário colcoar as chaves de cryptografia.
	-Este arquivo foi removido por questão de segurança e privacidade.

Licença de uso e do código:
	-Este software e seu código estão sob a licença GNU Lesser General Public License v3.0.
	-Este software está sendo distribuido gratuitamente.