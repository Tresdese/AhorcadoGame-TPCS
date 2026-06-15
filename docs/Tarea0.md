# Tarea 0 — Cimiento del proyecto (LISTO)

Este documento describe la base ya implementada para que **A, B y C trabajen en paralelo**
sin pisarse. La solución compila completa y el servidor levanta por TCP/IP.

---

## 1. Arquitectura

App cliente-servidor **WCF sobre TCP/IP (`netTcpBinding`)** en una **red local compartida**:

- El **servidor** (`AhorcadoHost`, app de consola) corre en una máquina con IP fija de la red
  y publica los 7 servicios en `net.tcp://<ip-servidor>:8000/<Servicio>`.
- Cualquier **cliente** (`ClienteAhorcado`) de esa red se conecta usando esa IP.
- La **base de datos** (SQL LocalDB) vive del lado del servidor; los clientes nunca la tocan directo.

```
[ ClienteAhorcado (WPF) ]  --net.tcp-->  [ AhorcadoHost (consola) ]  -->  [ AhorcadoWCF (servicios+DAOs+EF) ]  -->  [ BD ]
        (varios)                              (1, máquina servidor)
```

| Proyecto | Rol |
|---|---|
| `AhorcadoWCF` | Biblioteca: contratos (interfaces), DTOs, servicios y DAOs + EF |
| `AhorcadoHost` | **Nuevo.** Hospeda los servicios por `netTcpBinding` (ServiceHost) |
| `ClienteAhorcado` | Cliente WPF (todas las ventanas) |

`netTcpBinding` soporta **dúplex/callbacks** de forma nativa → el juego en tiempo real no
necesita binding HTTP especial.

---

## 2. Qué quedó implementado

### Servidor
- `AhorcadoHost/Program.cs` — abre los 7 `ServiceHost` con `NetTcpBinding(SecurityMode.None)`.
  IP/puerto configurables en `AhorcadoHost/App.config` (`ServidorHost`, `ServidorPuerto`).
- `AhorcadoHost/App.config` — appSettings + **config de EntityFramework y cadena de conexión**
  (en consola NO se hereda del Web.config).
- `AhorcadoWCF/JuegoCallbackService.svc(.cs)` — **shell** del servicio dúplex (lo implementa C).

### Cliente
- `ClienteAhorcado/Conexiones.cs` — fábrica única de proxies (`ChannelFactory`). Cada quien pide su
  servicio en una línea (ver tabla de abajo).
- `ClienteAhorcado/SesionActual.cs` — estado de sesión compartido (`IdUsuario`, `Nombre`, `Idioma`).
- `ClienteAhorcado/ManejadorErrores.cs` — helper para la excepción **EX01 "Sin conexión a BD"**.
- `ClienteAhorcado/App.config` — los 7 endpoints `net.tcp://SERVIDOR_IP:8000/...` con nombre.

---

## 3. Cómo ejecutar

1. **Servidor**: ejecutar `AhorcadoHost.exe` en la máquina servidor.
   - Opcional: fijar su IP en `ServidorHost` (vacío = nombre de la máquina = IP de la LAN).
   - Abrir el **puerto 8000/TCP en el firewall** de esa máquina.
2. **Cliente**: en `ClienteAhorcado/App.config` reemplazar `SERVIDOR_IP` por la **IP real del servidor**.
3. Ejecutar `ClienteAhorcado.exe` en cada equipo de la red.

### Uso de `Conexiones` (ejemplo)
```csharp
var ok = ManejadorErrores.Ejecutar(() =>
{
    var auth = Conexiones.Autenticacion();
    if (auth.IniciarSesion(correo, contrasena)) { /* ... */ }
});
```

| Persona | Métodos disponibles |
|---|---|
| A | `Conexiones.Autenticacion()`, `Conexiones.Usuario()` |
| B | `Conexiones.Partida()`, `Conexiones.Puntaje()` |
| C | `Conexiones.Palabra()`, `Conexiones.Movimiento()`, `Conexiones.Juego(contexto)` |

---

## 4. Reparto del trabajo

| | Persona A | Persona B | Persona C |
|---|---|---|---|
| **Tema** | Cuentas / perfil / idioma | Lobby / partida / puntaje | Juego en tiempo real |
| **CU** | 01,02,03,04,05 | 06,07,08,11,12,13 | 09,10 (+ vivo 07/11/12) |
| **DAOs** | UsuarioDAO | PartidaDAO, PuntajeDAO | MovimientoDAO, PalabraDAO |
| **Servicio clave** | AutenticacionService | PartidaService/PuntajeService | **JuegoCallbackService (dúplex)** |
| **Ventanas** | Login, Registro, Perfil, Editar | Partidas, Esperando, Historial, diálogos fin | Elegir palabra, juego, esperando palabra |

### Orden de trabajo
No es secuencial A→B→C. Tras la Tarea 0 (ya lista), **los tres avanzan en paralelo**:
los DAOs y el servicio dúplex no dependen del cliente; las ventanas se conectan con `Conexiones`.

### Puntos de coordinación (acordar firma, no esperar)
1. **A ↔ C — idioma/palabras:** decidir si `IPalabraService.ObtenerPalabrasPorCategoria`
   recibe `idioma`. Hoy es `ObtenerPalabrasPorCategoria(int idCategoria)`.
2. **B ↔ C — fin de partida:** al finalizar/abandonar, B debe disparar los callbacks
   (`PartidaFinalizada`/`RivalAbandono`) del registro de sesiones del dúplex de C.

---

## 5. Pendientes técnicos
- Reemplazar `SERVIDOR_IP` por la IP real en el cliente al desplegar.
- Decidir la firma de `ObtenerPalabrasPorCategoria` (con/sin idioma) **antes** de implementarla.
- CU-05 idioma: falta `Resources.en.resx` + catálogo de palabras bilingüe (Persona A, con C).
- Completar los DAOs con `NotImplementedException` (cada quien los suyos).
