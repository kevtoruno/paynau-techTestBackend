# Kevin Toruño Serpa prueba tecnica para Paynau

La arquitectura del backend cuenta de 4 funciones lambdas, y 2 librerias de clases:

- Infraestructure: Aqui está la libreria de EF Core

- Application: Aquí se encuentra la logica de negocio, basada en CQRS y Mediador

- PersonaCreate: (Accidentalmente la carpeta se llama PersonaCRUD) Función lambda para crear registros persona.

- PersonaEdit: Función lambda para editar registros existentes de persona.

- PersonaDelete: Funcion lambda para eliminar registros de persona.

- PersonaEdit: Funcion lambda para editar registros de persona.

<<<<<<< HEAD
API Gateway ENDPOINT: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person

- Obtener personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/get
- Editar personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/edit
- Crear personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/create
- Elimninar personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/delete
=======
API Gateway: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person

SWAGGER UI: https://paynau-techtest-bucket.s3.us-east-2.amazonaws.com/index.html
* Obtener personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/get
* Editar personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/edit
* Crear personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/create
* Elimninar personas: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/delete

Github repo del front end: https://github.com/kevtoruno/paynau-techTest-client

Aplicacion desplegada en AWS Amplify: https://main.d2lz1ksmzb9cu6.amplifyapp.com/
>>>>>>> bfd54f2ab008dcd4c3ef14e9a0a028c4b6a32334
