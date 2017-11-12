# API Cobran�a
## Modos de utilizar

### Cadastrar Usu�rios (POST api/Users)
Enviar o JSON no seguinte formato: 
> { Name": "Foo Bar", "Email": "foo@bar.com", "CardId": "1234567890123456", "Password": "foobar" }

### Recuperar Usu�rios (GET api/Users)
O Retorno ser� como no exemplo:
> [
    {
        "Name": "Foo Bar",
        "Email": "foo@bar.com",
        "CardId": "1234567890123456",
        "Password": "foobar"
    },
    {
        "Name": "Foo Bar 2",
        "Email": "foo2@bar.com",
        "CardId": "1234567890123457",
        "Password": "foobar2"
    }
]
