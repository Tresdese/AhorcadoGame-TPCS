# El Juego del Ahorcado — Segunda revisión

> Documento convertido a Markdown desde `Ahorcado-documentacion_Axel-Darlington-Mariana_2da-Entrega.pdf`.
> Los diagramas originales (despliegue y componentes) son imágenes UML; aquí se describen como `[FIGURA: ...]` con su contenido transcrito.

## Portada

- **Institución:** Universidad Veracruzana — Región Xalapa, Facultad de Estadística e Informática
- **Licenciatura:** Ingeniería de Software
- **Experiencia educativa:** Tecnologías para la construcción de software
- **Docente:** Ramón Gómez Romero
- **Trabajo:** El juego del Ahorcado (Segunda revisión)
- **Autores:** Darlington Diego Delgado Santiago; Mariana Soria Vázquez; Axel Gabriel Ramírez González
- **Fecha de entrega:** 05 de junio de 2026

## Contenido

- 1. Problema
- 2. Estados a mantener
  - Estado persistente (SQL Server, vía Entity Framework y los DAO)
  - Estado volátil de sesión (en memoria del servidor)
- 3. Justificación de decisiones
  - Servicio dúplex en lugar de petición–respuesta
  - Separación de estado persistente y volátil
  - Instancia singleton
  - Servidor como autoridad
  - NetTcpBinding
- 4. Diagrama de despliegue
- 5. Diagrama de componentes

## 1. Problema

El Ahorcado es un juego para dos jugadores (Jugador creador y Jugador adivinador) ejecutándose en dos aplicaciones WPF independientes, que solo se comunican a través del servidor WCF. Esto plantea un problema que no resuelve un servicio web tradicional de petición–respuesta: cuando un jugador realiza una acción, el otro debe enterarse de inmediato, sin haberla solicitado. Esto significa que se necesita una comunicación bidireccional del servidor hacia el cliente (server-push), además de la persistencia de los datos del juego.

## 2. Estados a mantener

Se distinguen dos clases de estado, con mecanismos de implementación distintos.

### Estado persistente (SQL Server, vía Entity Framework y los DAO)

Es la información que debe sobrevivir al cierre de la partida y de la aplicación, y que constituye la fuente de verdad:

- **usuario:** credenciales y perfil.
- **partida.estado:** "Disponible", "EnCurso", "Finalizada", "Cancelada".
- **palabra y categoría:** banco de palabras por idioma.
- **movimiento:** bitácora de letras ingresadas en cada partida.
- **historial_puntaje:** resultado de cada partida (ganada, rival no adivinó, penalización) para el desglose del CU-13.

### Estado volátil de sesión (en memoria del servidor)

Información que solo tiene sentido mientras la partida está activa y que cambia muchas veces por segundo:

- Qué usuarios están conectados y su canal de callback.
- Qué jugadores están dentro de cada sala (idPartida).
- La palabra en juego, las letras ya usadas, los intentos restantes y de quién es el turno.

## 3. Justificación de decisiones

### Servicio dúplex en lugar de petición–respuesta

El sistema exige que una acción de un jugador se refleje de inmediato en la otra sesión. Un servicio petición–respuesta no puede iniciar comunicación hacia el cliente; el dúplex permite que el servidor empuje (server-push) el evento justo cuando ocurre, evitando polling (latencia y carga innecesaria a la BD).

### Separación de estado persistente y volátil

Persistir cada letra como única vía de sincronización obligaría a consultar la BD constantemente. Mantener la partida viva en memoria da respuesta inmediata, mientras la BD conserva solo lo durable y auditable (resultados, puntajes, movimientos).

### Instancia singleton

Una sola instancia compartida permite que el servidor vea a ambos jugadores y reenvíe eventos entre ellos; con instancias PerCall/PerSession sería imposible.

### Servidor como autoridad

Centralizar la lógica garantiza que ambas vistas sean consistentes.

### NetTcpBinding

Es full-duplex nativo y de baja latencia, adecuado para el escenario LAN del sistema.

## 4. Diagrama de despliegue

[FIGURA: Diagrama de despliegue UML]

Nodos y artefactos:

- **«device» PC Jugador Creador** → artefacto `Ahorcado.exe`
- **«device» PC Jugador Adivinador** → artefacto `Ahorcado.exe`
- Ambas PC se conectan al servidor de aplicaciones mediante **«TCP/IP»**.
- **«device» Servidor de aplicaciones** → artefacto `AhorcadoService.scv`
- El servidor de aplicaciones se conecta a la base de datos mediante **«ADO.NET»**.
- **«device» Servidor de base de datos** → artefacto `AhorcadoDB.sql`

## 5. Diagrama de componentes

[FIGURA: Diagrama de componentes UML — "cmp Especificación de componentes"]

Componentes («comp spec») con su interfaz provista («interface type»):

- **IAutenticacionMgr** — provee `IAutenticacionMgt`
- **IUsuarioMgr** — provee `IUsuarioMgt`
- **IPartidaMgr** — provee `IPartidaMgt`
- **IPalabraMgr** — provee `IPalabraMgt`
- **IJuegoMgr** — provee `IJuegoMgt`
- **IPuntajeMgr** — provee `IPuntajeMgt`

---

# Anexo: Definición oficial del Proyecto Final (especificación del docente)

> Convertido desde `Proyecto_CALENDARIO.pdf`. Es la consigna original del Mtro. Ramón Gómez Romero (Tecnologías para la Construcción de Software, feb–jul 2026), no producción del equipo. Sirve como fuente de requisitos para la documentación del Ahorcado.

## Calendario de entregas — Proyecto Final

### 1.ª Revisión: 27 de mayo de 2026

Entregables:

- Modelo Relacional COMPLETO.
- Prototipo del juego COMPLETO.
- Diagrama de Casos de Uso de TODA la solución.
- Descripciones completas de todos los Casos de Uso.

### 2.ª Revisión: 05 de junio de 2026

Entregables:

- Diagrama de despliegue.
- Diagrama de componentes.
- Proyecto de WCF con la implementación de todos los servicios que hacen consultas.
- Proyecto de WPF con todas las interfaces gráficas de usuario diseñadas (sin conexión a servicios WCF o sockets).
- Descripción y justificación de la implementación a realizar, para mantener el estado, control y flujo de comunicación del juego entre las sesiones que participen.

## Definición del proyecto: El juego del Ahorcado

El Ahorcado es un juego para dos jugadores, en el cual un jugador (Jugador 1) piensa una palabra y el otro la intenta adivinar (Jugador 2).

Usando una fila de guiones, se representa la palabra a adivinar, dando el número de letras, descripción de la palabra y categoría.

Si el jugador adivinador (2) sugiere una letra o número que aparece en la palabra, el otro jugador (1) la escribe en todas sus posiciones correctas. Si la letra o el número propuesto no existen en la palabra, el otro jugador (1) dibuja una parte del cuerpo del ahorcado como una marca de conteo. El muñeco que se va dibujando tiene 6 partes (cabeza, cuerpo, dos brazos y dos piernas), por lo que el jugador tiene 6 opciones de fallar.

[FIGURA: Ilustración 1 — Visualización de las oportunidades falladas por el jugador 1. Muestra la secuencia de 6 estados del dibujo del ahorcado, agregando una parte del cuerpo (cabeza, cuerpo, brazos y piernas) por cada fallo.]

El juego termina cuando:

- El jugador adivinador (2) completa la palabra correctamente.
- El jugador (1) completa el dibujo con todas las partes del ahorcado.
- El adivinador (Jugador 2) o el Jugador 1 decide abandonar la partida. El jugador que solicite cerrar la partida debe ser penalizado.

## Arquitectura

El desarrollo del juego debe implementarse utilizando una arquitectura cliente–servidor con el uso de servicios web.

[FIGURA: Diagrama de arquitectura cliente–servidor]

Componentes y su comunicación:

- **Servidor de base de datos** ⟷ **Aplicación de servicios web (WCF) / Aplicación con sockets**
- La aplicación de servicios web se comunica de forma bidireccional con:
  - **Aplicación (WPF) de escritorio — Jugador 1**
  - **Aplicación (WPF) de escritorio — Jugador 2**

## Funcionalidades requeridas

Basadas en la descripción del juego:

- **Inicio de sesión:** ingresar las credenciales de un usuario registrado (correo electrónico y contraseña) para acceder al juego.
- **Registro de usuario:** para dar de alta un usuario se debe ingresar nombre completo, fecha de nacimiento, teléfono celular, correo electrónico (único por usuario) y password de acceso.
- **Lista de partidas disponibles:** al ingresar al juego se muestra la lista de partidas disponibles que otros usuarios han generado y que aún no cuentan con un jugador para adivinar. Se debe mostrar el usuario que comenzó la partida (nombre y correo) y la fecha de creación. Al ingresar a una partida disponible, el usuario será el retador (quien adivinará la palabra) y empezará el juego.
- **Generar una partida nueva:** el usuario que inició sesión puede solicitar la creación de una nueva partida en la cual será el retado de otro jugador para que este último adivine la palabra del ahorcado. Una vez generada la partida, el usuario deberá esperar a que algún jugador acepte o ingrese a su partida para iniciar el juego. Antes de iniciar la partida se debe seleccionar con qué palabra o palabras se iniciará (las palabras están asociadas por categorías).
- **Jugar partida:** al iniciar una partida se debe considerar lo siguiente:
  - Se inicializa el ahorcado y los guiones con la longitud de la palabra seleccionada de un banco de categorías almacenadas; además se muestra una breve ayuda con la descripción de la palabra a adivinar.
  - El jugador que adivina empieza la partida indicando la letra que contiene la palabra.
  - Si la letra se contiene en la palabra, el jugador retado la pone en los guiones pertinentes. El sistema debe mostrarle al Jugador 1 qué letra fue seleccionada por el jugador adivinador (Jugador 2).
  - Si la letra no se contiene en la palabra, el jugador retado redibuja el ahorcado y disminuye los intentos disponibles.
  - Si el jugador adivina la palabra, se debe sumar a su puntaje global 10 puntos por ganar la partida.
  - Si el jugador no adivina la palabra, el jugador que creó la partida (1) ganará 5 puntos.
  - Si alguno de los dos abandona la partida, esta automáticamente se cancela y el jugador que abandonó será penalizado con -3 puntos.
- **Ver puntaje:** el usuario puede ver el puntaje global desglosado por las partidas que ha ganado (fecha de partida, palabra adivinada y jugador vencido), por las que su rival no ha adivinado (fecha de partida, palabra no adivinada y jugador vencido) o por penalizaciones (fecha de partida y palabra que se estaba jugando).
- **Perfil:** se debe visualizar toda la información del usuario que inició sesión.
- **Editar información:** el usuario puede editar toda su información excepto su correo electrónico.

## Requisitos no funcionales y técnicos

- **Internacionalización:** soporte para los idiomas Español e Inglés. En el caso de las palabras no se hará traducción; se debe tener un catálogo de palabras en Español e Inglés según el idioma en el que se desee jugar.
- **Comunicación:** la conexión entre cliente y servidor se debe realizar utilizando servicios desarrollados en WCF.
- **Base de datos:** debe contener las tablas y campos necesarios para almacenar la información solicitada por el juego.

## Equipos de trabajo

- Equipos de hasta 4 integrantes.
- Cada equipo desarrolla los entregables que conforman la solución de software.
- Tecnología obligatoria: WPF, WCF (C#) y SQL Server para la base de datos.
- Uso de controlador de versiones (GitHub) para la gestión de los cambios en los proyectos.

## Entregables del proyecto

- Script de base de datos y modelo relacional.
- Documento con los siguientes elementos:
  - Planteamiento del problema.
  - Decisiones de diseño (tecnologías a utilizar).
  - Diagrama de casos de uso.
  - Descripción de casos de uso.
  - Diagrama de componentes.
  - Diagrama de despliegue.
  - Modelo de persistencia (final).
  - Prototipo.
  - Estándar de codificación.
  - Resultado de análisis estático de código.
- Código fuente WPF.
- Código fuente WCF.
- Código fuente sockets (si aplica).
