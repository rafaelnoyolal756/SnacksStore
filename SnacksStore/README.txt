Ejecutar usando F5 en visual studio 2017 , la url predeterminada es http://localhost:9002
Prerequisites:
- .net core 2.1
- entity framework 2.1.11 
- SQL server 2014

usuarios predeterminados : administrador "admin" Username = "admin", Password = "admin"
			    normal  Username = "user", Password = "user"
ConnectionString para la base de datos se debe definir en el archivo appsettings.json en el parametro "SnacksStoreDB" : "Server=;Database=;UID=;PWD=;"


Pruebas de metodos del api realizadas en SoapUI en la carpeta /SnacksStoreTest Requests