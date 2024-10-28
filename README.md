# 📚 Projeto Toly ID
Este é o Toly ID, a plataforma construída sob medida para a catalogação e monitoramento da espécie `Tolypeutes tricinctus`, mais conhecida como `Tatu-bola-do-nordeste`.

A espécie se encontra em extinção, restando cerca de apenas 100 indivíduos na natureza. Dessa forma, tomamos para nós a dor do curso de Medicina Veterinária e iniciamos a construção de uma plataforma para ajudar na pesquisa e preservação dessa espécie.

## 💔 Dor do Cliente
A catalogação da espécie mencionada se dava por meio do implante de um microchip em cada indivíduo capturado, onde tal processo segue os seguintes passos:

 - Capturar o animal
 - Sedar o mesmo, já que o mesmo se fecha para se proteger e sua carcaça é EXTREMAMENTE, resistindo até mesmo a mordidas de onça
 - Implantar o microchip
 - Realizar exames
 - Realizar coleta de amostras, fezes por exemplo
 - Realizar medições no corpo do animal
 - Devolver o indivíduo a natureza

Para realizar os procedimentos em cada indivíduo leva certo tempo, pois para implantar o microchip é necessário sedar cada animal e esperar que cada individuo relaxe, espondo a parte inferior ao seu corpo que não é protegida pela carcaça.

Além do tempo para sedar o animal, para realizar certos exames, intervalos de tempo entre procedimentos é necessário. Além disso, o método atual é invasivo, pois necessita de implantar um microchip no animal para que o mesmo fique `marcado` e possa ser identificado por outros pesquisadores caso o encontrem e realizar a comparação com os dados que já foram anteriormente capturados em outras coletas e tornar possível o acompanhamento do ciclo de vida do indivíduo.

## 📌 Objetivo Principal
A ideia inicial do projeto é a construção de uma plataforma onde a porta de entrada seria um smartphone. Com esse dispositivo em mãos, o pesquisador iria capturar o indivíduo e, por mais que o mesmo se feche para se proteger, com uma simples foto do `escudo cefálico` do indivído, já seria o suficiente para identificar o animal, sem a necessidade de um microchip, já que as placas do escuto encefálico formam um padrão único para cada indivíduo de espécie.

Após capturar o animal, o mesmo seria sedado e submetido aos procedimentos de exames e medidas. Todas as informações coletadas seriam registradas no aplicativo do smartphone. Com as informações cadastradas na plataforma, seria possível realizar uma comparação no local de captura se o animal já foi capturado anteriormente ou se é a sua primeira vez.

Além de facilitar o processo de campo, a plataforma teria o objetivo de conectar diferentes pesquisadores, centralizando a informação. Com a informação armazenada em um só lugar, diversos pesquisadores poderiam utilizar tais dados para contribuir com a preservação da espécie, além é claro, de estudar os dados coletados resultando em novas descobertas sobre a espécie.

## ✅ Resultado Alcançado Atualmente - 14/06/2024
Temos um esboço do aplicativo para smartphone, onde o mesmo é capaz de receber dados e gravar em um banco de dados para que as informações sejam armazenadas localmente para posteriormente serem sincronizadas com o servidor da plataforma por meio de uma API.

Duas funcionalidades importantíssimas ainda não implementadas foram o reconhecimento do escudo encefálico e a armazenagem de uma foto do animal no momento da captura. Para solucionar parcialmente o problema, encontramos uma saída para a identificação do animal, onde o número do microchip será salvo no cadastro de cada indivíduo.

A partir desse ponto, por mais que não esteja concluído o projeto, o mesmo já trará benefícios, como centralizar a informação em um só lugar, facilitando a preservação e estudo da espécie.

A primeiro momento, os dados estão permanecendo apenas no aplicativo de smartphone. Mais tarde uma API será construída a fim de centralizar os dados de todos os pesquisadores em um só lugar.

O último ponto a ser mencionado é que o aplicativo foi testado apenas em smartphone `Android`. Por mais que as plataformas `C#` e `MAUI` suportarem desenvolvimento praticamente para qualquer plataforma, devido a carência de equipamento específico, não foi possível realizar os testes em disposivos que rodam `iOS` e `iPad OS`.

## ⚙️ Funcionalidades
### 1 - Listagem de Animais Cadastrados
Essa tela é responsável por listar todos os animais que estão cadastrados no sistema. Durante a operação em campo, os animais recém capturados ficarão salvos somente no smartphone, posteriormente, quando o celular se conectar a internet, os registros locais serão enviados ao servidor da aplicação, realizando uma sincronização.
<p align="center">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/1-animais-cadastrados-vazio.png" alt="1-animais-cadastrados-vazio">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/3-animais-cadastrados.png" alt="3-animais-cadastrados">
</p>

### 2 - Cadastro de Animais
Esta tela é responsável por realizar o cadastro dos animais capturados durante as operações em campo.

Para cada categoria de cadastro existe uma tela específica para tal. Seguem demonstrações:

<p align="center">Adicionar Identificador do Animal e Microchip</p>
<p align="center">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/2-cadastro-de-tatu.png" alt="2-cadastro-de-tatu">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/5-adição-do-microchip.png" alt="5-adicao-do-microchip">
</p>

<p align="center">Captura de Dados Gerais, Captura de Dados da Ficha Anestésica</p>
<p align="center">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/6-captura-dados-gerais.png" alt="6-captura-dados-gerais">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/7-captura (ficha anestésica).png" alt="7-captura (ficha anestésica)">
</p>

<p align="center">Captura de Dados Biométricos, Captura de Dados de Amostra</p>
<p align="center">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/8-captura-biometria-.png" alt="8-captura-biometria-">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/9-captura-amostras.png" alt="9-captura-amostras">
</p>

### 3 - Exibir Ficha do Animal Cadastrado
Esta tela é responsável por exibir os dados de cada animal cadastrado, ou seja, em cada registro exibido na tela o aplicativo irá exibir todas as informações pertinentes a ele.

O Toly ID atualmente está montado da seguinte forma. Ao escolher um dos animais da tela, abrirá um menu com todas as capturas que ele já teve. Posteriormente, clicando sobre a captura específica o aplicativo irá exibir todos os dados pertinentes ao animal escolhido, na captura selecionada. Seguem demonstrações:
<p align="center">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/4-tatu-cadastrado.png" alt="4-tatu-cadastrado">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/10-tatu-com-cadastros-e-chip.png" alt="10-tatu-com-cadastros-e-chip">
  <img height="600" src="https://github.com/gPagio/multivix-pei-III-toly-id-mobile/blob/main/Docs/11 - captura cadastrada.png" alt="11 - captura cadastrada">
</p>
