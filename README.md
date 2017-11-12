# API Cobran�a
## Modos de utilizar

### Cadastrar Usu�rios (POST api/Users)
Enviar o JSON no seguinte formato: 
> { Name": "Foo Bar", "Email": "foo@bar.com", "CardId": "1234567890123456", "Password": "foobar" }
O Endpont retornar� um erro se o mesmo e-mail j� estivar cadastrado.

### Recuperar Usu�rios (GET api/Users)
O Retorno ser� como no exemplo:
>[
>    {
>        "Name": "Foo Bar",
>        "Email": "foo@bar.com",
>        "CardId": "1234567890123456",
>        "Password": "foobar"
>    },
>    {
>        "Name": "Foo Bar 2",
>        "Email": "foo2@bar.com",
>        "CardId": "1234567890123457",
>        "Password": "foobar2"
>    }
>]

### Cadastrar D�bito (POST api/Debits) (este endpoint requer autoriza��o)
Enviar o JSON no seguinte formato: 
> { "CardId": "1234567890123456", "Code": "(C�digo do �nibus)", "Value": 0.00 }
O Endpoint retornar� um erro se cadastrar um CardId que n�o tiver sido cadastrado no Endpoint POST api/Users

### Recuperar D�bitos Cadastrados (GET api/Debits/?cardId={n�mero cart�o}&initialDate={Data Inicial}&finalDate={Data Final}) (os par�metros s�o opcionais)
O Retorno ser� como no exemplo:
>[
>    {
>        "id": "1234567890123456",
>        "debitedAt": "2017-11-12T16:30:46.85",
>        "value": 5
>    },
>    {
>        "id": "1234567890123456",
>        "debitedAt": "2017-11-12T16:56:10.863",
>        "value": 10
>    }
>]