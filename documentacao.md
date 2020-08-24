<h2>Solicitação para veiculo.api:</h2> https://localhost:44352/api/<br><br><br><br>


<h3>USUARIO</h3><br><br>


• Url: https://localhost:44352/api/Usuario <br>
o	Parâmetros:  {
    "Id" : "0",
    "Nome":"Carlos",
    "Email": "Casdfasd@f",
    "Senha" :"asdfas"
};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores a base de dados;<br>
o	Http: POST;<br>
<br>
• Url: https://localhost:44352/api/Usuario/Logar <br>
o	Parâmetros:  {
    "Email": "Casdfasd@f",
    "Senha" :"asdfas"
};<br>
o	Autenticação: Não Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Autentica acesso;<br>
o	Http: POST;<br>
<br>
•	Url: https://localhost:44352/api/Usuario/{id}<br>
o	Parâmetros: Id do usuario passado na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca o Usuario com o id relacionado na base de dados;<br>
o	Http: GET;<br>
<br>


<h3>RELATÓRIO</h3><br><br>


•	Url: https://localhost:44352/api/Abastecimento/GerarRelatorio/{id_veiculo}/{mes}/{ano}<br>
o	Parâmetros:  Passados na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca o relatório relacionado ao veiculo no período de 1 ano;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Abastecimento/GerarRelatorio/05/2020 <br>
o	Parâmetros:  Passados na url;<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o relátorio no período de 1 ano para todos os veículos;<br>
o	Http: GET;<br>
<br>


<h3>ABASTECIMENTO</h3><br><br>


• Url: https://localhost:44352/api/Abastecimento/GravarAbastecimento <br>
o	Parâmetros:  {
    "id": 0,
        "km": 500,
        "litro": 50.0,
        "valor": 50.00,
        "data": "2020-03-02T00:00:00",
        "posto": "Teste2",
        "tipoCombustivelId": 1,
        "veiculoId": 2,
        "usuarioId": 1
};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores a base de dados;<br>
o	Http: POST;<br>
<br>
•	Url: https://localhost:44352/api/Abastecimento/AlterarAbastecimento <br>
o	Parâmetros:  {
    "id": 4,
        "km": 530,
        "litro": 50.0,
        "valor": 50.00,
        "data": "2020-03-02T00:00:00",
        "posto": "Teste3",
        "tipoCombustivelId": 1,
        "veiculoId": 2,
        "usuarioId": 1
};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
•	Url: https://localhost:44352/api/Abastecimento/BuscarAbastecimento<br>
o	Parâmetros:  Não necessário;<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todos os Abastecimentos cadastrados;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Abastecimento/BuscarAbastecimento{id} <br>
o	Parâmetros:  Id do obastecimento passado na url;<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o Abastecimento relacionado ao Id informado na url;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Abastecimento/ExcluirAbastecimento/{id} <br>
o	Parâmetros:  Id do obastecimento passado na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui o Abastecimento relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>


<h3>VEÍCULO</h3><br><br>


• Url: https://localhost:44352/api/Veiculo/GravarVeiculo <br>
o	Parâmetros:  {"id": 0, "ano": 2008, "placa": "ABCB123",
    "quilometragem": 750,
    "foto": null,
    "modeloVeiculoId": 1,
    "marcaVeiculoId": 1,
    "usuarioId": 1,
    "tipoCombustivelId": 1,
    "tipoVeiculoId": 1
};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores a base de dados;<br>
o	Http: POST;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/AlterarMarcaVeiculo <br>
o	Parâmetros:  {
    "id": 1,
    "ano": 2009,
    "placa": "ABC6123",
    "quilometragem": 790,
    "foto": null,
    "modeloVeiculoId": 1,
    "marcaVeiculoId": 1,
    "usuarioId": 1,
    "tipoCombustivelId": 1,
    "tipoVeiculoId": 1
};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
<br><br>
•	Url: https://localhost:44352/api/Veiculo/BuscarVeiculo<br>
o	Parâmetros:  Não necessário;<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todos os Veiculos cadastrados;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarVeiculo/{id} <br>
o	Parâmetros:  Id do veiculo passada na url;<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o Veiculo relacionado ao Id informado na url;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/ExcluirVeiculo/{id} <br>
o	Parâmetros:  Id do veiculo passado na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui Veiculo relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>


<h3>MARCA VEÍCULO</h3><br><br>


• Url: https://localhost:44352/api/Veiculo/GravarMarcaVeiculo <br>
o	Parâmetros:  { "Id" : "0", "Nome":"Honda" };<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores abase de dados;<br>
o	Http: POST;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/AlterarMarcaVeiculo <br>
o	Parâmetros:  { "Id" : "1", "Nome":"Honda" };<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
<br><br>
•	Url: https://localhost:44352/api/Veiculo/BuscarMarcaVeiculo<br>
o	Parâmetros:  Não necessário;<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todas as Marcas de Veiculos cadastradas;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarMarcaVeiculo/{id} <br>
o	Parâmetros:  Id da marca do veiculo passada na url;<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca a Marca de Veiculo relacionado ao Id informado na url;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/ExcluirMarcaVeiculo/{id} <br>
o	Parâmetros:  Id da marca do veiculo passada na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui a Marca de Veiculo relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>


<h3>MODELO VEÍCULO</h3><br><br>


•	Url: https://localhost:44352/api/Veiculo/GravarModeloVeiculo<br>
o	Parâmetros:  {"Id" : "0", "Nome":"Fusca"};<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores abase de dados;<br>
o	Http: POST;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/AlterarModeloVeiculo <br>
o	Parâmetros: {"Id" : "1", "Nome":"Gol"}<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarModeloVeiculo<br>
o	Parâmetros:  Não necessário<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todos os Modelos de Veiculos cadastrados;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarModeloVeiculo/{id} <br>
o	Parâmetros:  Id da marca do veiculo passada na url<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o Modelo de Veiculo relacionado ao Id informado na url;<br>
o	Http: GET;<br>

•	 Url: https://localhost:44352/api/Veiculo/ExcluirModeloVeiculo/{id} <br>
o	Parâmetros:  Id da marca do veiculo passada na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui o Modelo de Veiculo relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>


<h3>TIPO COMBUSTÍVEL</h3><br><br>


•	Url: https://localhost:44352/api/Veiculo/GravarTipoCombustivel 
o	Parametros: {"Id" : "0", "Nome":"Gasolina"}
o Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores abase de dados;<br>
o	Http: POST;<br>
•	Url: https://localhost:44352/api/Veiculo/AlterarModeloVeiculo <br>
o	Parâmetros: {"Id" : "1", "Nome":"Alcool"}<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarTipoCombustivel<br>
o	Parâmetros:  Não necessário<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todos os Tipos de Combustivel cadastrados;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarTipoCombustivel/{id} <br>
o	Parâmetros:  Id do Tipo de Combustivel passada na url<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o Tipo de Combustivel relacionado ao Id informado na url;<br>
o	Http: GET;<br>

•	 Url: https://localhost:44352/api/Veiculo/ExcluirTipoCombustivel/{id} <br>
o	Parâmetros:  Id do Tipo de Combustivel passado na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui o Tipo de Combustivel relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>


<h3>TIPO DE VEICULO</h3><br><br>


•	Url: https://localhost:44352/api/Veiculo/GravarTipoVeiculo
o	Paremetros: {"Id" : "0", "Nome":"Moto"}
o Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Adiciona Valores abase de dados;<br>
o	Http: POST;<br>
•	Url: https://localhost:44352/api/Veiculo/AlterarTipoVeiculo <br>
o	Parâmetros: {"Id" : "1", "Nome":"Carro"}<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Altera valores a base de dados com base no Id informado;<br>
o	Http: PUT;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarTipoVeiculo<br>
o	Parâmetros:  Não necessário<br>
o	Autenticação: Necessária;<br>
o	Retorno: JSON;<br>
o	Funcionalidade: Busca todos os Tipos de Veiculos cadastrados;<br>
o	Http: GET;<br>
<br>
•	Url: https://localhost:44352/api/Veiculo/BuscarTipoVeiculo/{id} <br>
o	Parâmetros:  Id do Tipo de Veiculo passada na url<br>
o	Autenticação: Necessária;<br>
o	Formato de Retorno: JSON;<br>
o	Funcionalidade: Busca o Tipo de Veiculo relacionado ao Id informado na url;<br>
o	Http: GET;<br>

•	 Url: https://localhost:44352/api/Veiculo/ExcluirTipoVeiculo/{id} <br>
o	Parâmetros:  Id do Tipo de Veiculo passado na url;<br>
o	Autenticação: Necessária;<br>
o	Retorno: Sem retorno;<br>
o	Funcionalidade: Exclui o Tipo de Veiculo relacionado ao Id informado na url;<br>
o	Http: DELETE;<br>
<br>






