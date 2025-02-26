# 🔹 Descripcion
ControlEdificioF es un sistema diseñado para la gestión y control eficiente del Edificio F dentro de `ITCA-FEPADE`. Su objetivo es facilitar la administración de recursos como usuarios, equipos, herramientas, centros de cómputo y estudiantes, asegurando un control centralizado y eficiente.

## 🚀 Objetivo del Proyecto
Este sistema está diseñado para ser escalable y fácil de mantener, permitiendo futuras mejoras como integración con APIs externas, gestión de reportes automatizados, y un sistema de notificaciones para los administradores y usuarios.

## 🛠️ Tecnologias Utilizadas
- Arquitectura: *Basado en el patrón de diseño MVVM (Model-View-ViewModel) para una mejor separación de responsabilidades*.
- Principios de desarrollo: *SOLID, DRY (Don't Repeat Yourself) y KISS (Keep It Simple, Stupid)*.
- Lenguaje de programación: *C#, XML*.
- Entorno: *.NET Core 8*.
- Base de datos: *MySQL Server*.
- Frameworks y librerías: *WPF, Material Design*.

## 🛠️ Instalacion
1. Clona el repositorio:
   `git clone https://github.com/Diego503jr/ControlEdificioF.git`.
2. Entra en la carpeta del proyecto:
   `cd ControlEdificioF`
3. Las variables de entorno:
   
   1. Primero crea un `Archivo de Configuracion`
   2. Luego Establece la siguiente estructura al archivo.
      `<?xml version="1.0" encoding="utf-8" ?>
       <configuration>
        	<!--Declaracion de variables de entorno para la conexion a la DB-->
        	<appSettings>
        		<add key="SERVER" value="valor"/>
        		<add key="DATABASE" value="valor"/>
        		<add key="USER" value="valor"/>
        		<add key="PASSWORD" value="valor"/>
        	</appSettings>
       </configuration>`
   3. Finalmente habras creado las variables de entorno

## ▶️ Uso
Para ejecutar el proyecto, solamente presiona `Run` en el IDE Visual Studio.

**📌 Nota:** Antes de realizar un cambio de estilos en XML 

1. Limpiar solucion.
2. Recompilar solucion.
3. Compilar solucion.

**Si esto no funciona:** Cambia las versiones de material-design y vuelve al punto 1

## ✨ Funcionalidades
- Gestión de usuarios con diferentes roles y permisos.
- Control de herramientas y equipos asignados a centros de cómputo. 
- Registro y seguimiento de estudiantes dentro de las instalaciones.
- Sistema modular para facilitar escalabilidad y mantenimiento.

## 📱 Contacto
Para más información, puedes contactarme en [diegocarias789@gmail].
