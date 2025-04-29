BACKEND
Se realiza el despliegue del backend con la plantilla de proyectos Blogs of the U. Se implementa para el Proyecto StreetFood 
CONFIGURACIÓN DEL PROYECTO THE BLOGS OF THE U - GUÍA PASO A PASO

1. UBICACIÓN DEL ARCHIVO DE CONFIGURACIÓN:
- Debes localizar el archivo "appsettings.json" que está dentro de la carpeta principal del proyecto (The_Blogs_Of_The_U.Backend).
- Este archivo es clave porque contiene todas las configuraciones de conexión a la base de datos.

2. CONFIGURACIÓN DE LA BASE DE DATOS LOCAL:
- El proyecto usa MySQL como gestor de base de datos.
- Recomendamos instalar MySQL Workbench (es una herramienta gráfica gratuita para gestionar MySQL).
- Debes modificar la sección "MySqlSettings" del archivo appsettings.json con tus datos locales.

3. QUÉ MODIFICAR EN APPSETTINGS.JSON:
Busca esta sección y cámbiala por tus datos:

"MySQLSettings": {
  "host": "localhost",  (o la IP de tu servidor si no es local)
  "port": 3306,         (el puerto de MySQL, normalmente es 3306)
  "db": "nombre_de_tu_bd",  (el nombre que le diste a tu base de datos)
  "dbUser": "tu_usuario",   (normalmente 'root' en desarrollo local)
  "dbPassword": "tu_contraseña"  (la que configuraste al instalar MySQL)
}

4. PASOS DETALLADOS:

a) Instalar MySQL Workbench:
- Descárgalo de la página oficial de MySQL
- Sigue el asistente de instalación
- Configura un usuario y contraseña (recuerda estos datos para appsettings.json)

b) Crear la base de datos:
- Abre MySQL Workbench
- Conéctate a tu servidor local
- Ejecuta el script SQL que crea la base de datos y tablas
  (debes tener este script, normalmente llamado 'database.sql')

c) Verificar la conexión:
- Prueba conectarte desde MySQL Workbench
- Asegúrate que las tablas se crearon correctamente

5. RECOMENDACIONES FINALES:
- Para desarrollo local, puedes usar estas credenciales:
  Usuario: root
  Contraseña: (la que hayas puesto al instalar MySQL)
- Nunca subas este archivo con tus contraseñas reales a GitHub
- Si tienes problemas de conexión, verifica que el servicio MySQL esté corriendo

6. SOLUCIÓN DE PROBLEMAS COMUNES:
- Error de conexión: Revisa que el usuario y contraseña sean correctos
- Puerto bloqueado: Verifica que el firewall no bloquee el puerto 3306
- Servicio no iniciado: Asegúrate que el servicio MySQL esté en ejecución

Una vez configurado correctamente, el proyecto podrá conectarse a tu base de datos local y funcionar normalmente.
