# Postulka.Franco.PrimerParcial

**Titulo:** CRUD-SistemasOperativos

**Sobre Mi:** Soy Franco Postulka, estudiante de la Tecnicatura en Programación en la UTN. Como desarrollador, domino Python, Django, JavaScript, HTML, CSS, Git y GitHub. Este proyecto es parte de mi incursión en C# y el entorno .NET

**Resumen:** Esta aplicación consta de distintos formulario que le permiten al usuario agregar a su listado de sistemas operativos, sistemas MacOS, Linux y Windows. Los sistemas tienen características en común y propias de cada uno, impidiendo la existencia de dos sistemas iguales en el listado. Los mismos pueden modificarse y eliminarse. El listado y los cambios en el mismo son guardados en un archivo de tipo xml, el cual el usuario puede elegir su ubicación o usar la ubicación que la aplicación brinda por defecto. La lista de SO se puede ordenar alfabéticamente y según la cantidad de GB que ocupa el mismo, de manera ascendente y descendente. 

## Diagrama de clases de los Sistemas Operativos.
### Clase padre Sistema Operativo.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/3fbea71f-8498-476e-abd8-1dbfe910255b)
### Clase hija Linux.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/22120933-9e85-4c6d-94a2-01f6d80c2df9)
### Clase hija Windows.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/c69043b6-208b-4b90-b0b9-18859f18c592)
### Clase hija MacOS.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/0931d471-1019-4740-9d65-c141966f51b2)


## Clase Computadora (objeto utilzado como contenedor de sistemas operativos)
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/622016ec-f17e-42a1-b1b0-38e36f1f3f45)

## Digrama de los enumerados.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/9e06792a-8b49-49d5-abfa-d01ffdbb86ae)

## Interfaces.
# Interfaz genérica implementada en la clase SistemaOperativo.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/b7ca429b-983e-4cb1-a205-8440a7f4d0e5)

# Interfaz implementada en los formularios de instalación.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/20cce99c-3aaf-42a7-8a07-3cd77f0a1c72)

## Excepción propia lanzada cuando el usuario ingresa mal los campos al momento de instalar o modificar un SO.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/3899d756-fe94-48d7-a713-3d41bf8d3c66)
