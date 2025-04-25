# Curso de Fundamentos de Entity Framework

By Miguel Teheran

En este ejemplo trabajaremos con modelos el modelo

- Category

- Task

Hasta este momento y me refiero a los videos del curso (video 8)
solo con cambiar la biblioteca instalada Entity Framework a la
biblioteca de base de datos bastaria con poder cambiar de la misma

Por ejemplo este es para slq server

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
```

estos comandos de consulta se utilizaron en algunas cosas que probamos

SELECT * FROM Tareas;
EXEC sp_help 'Tareas';

Para explicarlo de forma sencilla, como si fuera para un niño, y organizar el flujo de ASP.NET Core, aquí tienes los pasos jerárquicos:

Flujo jerárquico para una aplicación ASP.NET Core
Crea el Builder (Constructor de la App):

Se usa WebApplication.CreateBuilder(args) para configurar los servicios que la aplicación necesitará.
Es como preparar todos los ingredientes antes de cocinar.
Configura los Servicios:

Usa builder.Services para agregar funcionalidades, como bases de datos (AddDbContext, AddSqlServer) o controladores (AddControllers).
Piensa en esto como poner las herramientas y reglas que la aplicación usará para trabajar.
Construye la Aplicación:

Llama a builder.Build() para convertir toda la configuración en una aplicación lista para ejecutarse.
Es como armar el platillo con los ingredientes preparados.
Define las Rutas (Caminos):

Usa app.MapGet o app.MapPost para decir cómo la aplicación responderá cuando alguien visite una dirección específica.
Ejemplo: Si alguien va a "/", la aplicación responde con "Hello World!".
Inicia la Aplicación:

Llama a app.Run() para poner todo en marcha y escuchar las solicitudes que llegan al servidor.
Es como abrir el restaurante y empezar a servir comida.
Tabla jerárquica (Mermaid)
Aquí tienes una nueva tabla en formato Mermaid mejorada para visualizar todo el flujo:

mermaid
Copy
Edit
graph TD
    A["WebApplication.CreateBuilder(args)"] --> B["builder.Services"]
    B --> C["AddDbContext<T>()"]
    B --> D["AddSqlServer"]
    B --> E["AddControllers"]
    A --> F["builder.Build()"]
    F --> G["app"]
    G --> H["MapGet('/', () => 'Hello World!')"]
    G --> I["MapGet('/dbconexion', handler)"]
    I --> J["EnsureCreated()"]
    I --> K["IsInMemory()"]
    G --> L["Run()"]

## Cómo usar este flujoWS

Antes de builder.Build(): Configura los servicios que necesitará tu aplicación.

Antes de app.Run(): Define las rutas para las solicitudes.

Después de app.Run(): ¡Tu aplicación ya está en marcha!

Este flujo simplificado y el diagrama te ayudarán a identificar dónde agregar lógica adicional en el código. Si necesitas más ejemplos o ajustes, ¡avísame! 😊
