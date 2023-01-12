Feature: Probar las funcionalidades de producto
 

Scenario: Registrar Producto
    Given la siguiente solicitud
    """
    {
    "Name": "Prueba Entrada",
    "Descripciont": "Local datos",
    "Status": true,
    "Price": 12
    }
    """
    When se solicita "sin" credenciales que se procese a la url "/api/fassil/product", usando el metodo "post"
    Then la respuesta debe tener el codigo de estado 200 
    And la respuesta debe contener un entero