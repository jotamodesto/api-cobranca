# API Cobrança
## Modos de utilizar

### Cadastrar Usuários (POST api/Users)
Enviar o JSON no seguinte formato: 
> { Name": "Foo Bar", "Email": "foo@bar.com", "CardId": "1234567890123456", "Password": "foobar" }
O Endpont retornará um erro se o mesmo e-mail já estivar cadastrado.

### Recuperar Usuários (GET api/Users)
O Retorno será como no exemplo:
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

### Cadastrar Débito (POST api/Debits) (este endpoint requer autorização)
Enviar o JSON no seguinte formato: 
> { "CardId": "1234567890123456", "Code": "(Código do ônibus)", "Value": 0.00 }
O Endpoint retornará um erro se cadastrar um CardId que não tiver sido cadastrado no Endpoint POST api/Users

### Recuperar Débitos Cadastrados (GET api/Debits/?cardId={número cartão}&initialDate={Data Inicial}&finalDate={Data Final}) (os parâmetros são opcionais)
O Retorno será como no exemplo:
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