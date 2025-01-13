# Kevin Toruño Serpa prueba tecnica para Paynau

La estructura del proyecto cuenta de 4 funciones lambdas, 2 librerias de clases y un proyecto para de pruebas para probar el flujo CRUD completo:

1. **Infraestructure:** Aqui está la libreria de EF Core

2. **Application:** Aquí se encuentra la logica de negocio, basada en CQRS y Mediador

3. **PersonaCreate:** (Accidentalmente la carpeta se llama PersonaCRUD) Función lambda para crear registros persona.

4. **PersonaEdit:** Función lambda para editar registros existentes de persona.

5. **PersonaDelete:** Funcion lambda para eliminar registros de persona.

6. **PersonaEdit** Funcion lambda para editar registros de persona.

7. **PersonasTest** Prueba Unitaria para probar el flujo CRUD completo.

La cadena de conexión de la BD está hardcoded en el proyecto por cuestiones de usabilidad, no es necesario configurar nada, el servidor en AWS RDS se mantendrá activo.

## API

Ruta API: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person

Contiene los siguientes endpoints:
- **person/get**: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/get
- **person/create**: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/create
- **person/delete**: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/delete
- **person/edit**: https://9jpxq58d04.execute-api.us-east-2.amazonaws.com/paynautechtest/person/edit

Se puede probar el API, en la siguiente documentación SWAGGER: 
- https://paynau-techtest-bucket.s3.us-east-2.amazonaws.com/index.html

## Ejecutar pruebas unitarias

Se utilizó la libreria "xUnit", para probar el proyecto: 
1. En el "Test Explorer", unicamente darle al boton de "Run all tests".
2. También, se puede probar corriendo el siguiente comando "dotnet test"

**Repositorio front end:** https://github.com/kevtoruno/paynau-techTest-client

**Aplicación desplegada en AWS Amplify:** https://main.d2lz1ksmzb9cu6.amplifyapp.com/
