# PruebaTecnicaWordBox

El proyecto se creo tomando las referencias de la Clean Arquitecture lo mas posible.

Durante el desarrollo se intento utilizar UniRX pero para los casos de los comandos reactivos y propiedades reactivas, estas fallaron. Y para no atrasar mas el tiempo. Este se remplazo por Action's de System.

Se utilizo Unitask de forma exitosa

Durante el desarrollo me di cuenta que la URL que mandaron estaba errada ya que en la URL pedia que fuera de un callback de Javascript parece ser. La cual se quito este parametro para que regresara un JSON puro.

No se realizaron pruebas unitarias ya que por falta de tiempo no se lograron escribir.

Se utilizaron los siguientes patrones:
- MVVM, como variacion donde se utliza tanto un controlador como un presentador para desacoplar lo mas que se pudo
- ServiceLocator, para registrar eventos globales y poder accederlos y ejecutarlos

Cosas que se pudieron haber hecho mejor con mas tiempo:
- Implementar correctamente el UniRx
- Crear los TDD
- Aplicar refactors, ya que hay algunas dependencias en funcionalidades criticas
- Realizar pruebas manuales para validar algunos casos, como: Si una URL de imagen esta rota, o si el nombre no tiene el UTF-8, entre otros.
- Crear documentacion de las dependencias del codigo


En general me diverti mucho realizando la prueba tecnica, espero les guste.

Si no es mas: Luis Plata (PeryLoth)