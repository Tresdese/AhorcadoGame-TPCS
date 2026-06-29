# Proyecto: Aplicación para Prácticas Profesionales

> Documento convertido a Markdown desde `DocumentacionProyectoPracticasProfesionales.pdf` (175 páginas).
> Las figuras originales (diagramas UML, modelos de BD, prototipos de interfaz) son imágenes y se indican como marcadores `[FIGURA: ...]`.

## Portada

- **Institución:** Facultad de Estadística e Informática — Lic. en Ingeniería de Software, Universidad Veracruzana (Xalapa, Ver.)
- **Experiencia educativa:** Principios de Construcción de Software
- **Proyecto:** Aplicación para Prácticas Profesionales
- **Autores:** Angel De Jesús Aburto Ruiz; Darlington Diego Delgado Santiago
- **Fecha:** 19 de junio de 2025

## Contenido

*(Índice original del documento; los números de página se omiten en esta versión.)*

    - Introducción

    - Análisis de requisitos
    - Actores principales del Sistema

    - Requisitos
    - Gestión de Usuarios

    - Gestión de Organizaciones y Proyectos
    - Asignación y Solicitudes

    - Evaluaciones y Calificaciones
    - Reportes y Documentación

    - Diagrama de Paquetes
    - Diagramas de Casos de Uso
    - Gestión de académicos y OVs

    - Asignación de proyectos
    - Consultas y estadísticas

    - Evaluaciones y calificaciones
    - Gestión de estudiantes

    - Gestión de perfil
    - Gestión de proyectos

    - Reportes y documentación
    - Solicitudes de prácticas profesionales

    - Diagrama de clases del modelo de dominio
    - Modelo de bases de datos
    - Casos de uso

    - CU-01 Registrar Académico
    - Descripcion de caso de uso

    - Diagrama de secuencia
    - Prototipos

    - CU – 02 Consultar lista de académicos
    - Descripción de caso de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 03 Gestionar académico

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 04 Registrar OV
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 05 Consultar lista de OVS
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 06 Gestionar OV
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos
    - CU - 07 Registrar proyecto

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 08 Consultar lista de proyectos

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 09 Gestionar proyecto

    - Descripción de casos de uso
    - Diagrama de secuencia
    - Prototipos

    - CU - 10 Asignar proyecto
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 11 Reasignar proyecto a estudiante
    - Descripción de casos de uso

    - Diagrama de secuencia

    - Prototipos
    - CU - 12 Gestionar solicitudes de prácticas

    - Descripción de casos de uso
    - Diagrama de comunicación
    - Prototipos

    - CU - 13 Habilitar registro de evaluaciones
    - Descripción de casos de uso

    - Diagrama de comunicación
    - Prototipos

    - CU - 14 Consultar estadísticas
    - Descripción de casos de uso

    - Diagrama de comunicación
    - Prototipos

    - CU - 15 Registrar Estudiante
    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 16 Consultar lista de Estudiantes

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 17 Gestionar Estudiante

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 18 Registrar Calificación Final
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 19 Consultar Evaluación de Presentaciones
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 20 Registrar Evaluación Parcial

    - Descripción de casos de uso
    - Diagrama de secuencia

    - Prototipos
    - CU - 21 Consultar lista de evaluaciones
    - Descripción de casos de uso

    - Diagrama de comunicacion
    - Prototipos

    - CU - 22 Actualizar Perfil
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 23 Registrar Solicitud de Proyecto
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos
    - CU - 24 Consultar Proyecto Asignado

    - Descripción de casos de uso
    - Diagrama de comunicación

    - Prototipos
    - CU - 25 Consultar cronograma

    - Descripción de casos de uso
    - Diagrama de comunicación

    - Prototipos
    - CU - 26 Registrar Autoevaluación

    - Descripción de casos de uso
    - Diagrama de secuencia
    - Prototipos

    - CU - 27 Registrar Reporte Mensual
    - Descripción de casos de uso

    - Diagrama de secuencia
    - Prototipos

    - CU - 28 Consultar las evaluaciones
    - Descripción de casos de uso

    - Diagrama de comunicación

    - Prototipos
    - Definición del estándar

    - Introducción
    - Propósito
    - Reglas de nombrado

    - Variables
    - Constantes

    - Métodos
    - Clases

    - Interfaces
    - Pruebas

    - Estilo de código
    - Indentación

    - Llaves de Apertura y Cierre
    - Ajuste de Líneas
    - Espacios en blanco

    - Espacios
    - Estructuras de Control

    - If (If-else, if-else if-else)
    - While

    - do-while
    - for

    - Switch
    - Agrupamiento y organización del código

    - Comentarios
    - Tareas Pendientes (TODO)
    - Argumentación de decisiones

    - Estructura del proyecto
    - Capa de interfaz gráfica

    - Capa lógica
    - Capa de acceso de datos

    - Tecnologías
    - Dependencias externas

    - Pruebas

    - Prácticas de programación defensiva
    - Validación de datos

    - Manejo de errores de formato
    - Manejo de estados de error
    - Trazabilidad

    - Desborde de campos
    - Sección de pruebas

    - Pruebas por componente
    - Pruebas de Integridad Referencial

    - Pruebas de Casos Límite
    - Verificación de Estados

    - Lecciones aprendidas
    - Angel

    - Darlington
    - Conclusiones de equipo y proyecto
    - Referencias

    - Declaración de uso de IA

## Introducción

El presente documento realizado para el proyecto de las experiencias educativas “Principios de diseño de
software” y “Principios de construcción de Software” en la Licenciatura en Ingeniería de Software, tiene
como principal objetivo mostrar el diseño y análisis llevado a cabo para la propuesta de solución

problemática sugerida por dichas experiencias educativas.
La problemática identificada, se relaciona con la sobrecarga operativa del coordinador de prácticas
profesionales, quien debe supervisar registros, asignaciones y validaciones de estudiantes, académicos,

organizaciones y proyectos de forma manual, lo que genera errores, retrabajo y pérdida de tiempo. La
solución consiste en el desarrollo de una aplicación web que permita automatizar el proceso de gestión de
prácticas, abarcando desde el registro de académicos, estudiantes y organizaciones vinculadas, hasta la
asignación de proyectos, el control de evaluaciones y la consulta de estadísticas clave.
Para llevar a cabo esta propuesta, se realizó un análisis detallado de los flujos de trabajo del coordinador,
los académicos y los estudiantes, identificando las funcionalidades requeridas para cada uno de los

actores involucrados. A partir de este análisis, se definieron los casos de uso y los artefactos necesarios
para modelar el sistema, los cuales permiten comprender la interacción entre usuarios y componentes, así
como el comportamiento del sistema dentro de su entorno operativo. Este enfoque permite una
implementación estructurada, centrada en la experiencia del usuario, y alineada con las necesidades reales
de la institución educativa.

## Análisis de requisitos

Actores principales del Sistema

Actor                Descripción           Responsabilidades

Gestión completa de
Administrador principal del
Coordinador                                académicos, estudiantes,
sistema
proyectos, OVs y estadísticas
Registro de estudiantes, gestión
Académico            Supervisor de estudiantes
de evaluaciones y calificaciones
Evaluación de exposiciones y
Académico Evaluador  Evaluador de presentaciones
presentaciones de proyectos
Registro de reportes,
Estudiante           Usuario final de prácticas autoevaluaciones, consulta de
información
Requisitos

Gestión de Usuarios

**RF-001: Gestión de Académicos**

- Descripción: El coordinador puede registrar, consultar, modificar y cambiar estado de
académicos
- Actor: Coordinador

**RF-002: Gestión de Estudiantes**

- Descripción: El académico puede registrar, consultar y modificar información de estudiantes

- Actor: Académico

**RF-003: Gestión de Perfil de Estudiante**

- Descripción: El estudiante puede actualizar su información personal
- Actor: Estudiante

Gestión de Organizaciones y Proyectos

**RF-004: Gestión de Organizaciones Vinculadas (OV)**

- Descripción: El coordinador gestiona las organizaciones participantes
- Actor: Coordinador

**RF-005: Gestión de Proyectos**

- Descripción: El coordinador administra los proyectos disponibles
- Actor: Coordinador

Asignación y Solicitudes

**RF-006: Asignación de Proyectos**

- Descripción: El coordinador asigna estudiantes a proyectos disponibles
- Actor: Coordinador

**RF-007: Solicitud de Proyecto por Estudiante**

- Descripción: El estudiante puede solicitar participar en un proyecto específico
- Actor: Estudiante

**RF-008: Gestión de Solicitudes**

- Descripción: El coordinador revisa y gestiona las solicitudes de estudiantes
- Actor: Coordinador

Evaluaciones y Calificaciones

**RF-009: Registro de Evaluaciones Parciales**

- Descripción: El académico evaluador califica presentaciones usando rúbricas
- Actor: Académico Evaluador

**RF-010: Registro de Calificación Final**

- Descripción: El académico asigna calificación final al estudiante

- Actor: Académico

**RF-011: Consulta de Evaluaciones**

- Descripción: Actores pueden consultar evaluaciones según su rol

- Actor: Académico, Estudiante

Reportes y Documentación

**RF-012: Registro de Reportes Mensuales**

- Descripción: El estudiante registra sus actividades y horas mensuales

- Actor: Estudiante

**RF-013: Autoevaluación del Estudiante**

- Descripción: El estudiante completa su autoevaluación al finalizar prácticas
- Actor: Estudiante

**RF-014: Generación de Oficios**

- Descripción: El sistema genera documentos oficiales automáticamente

- Actor: Sistema

## Diagrama de Paquetes

[FIGURA: contenido gráfico en la página 12 del PDF original — 1 imagen(es)]

## Diagramas de Casos de Uso

Gestión de académicos y OVs

[FIGURA: contenido gráfico en la página 13 del PDF original — 1 imagen(es)]

Asignación de proyectos

Consultas y estadísticas

[FIGURA: contenido gráfico en la página 14 del PDF original — 2 imagen(es)]

Evaluaciones y calificaciones

[FIGURA: contenido gráfico en la página 15 del PDF original — 1 imagen(es)]

Gestión de estudiantes

Gestión de perfil

[FIGURA: contenido gráfico en la página 16 del PDF original — 2 imagen(es)]

Gestión de proyectos

[FIGURA: contenido gráfico en la página 17 del PDF original — 1 imagen(es)]

Reportes y documentación

Solicitudes de prácticas profesionales

[FIGURA: contenido gráfico en la página 18 del PDF original — 2 imagen(es)]

## Diagrama de clases del modelo de dominio

[FIGURA: contenido gráfico en la página 19 del PDF original — 1 imagen(es)]

## Modelo de bases de datos

[FIGURA: contenido gráfico en la página 20 del PDF original — 1 imagen(es)]

## Casos de uso

### CU-01 Registrar Académico

**Descripción del caso de uso**

- **ID:** CU-01

- **Nombre del CU:** Registrar académico

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El coordinador registra a los académicos correspondientes para la experiencia
educativa de prácticas profesionales

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en “Registrar Académico”.

- **Precondiciones:** PRE-01 El académico debe tener un número de personal válido

PRE-02 El sistema debe estar conectado a la base de datos

1. El sistema muestra una ventana de registro para académicos con los
- **Flujo normal:**
campos: número de personal, nombres, apellidos, usuario, contraseña,
confirmar contraseña y rol, además de un botón "Registrar académico"
(GUI_RegisterAcademic).
2. El COORDINADOR llena los campos requeridos y selecciona el rol del
académico (Académico, Académico Evaluador, o Coordinador).
3. El COORDINADOR da clic en “Registrar académico”. (Ver FA-3.1, FA-
3.2).
4. El sistema valida el número de personal usando una expresión regular.
(Ver FA-4.1, FA-4.2).
5. El sistema verifica que el campo “Contraseña” y “Confirmar contraseña”
coincidan. (Ver FA-5.1).
6. El sistema encripta la contraseña.
7. El sistema registra al académico en la base de datos, muestra un mensaje
de éxito y limpia los campos. (Ver EX - 01).
8. Termina el caso de uso.
- **Flujos alternos:** FA - 3.1 – Campos incompletos.
1. El COORDINADOR no llenó todos los campos requeridos.
2. El sistema muestra un mensaje de advertencia para los campos vacíos y
los resalta en color rojo.
3. Retorna al paso dos del flujo normal.

FA-3.2 – Nombre de usuario existente.
1. El COORDINADOR intenta registrar un nombre de usuario que ya existe
en la base de datos.

2. El sistema detecta el nombre duplicado, muestra un mensaje de usuario
repetido y resalta el campo en rojo. (Ver EX - 01).
3. Retorna al paso dos del flujo normal.

FA-4.1 – Número de personal inválido.
1. El COORDINADOR ingresa un numero de personal con formato inválido
(más de cinco dígitos).

2. El sistema muestra un mensaje de error y resalta el campo “número de
personal” en rojo.

3. Retorna al paso dos del flujo normal.

FA-4.2 – Número de personal repetido.
1. El COORDINADOR intenta registrar un número de personal existente en

la base de datos.
2. El sistema detecta el número de personal duplicado, muestra un mensaje
de ID duplicado y resalta el campo en rojo. (Ver EX - 01).
3. Retorna al paso dos del flujo normal.

FA – 5.1 - Contraseñas no coinciden.
1. El COORDINADOR ingresa contraseñas diferentes en el campo de la
contraseña y la confirmación.
2. El sistema muestra el mensaje “Las contraseñas no coinciden” y resalta
los campos en rojo.
3. Retorna al paso dos del flujo normal

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.
1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** El académico queda registrado en el sistema con la contraseña encriptada y el rol
asignado.

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 23 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 24 del PDF original — 4 imagen(es)]

[FIGURA: contenido gráfico en la página 25 del PDF original — 3 imagen(es)]

### CU – 02 Consultar lista de académicos

**Descripción del caso de uso**

- **ID:** CU-02

- **Nombre del CU:** Consultar lista de académicos

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR consulta la lista de académicos registrados en el sistema para la
experiencia educativa de prácticas profesionales.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en "Lista de Académicos".

- **Precondiciones:** PRE – 01 El sistema debe tener al menos un académico registrado.

1. El sistema muestra una tabla con los académicos registrados, incluyendo:
- **Flujo normal:**
Número de personal, Nombres, Apellidos, Nombre de usuario y Rol, junto
con un campo de búsqueda, botón "Registrar Académico", y columnas "Ver
Detalles" y "Gestionar" (GUI_CheckAcademicList). (Ver FA–1.1).
2. El sistema carga automáticamente todos los académicos registrados. (Ver EX
- 01). (Ver FA–2.1).
3. El COORDINADOR puede usar el campo de búsqueda para filtrar
académicos por ID y seleccionar uno. (Ver FA–3.1, FA-3.2).
4. El sistema muestra el total de académicos registrados.
5. Termina el caso de uso.
- **Flujos alternos:** FA-1.1 – Registrar académico.
1. El COORDINADOR da clic en “Registrar académico”.
2. El sistema abre la ventana de registro de académicos
(GUI_RegisterAcademic).
FA-2.1 – No hay académicos registrados en el sistema.

1. El sistema carga un alista vacía pero no muestra ningún mensaje.
2. La tabla se mantiene vacía y el total de académicos es 0.
3. Vuelve al paso uno del flujo normal.

FA-3.1 – Ver detalles de académico.

1. El COORDINADOR selecciona un académico en la tabla.
2. El sistema muestra el botón “Detalles” para el académico seleccionado.

FA-3.2 – Gestionar académico.
1. El COORDINADOR selecciona un académico en la tabla.

2. El sistema muestra el botón “Gestionar” para el académico seleccionado.
3. Al hacer clic, se abre la ventana de gestión de académicos
(GUI_ManageAcademic).
- **Excepciones:** EX – 01, No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.
4. Termina el caso de uso.

- **Postcondiciones:** La lista de académicos se muestra correctamente con las opciones de gestión
disponibles.

Reglas de negocio: Solo los coordinadores pueden acceder a la lista de académicos.

Incluye:       N/A

Extiende:      CU-01 – Registrar académico.

### CU-03 - Gestionar académico.

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 28 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 29 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 30 del PDF original — 1 imagen(es)]

### CU - 03 Gestionar académico

**Descripción del caso de uso**

- **ID:** CU-03

- **Nombre del CU:** Gestionar académico

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR administra la información de los académicos registrados en
el sistema, permitiendo editarlos según sea necesario.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en “Gestionar académico” en la lista de
académicos.

- **Precondiciones:** PRE-01: Debe existir al menos un académico registrado.

1. El sistema abre la ventana de gestión de académicos y carga los datos del
- **Flujo normal:**
académico (GUI_ManageAcademic).
2. El sistema muestra un formulario con los datos actuales del académico en
los campos: Nombres, Apellidos, Nombre de Usuario, Contraseña y Rol,
junto con un botón "Guardar Cambios".
3. El COORDINADOR actualiza la información necesaria y da clic en
"Guardar Cambios".
4. El sistema verifica que todos los campos estén llenos. (Ver FA-4.1).
5. El sistema actualiza los datos del académico en la base de datos. (Ver EX
- 01). (Ver FA-5.1).
6. El sistema muestra un mensaje de éxito.
7. Termina el caso de uso
- **Flujos alternos:** FA - 4.1 – Campos incompletos.
1. El COORDINADOR dejó campos vacíos.
2. El sistema muestra un mensaje de advertencia para los campos vacíos y
los resalta en color rojo.
3. Vuelve al paso tres del flujo normal

FA-5.1 – Nombre de usuario existente.
1. El COORDINADOR intenta registrar un nombre de usuario que ya existe
en la base de datos. (Ver EX - 01).
2. El sistema detecta el nombre duplicado, muestra un mensaje de error y
resalta el campo en rojo.
3. Vuelve al paso tres del flujo normal.

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.
4. Termina el caso de uso.

- **Postcondiciones:** El académico queda modificado en el sistema.

Reglas de negocio: No se puede eliminar un académico.

Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 33 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 34 del PDF original — 2 imagen(es)]

### CU - 04 Registrar OV

**Descripción del caso de uso**

- **ID:** CU-04

- **Nombre del CU:** Registrar OV

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR registra en el sistema una organización que desee participar
en el programa de prácticas profesionales.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en “Registrar organización”

- **Precondiciones:** PRE-01: El sistema debe estar conectado a la base de datos

1. El sistema muestra un formulario con los campos: Nombre de la
- **Flujo normal:**
organización y Dirección, junto con un botón "Registrar"
(GUI_RegisterLinkedOrganization).
2. El COORDINADOR llena los campos y da clic en "Registrar".
3. El sistema valida que todos los campos estén llenos. (Ver FA-3.1).
4. El sistema verifica que la organización no esté duplicada. (Ver FA-4.1).
5. El sistema guarda la información en la base de datos. (Ver EX - 01).
6. El sistema muestra un mensaje de éxito.
7. La organización queda disponible en la lista de empresas vinculadas
8. Termina el caso de uso.
- **Flujos alternos:** FA-3.1 - Campos incompletos:
1. El COORDINADOR no llena todos los campos requeridos
2. El sistema muestra un mensaje de advertencia.
3. Retorna al paso dos del flujo normal
FA-4.2 - Organización duplicada:

1. El COORDINADOR intenta registrar una organización cuyo nombre ya
existe
2. El sistema detecta el nombre duplicado y muestra un mensaje de error.
3. Retorna al paso dos del flujo normal

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.
1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** La organización vinculada y el representante quedan registrados en la base de
datos.

Reglas de negocio:  •  No se pueden registrar organizaciones duplicadas.

- La organización debe proporcionar un contacto responsable dentro de la
empresa (representante).
Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 38 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 39 del PDF original — 2 imagen(es)]

### CU - 05 Consultar lista de OVS

**Descripción del caso de uso**

- **ID:** CU-05

- **Nombre del CU:** Consultar lista de OVs

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR accede a la lista de organizaciones vinculadas en el sistema
para visualizar su información y disponibilidad de vacantes para prácticas
profesionales.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR accede a la opción "Ver lista de organizaciones"

- **Precondiciones:** Debe existir al menos una organización registrada.

1. El sistema muestra una tabla con la lista de organizaciones registradas,
- **Flujo normal:**
incluyendo: Nombre de la organización, Dirección de la organización,
columnas "Ver Detalles" y "Gestionar", junto con un campo de búsqueda
y botón "Registrar Organización".
2. El sistema carga automáticamente todas las organizaciones registradas.
(Ver EX - 01). (Ver FA-2.1, FA-2.2).
3. El COORDINADOR puede usar el campo de búsqueda para filtrar
organizaciones por ID y seleccionar una. (Ver FA-3.1, FA-3.2).
4. El sistema muestra el total de organizaciones registradas.
5. Termina el caso de uso.
- **Flujos alternos:** FA-2.1 - Registrar nueva organización:
1. El COORDINADOR da clic en "Registrar Organización"
2. El sistema abre la ventana de registro de organizaciones.

FA-2.2 - No hay organizaciones registradas:
1. El sistema carga una lista vacía pero no muestra mensaje específico
2. La tabla permanece vacía y muestra "Totales: 0"
3. Retorna al paso uno del flujo normal.

FA-3.1 - Ver detalles de organización:
1. El COORDINADOR selecciona una organización de la tabla
2. El sistema muestra el botón "Ver detalles" para la organización
seleccionada.

FA-3.2 - Gestionar organización:
1. El COORDINADOR selecciona una organización de la tabla
2. El sistema muestra el botón "Gestionar Organización" para la
organización seleccionada
3. Al hacer clic, se abre la ventana de gestión de organizaciones.
- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.
3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** N/A

Reglas de negocio: Solo los coordinadores pueden acceder a la lista de organizaciones vinculadas

Los botones de acción solo aparecen cuando se selecciona una organización
específica

Incluye:          N/A

Extiende:         CU-04 - Registrar OV

### CU-06 – Gestionar OV

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 43 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 44 del PDF original — 2 imagen(es)]

### CU - 06 Gestionar OV

**Descripción del caso de uso**

- **ID:** CU-06

- **Nombre del CU:** Gestionar OV

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR o administrador modifica, consulta o da de baja
organizaciones vinculadas que colaboran en las prácticas profesionales de los
estudiantes.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR selecciona "Gestionar organización".

- **Precondiciones:** Debe existir al menos una organización registrada.

1. El sistema abre la ventana de gestión de organizaciones vinculadas y
- **Flujo normal:**
carga los datos (GUI_ManageLinkedOrganization).
2. El COORDINADOR actualiza la información necesaria.
3. El COORDINADOR da clic en "Guardar Cambios".
4. El sistema verifica que todos los campos obligatorios estén llenos. (Ver
FA - 4.1).

5. El sistema actualiza los datos y muestra un mensaje de éxito. (Ver EX -
01). (Ver FA - 5.1).
6. Termina el caso de uso

- **Flujos alternos:** FA - 4.1 – Campos incompletos.

1. El COORDINADOR dejó campos vacíos.
2. El sistema muestra un mensaje de advertencia para los campos vacíos y
los resalta en color rojo.
3. Retorna al paso dos del flujo normal.

FA - 5.1 – Nombre de organización existente.
1. El COORDINADOR intenta registrar un nombre de organización que ya
existe en la base de datos. (Ver EX - 01).

2. El sistema detecta el nombre duplicado, muestra un mensaje de error y
resalta el campo en rojo.
3. Retorna al paso dos del flujo normal.

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos
2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** La organización queda modificada en el sistema

Reglas de negocio: Todos los campos son obligatorios para la actualización

Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 47 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 48 del PDF original — 2 imagen(es)]

### CU - 07 Registrar proyecto

**Descripción del caso de uso**

- **ID:** CU-07

- **Nombre del CU:** Registrar Proyecto

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR registra un nuevo proyecto asociado a una organización
vinculada para que los estudiantes puedan realizar prácticas profesionales.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en "Registrar Proyecto".

- **Precondiciones:** PRE-01: La organización vinculada debe estar registrada y activa en el sistema

1. El sistema muestra una ventana de registro para proyectos con los
- **Flujo normal:**
campos: nombre, descripción, académico a cargo, organización, fecha de
inicio y fecha aproximada de fin, además de un botón "Registrar
proyecto" (GUI_RegisterProject).
2. El COORDINADOR llena todos los campos requeridos y selecciona la
organización y académico correspondientes.
3. El COORDINADOR da clic en "Registrar proyecto".
4. El sistema valida que todos los campos estén completos. (Ver FA-4.1).
5. El sistema valida que el nombre no sea igual a otro en la base de datos.
(Ver FA-5.1).
6. El sistema registra el proyecto en la base de datos. (Ver EX-01).
7. El sistema muestra un mensaje de éxito, limpia los campos y actualiza las
listas de organizaciones y académicos.
8. Termina el caso de uso.
- **Flujos alternos:** FA-4.1 – Campos incompletos
1. El COORDINADOR no llenó todos los campos requeridos.
2. El sistema muestra el mensaje "Todos los campos deben estar llenos." y
resalta los campos vacíos en color rojo.
3. Retorna al paso dos del flujo normal.
FA-5.1 – Proyecto existente

1. El COORDINADOR intenta registrar un proyecto que ya existe en la base
de datos. (Ver EX-01).
2. El sistema detecta el proyecto duplicado y muestra el mensaje "El
proyecto ya existe."
3. Retorna al paso dos del flujo normal.
- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.
1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** El proyecto queda registrado en el sistema con un ID único asignado y disponible
para asignación a estudiantes.

Reglas de negocio: Solo el coordinador puede registrar proyectos.

Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 52 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 53 del PDF original — 2 imagen(es)]

### CU - 08 Consultar lista de proyectos

**Descripción del caso de uso**

- **ID:** CU-08

- **Nombre del CU:** Consultar lista de proyectos

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR consulta la información detallada de uno o varios proyectos
registrados en el sistema.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El usuario selecciona la opción "Ver lista de proyectos".

- **Precondiciones:** Debe existir al menos un proyecto registrado en el sistema.

1. El sistema muestra una tabla con la lista de proyectos registrados,
- **Flujo normal:**
incluyendo: Nombre del proyecto, Fecha de inicio, Fecha aproximada de
fin, Organización, Académico a cargo, columnas "Ver detalles" y
"Gestionar", junto con un campo de búsqueda y botón "Registrar
Proyecto" (GUI_CheckProjectList).
2. El sistema carga automáticamente todos los proyectos registrados. (Ver
EX-01). (Ver FA-2.1).
3. El COORDINADOR puede usar el campo de búsqueda para filtrar
proyectos por ID o nombre y seleccionar un proyecto. (Ver FA-3.1, FA-
3.2).
4. El sistema muestra el total de proyectos registrados
5. Termina el caso de uso.
- **Flujos alternos:** FA-2.1 - No hay proyectos registrados
1. El sistema carga una lista vacía pero no muestra mensaje específico
2. La tabla permanece vacía y muestra "Totales: 0"
3. Retorna al paso uno del flujo normal.

FA-3.1 - Ver detalles de proyecto
1. El COORDINADOR selecciona un proyecto de la tabla
2. El sistema muestra el botón "Ver detalles" para el proyecto.

FA-3.2 - Gestionar proyecto:

1. El COORDINADOR selecciona un proyecto de la tabla
2. El sistema muestra el botón "Gestionar" para el proyecto seleccionado
3. Al hacer clic, se abre la ventana de gestión de
proyectos (GUI_ManageProject).
4. Termina el caso de uso.

FA-3.3 - Registrar nuevo proyecto
1. El COORDINADOR da clic en "Registrar Proyecto" (solo visible para
coordinadores).
2. El sistema abre la ventana de registro de proyectos
(GUI_RegisterProject).
3. Termina el caso de uso
- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos
2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** La lista de proyectos se muestra correctamente con las opciones de gestión
disponibles

1. Solo los coordinadores pueden acceder a la lista de proyectos.
Reglas de negocio:
2. Los botones de acción solo aparecen cuando se selecciona un proyecto
específico
Incluye:          N/A

Extiende:         CU-07 - Registrar proyecto.

### CU-09 – Gestionar proyecto.

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 57 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 58 del PDF original — 2 imagen(es)]

### CU - 09 Gestionar proyecto

**Descripción del caso de uso**

- **ID:** CU-09

- **Nombre del CU:** Gestionar proyecto

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR desea modificar o eliminar la información de un proyecto
previamente registrado.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR selecciona un proyecto y da clic en "Gestionar proyecto"

- **Precondiciones:** Debe existir al menos un proyecto registrado en el sistema.

1. El sistema abre la ventana de gestión y muestra un formulario con los
- **Flujo normal:**
datos actuales del proyecto: Nombre, Descripción, Fecha inicio, Fecha
fin, Organización y Académico a cargo (GUI_ManageProject).
2. El COORDINADOR llena los campos necesarios.
3. El sistema verifica que todos los campos obligatorios estén llenos. (Ver
FA-3.1).
4. El COORDINADOR da clic en "Guardar Cambios"

5. El sistema actualiza los datos y muestra un mensaje de éxito. (Ver EX -
01).
6. Termina el caso de uso.

- **Flujos alternos:** FA-3.1 - Campos incompletos al editar:
1. El sistema muestra un mensaje de campos vacíos.
2. El sistema resalta campos en rojo
3. Retorna al paso dos del flujo normal.
- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.
4. Termina el caso de uso.

- **Postcondiciones:** El proyecto queda modificado en el sistema

1. Solo los coordinadores pueden gestionar proyectos
Reglas de negocio:
2. Todos los campos son obligatorios para la actualización
Incluye:          N/A
Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 61 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 62 del PDF original — 2 imagen(es)]

### CU - 10 Asignar proyecto

**Descripción del caso de uso**

- **ID:** CU-10

- **Nombre del CU:** Asignar proyecto

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR asigna un proyecto de prácticas profesionales a un
estudiante registrado en el sistema.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR selecciona un estudiante de la lista y da clic en "Asignar
Proyecto"

- **Precondiciones:** •  Debe existir al menos un proyecto registrado en el sistema.
- El proyecto debe estar registrado y en estado "Disponible".
- Debe existir un académico disponible para supervisión.
- El estudiante debe estar registrado en el sistema.
1. El sistema abre la ventana de asignación y muestra el nombre del
- **Flujo normal:**
estudiante seleccionado (GUI_AssignProject).
2. El sistema carga automáticamente todos los proyectos disponibles. (Ver
EX - 01). (Ver FA-2.1).
3. El COORDINADOR selecciona un proyecto de la lista desplegable.

4. El COORDINADOR hace clic en "Asignar Proyecto".
5. El sistema valida que se haya seleccionado un proyecto. (Ver FA-5.1).
6. El sistema registra la asignación en la base de datos. (Ver EX - 01).
7. El sistema genera un PDF de asignación con los datos del estudiante,
proyecto y organización.
8. El sistema sube el PDF a Google Drive y envía un correo electrónico al
estudiante con el documento adjunto. (Ver EX - 02).
9. El sistema muestra el mensaje "Proyecto asignado, PDF subido a Drive y
correo enviado correctamente." y cierra la ventana. (Ver EX - 03).
10. Termina el caso de uso.
- **Flujos alternos:** FA-2.1 - No hay proyectos disponibles
1. El sistema carga una lista vacía.
2. El COORDINADOR no puede seleccionar ningún proyecto
3. Retorna al paso uno del flujo normal.

FA-5.1 - No se ha seleccionado proyecto
1. El COORDINADOR no selecciona ningún proyecto de la lista.
2. El sistema muestra el mensaje "Debe seleccionar un proyecto".
3. Retorna al paso dos del flujo normal.

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.
3. El mensaje desaparece.

4. Termina el caso de uso.

EX - 02 - Error al enviar correo:
1. El sistema no puede enviar el correo electrónico al estudiante

2. El sistema muestra un mensaje de error al enviar el correo.

3. El COORDINADOR da clic en “aceptar”.

4. Termina el caso de uso.

EX - 03 - Error al subir PDF a Drive:

1. El sistema no puede subir el PDF a Google Drive
2. El sistema muestra un mensaje de error al subir el PDF a Drive.

3. El COORDINADOR da clic en “aceptar”.

4. Termina el caso de uso

- **Postcondiciones:** N/A

Reglas de negocio: Solo los COORDINADORES pueden acceder a la lista de proyectos.

Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 66 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 67 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 68 del PDF original — 2 imagen(es)]

### CU - 11 Reasignar proyecto a estudiante

**Descripción del caso de uso**

- **ID:** CU-11

- **Nombre del CU:** Reasignar proyecto a estudiante

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR reasigna a un estudiante previamente asignado a un
proyecto, ya sea porque el proyecto fue cancelado, el estudiante no cumplió con
los requisitos o la organización solicitó cambios.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR selecciona un estudiante y da clic en "Reasignar Proyecto"

- **Precondiciones:** PRE-01 El estudiante debe estar previamente asignado a un proyecto.
PRE-02 Deben existir al menos dos proyectos disponibles en el sistema.

PRE-03 El proyecto destino debe estar en estado “Disponible”.
PRE-04 El estudiante debe estar activo en el sistema.
PRE-05 Debe haber un académico disponible para supervisión.
1. El sistema abre la ventana de reasignación pasando los datos del
- **Flujo normal:**
estudiante y proyecto actual (GUI_ReassignProject).
2. El sistema busca el proyecto actual del estudiante. (Ver FA-2.1).
3. El sistema muestra el nombre del estudiante y carga todos los proyectos
disponibles. (Ver FA-3.1).
4. El COORDINADOR selecciona un nuevo proyecto de la lista
desplegable. (Ver FA-4.1).
5. El COORDINADOR hace clic en "Asignar proyecto".
6. El sistema actualiza la asignación del estudiante al nuevo proyecto.
7. El sistema actualiza el estudiante en la base de datos.
8. El sistema muestra un mensaje de proyecto reasignado y cierra la ventana.
9. Termina el caso de uso.
- **Flujos alternos:** FA-2.1 - No hay estudiante seleccionado
1. El COORDINADOR no selecciona ningún estudiante antes de hacer clic
en "Reasignar Proyecto"
2. El sistema muestra el mensaje "Debe seleccionar un estudiante para
reasignar proyecto"
3. Retorna al paso tres del flujo normal.

FA-3.1 – No hay más de un proyecto
1. El sistema muestra una lista vacía de proyectos a seleccionar.
2. El COORDINADOR cierra la ventana de reasignación de proyectos.
3. El sistema vuelve a la lista de proyectos.
4. Retorna al paso tres del flujo normal.

FA-4.1 - No se selecciona proyecto
1. El COORDINADOR no selecciona ningún proyecto.
2. El sistema muestra el mensaje "Seleccione un proyecto."
3. Retorna al paso tres del flujo normal.

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos
2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** •  El estudiante queda asignado al nuevo proyecto.

Reglas de negocio:  •  Solo los coordinadores pueden reasignar estudiantes.
- No se puede reasignar a un estudiante si no existen proyectos disponibles.
Incluye:          N/A

Extiende:         N/A

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 72 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 73 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 74 del PDF original — 2 imagen(es)]

### CU - 12 Gestionar solicitudes de prácticas

**Descripción del caso de uso**

- **ID:** CU-12

- **Nombre del CU:** Gestionar solicitudes de prácticas

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR gestiona las solicitudes de prácticas profesionales de los
estudiantes, considerando las prioridades de proyecto indicadas por cada uno, para
decidir su asignación o enviarlas a la Comisión de Evaluación (COE).

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en "Lista de Solicitudes de Prácticas" desde el menú
principal

- **Precondiciones:** •  PRE-01: El estudiante debe estar registrado en el sistema.
- PRE-02: Debe haber al menos una solicitud enviada.
- PRE-03: El estudiante debe tener un estatus activo.
1. El sistema muestra una tabla con las solicitudes de proyectos registradas,
- **Flujo normal:**
incluyendo: Matrícula, Nombre Proyecto, Descripción, Organización,
Representante, Estado y columna
"Aprobar/Rechazar" (GUI_CheckProjectRequestList).

2. El sistema carga automáticamente todas las solicitudes. (Ver EX - 01).
(Ver FA-2.1).
3. El COORDINADOR puede filtrar las solicitudes por estado (pendiente,
aprobada, rechazada) y buscar por matrícula, nombre de proyecto.
4. El COORDINADOR selecciona una solicitud pendiente y da clic en
"Aprobar/Rechazar".
5. El sistema abre la ventana de gestión de solicitudes mostrando los detalles
de la solicitud (GUI_ManageRequest).
6. El COORDINADOR selecciona "Aprobar" o "Rechazar". (Ver FA-6.1,
FA-6.2).
7. El sistema actualiza el estado de la solicitud en la base de datos y muestra
un mensaje de confirmación. (Ver EX - 01).
8. Termina el caso de uso
- **Flujos alternos:** FA-2.1 - No hay solicitudes registradas:
1. El sistema carga una lista vacía pero no muestra mensaje específico
2. La tabla permanece vacía.
3. Retorna al paso uno del flujo normal.
- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.
3. El mensaje desaparece.

4. Termina el caso de uso.

- **Postcondiciones:** •  La solicitud del estudiante se encuentra con estado actualizado según la
acción realizada.
Reglas de negocio:  •  No se pueden aprobar solicitudes si el proyecto ya fue asignado a otro
estudiante.
- Las solicitudes enviadas a COE no pueden ser modificadas por el
coordinador hasta que la comisión emita una resolución.
Incluye:          N/A

Extiende:         N/A

#### Diagrama de comunicación

#### Prototipos

[FIGURA: contenido gráfico en la página 77 del PDF original — 2 imagen(es)]

### CU - 13 Habilitar registro de evaluaciones

**Descripción del caso de uso**

- **ID:** CU-13

- **Nombre del CU:** Habilitar registro de evaluaciones

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR habilita el registro de evaluaciones para que los académicos
puedan calificar los proyectos de prácticas profesionales asignados a sus
estudiantes.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR da clic en “Habilitar registro de evaluaciones”.

- **Precondiciones:** •  Deben existir estudiantes con proyectos asignados.

- Deben existir académicos registrados.
1. El sistema conecta con la base de datos y obtiene el estado actual de los
- **Flujo normal:**
registros. (Ver EX - 01).
2. El sistema cambia el estado global de habilitación de evaluaciones.
3. El sistema actualiza dinámicamente la visibilidad de los botones
“Consultar calificación de evaluación” y “Evaluar presentación” para
todos los usuarios con rol ACADEMICO EVALUADOR.

4. El sistema muestra un mensaje de confirmación.
5. Termina el caso de uso.

- **Flujos alternos:**

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

1. El sistema muestra una ventana de error en conexión con la base de datos

2. El COORDINADOR da clic en “aceptar”.

3. El mensaje desaparece.
4. Termina el caso de uso.

- **Postcondiciones:** •  El sistema permite el registro de evaluaciones por parte de los académicos
habilitados.

Reglas de negocio:  •  Solo el COORDINADOR puede habilitar el registro de evaluaciones.

- Una vez habilitado, el registro estará disponible hasta la fecha límite
establecida por el sistema.
Incluye:          N/A

Extiende:         N/A

#### Diagrama de comunicación

#### Prototipos

### CU - 14 Consultar estadísticas

**Descripción del caso de uso**

- **ID:** CU-14

- **Nombre del CU:** Consultar estadística

- **Responsable:** Darlington Diego Delgado Santiago

- **Fecha de Creación:** 29/03/25

- **Descripción:** El COORDINADOR consulta estadísticas relacionadas con las prácticas
profesionales, como número de estudiantes asignados, porcentaje de proyectos
evaluados, cantidad de organizaciones activas, entre otros indicadores clave del
proceso.

- **Actor(es):** AC-01- Coordinador

- **Disparador:** El COORDINADOR accede a cualquiera de las listas principales del sistema

- **Precondiciones:** •  PRE-01: Debe haber datos registrados en el sistema (proyectos,
estudiantes, organizaciones, académicos)
- PRE-02: El sistema debe estar conectado a la base de datos
1. El COORDINADOR accede a una de las opciones del menú principal:
- **Flujo normal:**
"Ver lista de académicos", "Ver lista de estudiantes", "Ver lista de
organizaciones" o "Ver lista de proyectos"
2. El sistema carga automáticamente los datos correspondientes y muestra la
tabla con la información.
3. El sistema calcula y muestra estadísticas básicas de conteo en etiquetas al
pie de cada lista.
4. El COORDINADOR puede visualizar los totales mostrados en las
etiquetas correspondientes
5. Termina el caso de uso
- **Flujos alternos:** FA-2.1 - Lista vacía:
1. El sistema carga una lista sin elementos

2. El sistema muestra "Totales: 0" en la etiqueta correspondiente
3. Retorna al paso uno del flujo normal.

- **Excepciones:** EX – 01 No se pudo establecer conexión con la base de datos.

5. El sistema muestra una ventana de error en conexión con la base de datos

6. El COORDINADOR da clic en “aceptar”.

7. El mensaje desaparece.
8. Termina el caso de uso.

- **Postcondiciones:** •  Las estadísticas básicas de conteo se muestran correctamente en cada lista

Reglas de negocio:  •  Las estadísticas se calculan automáticamente al cargar cada lista

Incluye:          N/A

Extiende:         N/A

#### Diagrama de comunicación

[FIGURA: contenido gráfico en la página 82 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 83 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 84 del PDF original — 1 imagen(es)]

### CU - 15 Registrar Estudiante

**Descripción del caso de uso**

- **ID:** CU-15

Nombre:     Registrar Estudiante

- **Responsable:** Académico
Fecha de    28/marzo/2025
actualización:

- **Descripción:** : El ACADEMICO registra los datos del ESTUDIANTE para crear un perfil
dentro del sistema
- **Actor(es):** AC-02- Académico

- **Disparador:** El ACADEMICO da click en Registrar estudiante.

- **Precondiciones:** PRE-01 El ESTUDIANTE no está registrado en la base de datos
PRE-02 La base de datos es accesible

Flujo Normal: 1. EL SISTEMA muestra GUI_RegistrarEstudiante, en la cual va a
solicitar los campos de datos de un ESTUDIANTE (matricula,
nombres, apellidos, correo, avance crediticio, teléfono, NRC, usuario,
contraseña).
2. El ACADEMICO ingresa los datos del ESTUDIANTE y da clic en
“Registrar”. (Ver FA 2.1)
3. EL SISTEMA valida que no se encuentren campos vacíos (Ver FA

3.1)
4. EL SISTEMA valida que no haya datos inválidos (una matrícula que
exceda caracteres o no cumpla con la estructura). (Ver FA 4.1)
5. EL SISTEMA valida que no exista un ESTUDIANTE con la misma
matrícula (FA 5.1) (Ver EX1)

6. EL SISTEMA crea a el ESTUDIANTE en la base de datos y muestra
GUI_RegistroExitoso con el mensaje “El registro se ha realizado con
éxito”. (Ver EX1)
7. Termina el caso de uso

Flujos Alternos: FA 2.1 Cancelar registro de estudiante
1. EL SISTEMA muestra GUI_ConfirmaciónCancelación con el
mensaje “¿Estás seguro de que deseas cancelar?”.

2. El ACADEMICO da clic en “Si”.
3. Termina el caso de uso
FA 3.1 Campos Vacíos

1. EL SISTEMA detecta campos vacíos
2. EL SISTEMA muestra la GUI_CamposVacios con el mensaje
“No puede haber campos sin datos”
3. El ACADEMICO da clic en “Regresar”.

4. Regresa al paso 2 del flujo normal.
FA 4.1 Datos inválidos
1. EL SISTEMA limpia los campos erróneos y muestra la
GUI_DatosInvalidos con el mensaje “Los datos ingresados son
inválidos”.

2. El ACADEMICO da clic en el botón “Regresar”.
3. Regresa al paso 2 del flujo normal.
FA 5.1 Registro Existente

1. El sistema detecta que la matricula ingresada ya cuenta con un
registro existente
2. EL SISTEMA limpia el campo que contiene la matricula
3. EL SISTEMA muestra la GUI_EstudianteExistente con el mensaje
“La matrícula ya está asignada para otro Estudiante”.

4. El ACADEMICO da click en “Regresar”.
5. Regresa al paso 2 del flujo normal.
- **Excepciones:** EX1. No hay conexión con la base de datos

1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”
2. El ACADEMICO da click en “Cerrar”

3. Termina el caso de uso
- **Postcondiciones:** POST-01 Un ESTUDIANTE queda registrado en el sistema.

Reglas de   RN-01 El ESTUDIANTE debe contar con una inscripción activa para la
negocio:    Experiencia Educativa de Prácticas Profesionales
RN-02: La matrícula debe seguir el formato.
RN-03: El avance crediticio mínimo para prácticas es del 70%.

Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 87 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 88 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 89 del PDF original — 2 imagen(es)]

### CU - 16 Consultar lista de Estudiantes

**Descripción del caso de uso**

- **ID:** CU-16
Nombre:     Consultar lista de Estudiantes

- **Responsable:** Académico

Fecha de    28/marzo/2025
actualización:

- **Descripción:** : El ACADEMICO visualiza una lista de ESTUDIANTES con información
básica de estos

- **Actor(es):** AC-02-Academico
- **Disparador:** El ACADEMICO da click en Consultar Estudiantes

- **Precondiciones:** PRE-01 La base de datos está disponible.
PRE-02 Hay registros de ESTUDIANTES en la base de datos

Flujo Normal: 1. EL SISTEMA obtiene una lista de ESTUDIANTES registrados con
un estado Activo a partir de la base de datos. (Ver EX1) (Ver FA
1.1)
2. EL SISTEMA muestra GUI_Estudiantes que contiene una lista de
los ESTUDIANTES y el botón “Registrar Estudiante” (Ver FA
2.1)

3. [Extensión opcional] Si el ACADEMICO da click en el botón
“Registrar Estudiante”, se ejecuta el caso de uso “Registrar
Estudiante” (CU-15)
4. El ACADEMICO selecciona un ESTUDIANTE
5. El ACADEMICO da click en la opción “Ver detalles”

6. EL SISTEMA obtiene toda la información del ESTUDIANTE
7. EL SISTEMA muestra la GUI_DetallesEstudiante que contiene la
información completa del ESTUDIANTE junto con el boton
“Gestionar Estudiante” (Ver EX1)
8. [Extensión opcional] Si el ACADEMICO da click en el botón
“Modificar”, se ejecuta el caso de uso “Gestionar Estudiante” (CU-
17)

9. Termina el caso de uso
Flujos Alternos: FA 1.1 No hay estudiantes registrados

1. EL SISTEMA muestra la GUI_NoEstudiantesRegistrados con el
mensaje “No se encontraron estudiantes registrados”
2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso

FA 2.1 Buscar estudiante
1. EL SISTEMA permite buscar a un ESTUDIANTE través de la
matricula
2. El ACADEMICO ingresa la matricula del ESTUDIANTE que
desea ver

3. El ACADEMICO da click en “Buscar”
4. El sistema muestra el ESTUDIANTE o ESTUDIANTES que
tengan similitudes con el dato ingresado
5. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”

2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 Se obtuvo información relevante del ESTUDIANTE a consultar.

Reglas de   RN-03: Solo se muestran estudiantes con estado ACTIVO.

negocio:    RN-04: Los estudiantes se ordenan alfabéticamente por apellido.
Incluye:    Ninguno

Extiende:   CU-15 Registrar Estudiante

### CU-17 Gestionar Estudiante

#### Diagrama de secuencia

#### Prototipos

[FIGURA: contenido gráfico en la página 93 del PDF original — 1 imagen(es)]

[FIGURA: contenido gráfico en la página 94 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 95 del PDF original — 1 imagen(es)]

### CU - 17 Gestionar Estudiante

**Descripción del caso de uso**

- **ID:** CU-17

Nombre:     Gestionar Estudiante
- **Responsable:** Académico

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ACADEMICO modifica los datos del ESTUDIANTE registrado dentro

del sistema
- **Actor(es):** AC-02-Academico

- **Disparador:** EL ACADEMICO da click en Gestionar Estudiante
- **Precondiciones:** PRE-01 El ESTUDIANTE existe en el sistema.

PRE-02 La base de datos está accesible.
Flujo Normal: 1. EL SISTEMA obtiene los datos del ESTUDIANTE a través de la
base de datos (Ver EX1)

2. EL SISTEMA muestra la GUI_GestionEstudiante en la cual
podremos modificar todos los datos (Con excepción del correo,
usuario, teléfono y contraseña) del ESTUDIANTE seleccionado.
3. El ACADEMICO realiza la modificación de los datos que requiere
cambiar
4. El ACADEMICO da click en “Modificar” (Ver FA 4.1)

5. EL SISTEMA valida que no haya campos vacíos (Ver 5.1)
6. EL SISTEMA valida los datos (que la matricula siga siendo válida;
que cumpla con la estructura de una matrícula) sean válidos.
7. EL SISTEMA en caso de que se haya modificado la matricula
verifica que no esté asignada a otro ESTUDIANTE. (Ver EX1)

(Ver 7.1)
8. EL SISTEMA guarda la modificación en la base de datos (Ver
EX1)
9. EL SISTEMA muestra la GUI_ModificacionExitosa con el
mensaje “La modificación se ha realizado con éxito”

10. Termina el caso de uso

Flujos Alternos: FA 4.1 Cancelar modificación del Estudiante
1. EL SISTEMA muestra GUI_ConfirmaciónCancelación con el
mensaje “¿Estás seguro de que deseas cancelar?”

2. El ACADEMICO da click en “Si”
3. Termina el caso de uso
FA 5.1 Campos vacíos

1. EL SISTEMA detecta campos vacíos
2. EL SISTEMA muestra la GUI_CamposVacios con el mensaje “No
puede haber campos sin datos”
3. El ACADEMICO da click en “Regresar”
4. Regresa al paso 2 del flujo normal

FA 6.1 Campos Inválidos
1. EL SISTEMA limpia los campos erróneos
2. EL SISTEMA muestra la GUI_DatosInvalidos con el mensaje “Los
datos ingresados son inválidos”

3. El ACADEMICO da click en “Regresar”
4. Regresa al paso 2 del flujo normal
FA 7.1 Registro Existente

1. EL SISTEMA detecta que la matricula ingresada ya cuenta con un
registro existente
2. EL SISTEMA limpia el campo que contiene la matricula
3. EL SISTEMA muestra la GUI_EstudianteExistente con el mensaje
“La matrícula ya está asignada para otro Estudiante”

4. El ACADEMICO da click en “Regresar”
5. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos
con el mensaje “No hay conexión a la base de datos”
2. El ACADEMICO da click en “Cerrar”

3. Termina el caso de uso
- **Postcondiciones:** POST-01 Los datos del ESTUDIANTE se actualizan en la base de datos.

Reglas de   RN-05: La matrícula no puede modificarse después del registro.
negocio:    RN-06: El NRC debe pertenecer a una Experiencia Educativa vigente

Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 98 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 99 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 100 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 101 del PDF original — 2 imagen(es)]

### CU - 18 Registrar Calificación Final

**Descripción del caso de uso**

- **ID:** CU-18

Nombre:     Registrar Calificación Final
- **Responsable:** Académico

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ACADEMICO registra la calificación final a un ESTUDIANTE

- **Actor(es):** AC-02-Academico

- **Disparador:** El ACADEMICO da click en Registrar calificación final

- **Precondiciones:** PRE-01 El ESTUDIANTE está asignado a un proyecto.
PRE-02 El ESTUDIANTE ha completado las horas requeridas de prácticas.

Flujo Normal: 1. EL SISTEMA Obtiene una lista de ESTUDIANTES que tengan un
estado activo en el sistema (Ver EX1)
2. EL SISTEMA muestra GUI_EstudiantesCalificaciones que
contiene una lista de los ESTUDIANTES Activos para poder
asignarles calificación (Ver FA 2.1)
3. El ACADEMICO selecciona un ESTUDIANTE para asignarle su
calificación (Ver FA 3.1)

4. EL SISTEMA muestra GUI_RegistrarCalificacion con un campo
para ingresar la calificación del ESTUDIANTE
5. El ACADEMICO ingresa la calificación del ESTUDIANTE (En un
rango de 1 a 10)
6. El ACADEMICO da click en “Registrar” (Ver 6.1)

7. EL SISTEMA valida que el campo no este vacío (Ver 7.1)
8. EL SISTEMA verifica que el dato ingresado sea válido(Ver 8.1)
9. EL SISTEMA registra la calificación asignada al ESTUDIANTE
seleccionado en la base de datos (Ver EX1)

10. EL SISTEMA muestra la GUI_CalificacionRegistrada con el
mensaje “Se registro la calificación con éxito”
11. Termina el caso de uso

Flujos Alternos: FA 2.1 No hay Estudiantes Registrados
1. EL SISTEMA muestra la GUI_NoEstudiantesRegistrados con el
mensaje “No se encontraron estudiantes registrados”

2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso
FA 3.1 Buscar Estudiante

1. EL SISTEMA permite buscar a través de la matricula
2. El ACADEMICO ingresa la matricula del ESTUDIANTE que
desea
3. El ACADEMICO da click en “Buscar”
4. EL SISTEMA muestra el ESTUDIANTE o ESTUDIANTES que

tengan similitudes con el dato ingresado
5. Regresa al paso 2 del flujo normal
FA 6.1 Cancelar Registro de Calificación
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el

mensaje “¿Estás seguro de que deseas cancelar?”
2. El ACADEMICO da click en “Si”
3. Regresa al paso 2 del flujo normal
FA 7.1 Campo Vacío

1. EL SISTEMA detecta que el campo este vacío
2. EL SISTEMA muestra la GUI_CamposVacios con el mensaje “No
puede haber campos sin datos”
3. El ACADEMICO da click en “Regresar”

4. Regresa al paso 4 del flujo normal
FA 8.1 Dato Invalido
1. EL SISTEMA detecta el campos invalido

2. EL SISTEMA limpia el campo erróneo
3. EL SISTEMA muestra la GUI_DatosInvalidos con el mensaje “Los
datos ingresados son inválidos”
4. El ACADEMICO da click en el botón “Regresar”

5. Regresa al paso 4 del flujo normal
- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el

mensaje “No hay conexión a la base de datos”
2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso

- **Postcondiciones:** POST-01 La calificación se asigna a un ESTUDIANTE en la base de datos

Reglas de   RN-07: La calificación debe ser un número entero entre 5 y 10.
negocio:    RN-08: El académico debe ser el responsable asignado del proyecto.

Incluye:    Ninguno
Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 105 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 106 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 107 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 108 del PDF original — 1 imagen(es)]

### CU - 19 Consultar Evaluación de Presentaciones

**Descripción del caso de uso**

- **ID:** CU-19

Nombre:     Consultar Evaluación de Presentaciones
- **Responsable:** Académico

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ACADEMICO consulta el promedio de calificación de las

presentaciones de los proyectos.
- **Actor(es):** AC-02-Academico

- **Disparador:** El ACADEMICO da click en Consultar Evaluación Presentaciones
- **Precondiciones:** PRE-01 Al menos un PROYECTO ha realizado PRESENTACIONES.

Flujo Normal: 1. EL SISTEMA obtiene una lista de
EVALUACION_PRESENTACION (Ver EX1)

2. EL SISTEMA muestra GUI_EvaluacionesPromedio en la cual
muestra una lista de las EVALUACION_PRESENTACION junto
con sus respectivos promedios (Ver FA 2.1)
3. El ACADEMICO selecciona una
EVALUACION_PRESENTACION
4. El ACADEMICO da click en “Ver detalles” para ver más detalles
de su evaluación (Ver 4.1)

5. EL SISTEMA muestra GUI_EvaluacionDetalle en la cual se
muestra las rubricas de EVALUACION_PRESENTACION
seleccionada
6. Termina el caso de uso

Flujos Alternos: FA 2.1 No hay evaluaciones registradas
1. EL SISTEMA muestra GUI_NoEvaluacionesRegistradas con el
mensaje “No se encontraron evaluaciones para proyectos
registradas”

2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso
FA 4.1 Buscar Evaluacion_Presentacion

1. EL SISTEMA permite buscar a través de la matricula del
ESTUDIANTE
2. El ACADEMICO ingresa la matricula del ESTUDIANTE que
desea ver la EVALUACION_PRESENTACION
3. El ACADEMICO da click en “Buscar”

4. EL SISTEMA muestra la EVALUACION_PRESENTACION o las
EVALUACION_PRESENTACION que tengan similitudes con el
dato ingresado
5. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos

2. El ACADEMICO da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 El ACADEMICO visualiza el promedio de calificaciones de las

PRESENTACIONES.
Reglas de   RN-09: El promedio se calcula como (suma de evaluaciones) / (número de

negocio:    evaluadores).
Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 111 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 112 del PDF original — 2 imagen(es)]

### CU - 20 Registrar Evaluación Parcial

**Descripción del caso de uso**

- **ID:** CU-20

Nombre:     Registrar Evaluación Parcial
- **Responsable:** Académico Evaluador

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ACADEMICO EVALUADOR realiza la evaluación de la

PRESENTACION ingresando los datos correspondientes en la plantilla de
rubrica de evaluación exposiciones
- **Actor(es):** AC-03-Academico Evaluador

- **Disparador:** El ACADEMICO EVALUADOR da click en Registrar Evaluación Parcial
- **Precondiciones:** PRE-01 La PRESENTACION del proyecto está programada.

PRE-02 La rúbrica de evaluación está configurada.
Flujo Normal: 1. EL SISTEMA muestra GUI_EvaluarExposicion que contiene una
plantilla con una rubrica para calificar las PRESENTACIONES, en
donde puede seleccionar criterios para cada uno de los campos y el
nombre del ESTUDIANTE a evaluar

2. El ACADEMICO EVALUADOR llena todos los criterios
correspondientes a lo que él considera
3. El ACADEMICO EVALUADOR da click en “Evaluar” (Ver FA
3.1)

4. EL SISTEMA valida que no haya criterios sin marcar (Ver FA 4.1)
5. EL SISTEMA calcula el promedio de la calificación
6. EL SISTEMA crea la EVALUACION_PRESENTACION para la
PRESENTACION calificada (Ver EX1)

7. EL SISTEMA muestra GUI_EvaluacionRegistrada con el mensaje
“La evaluación a sido registrada con éxito”
8. Termina el caso de uso

Flujos Alternos: FA 3.1 Cancelar Evaluación
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el
mensaje “¿Estas seguro de que deseas cancelar?”

2. El ACADEMICO EVALUADOR da click en “Si”
3. Termina el caso de uso
FA 4.1 Criterios sin marcar

1. EL SISTEMA detecta criterios sin marcar
2. EL SISTEMA muestra GUI_CriteriosSinMarcar con el mensaje
“No puede haber criterios sin marcar”
3. El ACADEMICO EVALUADOR da click en “Regresar”
4. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”

2. El ACADEMICO EVALUADOR da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 La evaluación se registra en la base de datos.

POST-02 Se calcula y almacena el promedio de la calificación.
Reglas de   RN-10: Cada criterio de la rúbrica debe tener un valor entre 1 y 5.

negocio:    RN-11: Un evaluador no puede calificar la misma presentación del mismo
estudiante más de una vez.
Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 115 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 116 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 117 del PDF original — 2 imagen(es)]

### CU - 21 Consultar lista de evaluaciones

**Descripción del caso de uso**

- **ID:** CU-21

Nombre:     Consultar lista de evaluaciones
- **Responsable:** Académico Evaluador

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ACADEMICO EVALUADOR revisa las PRESENTACIONES de los

PROYECTOS que se van a realizar pudiendo obtener un poco más de
detalles de los PROYECTOS
- **Actor(es):** AC-03-Academico Evaluador

- **Disparador:** El ACADEMICO EVALUADOR da click en Consultar lista de
evaluaciones
- **Precondiciones:** PRE-01 Hay PRESENTACIONES programadas para las fechas proximas.

Flujo Normal: 1. EL SISTEMA obtiene una lista de
PRESENTACION_PROYECTO con una fecha próxima a la actual
(incluye la hora). (Ver EX1)

2. EL SISTEMA muestra GUI_PresentacionProyectos que muestra
una lista de las PRESENTACION_PROYECTO (Ver FA 2.1)
3. El ACADEMICO EVALUADOR selecciona una
PRESENTACION_PROYECTO

4. [Extensión opcional] Si el ACADEMICO da click “Registrar
Evaluación”, se ejecuta el caso de uso “Registrar Evaluación
parcial” (CU-19)
5. El ACADEMICO EVALUADOR da click en “Ver detalles”
6. EL SISTEMA muestra GUI_Presentacion la cual contiene el
nombre del PROYECTO, los integrantes y el nombre de la
ORGANIZACION VINCULADA

7. Termina el caso de uso
Flujos Alternos: FA 2.1 No hay presentaciones asignadas a fechas próximas

1. EL SISTEMA muestra GUI_NoHayPresentaciones con el mensaje
“No hay presentaciones asignadas a fechas próximas”
2. El ACADEMICO EVALUADOR da click en “Cerrar”
3. Termina el caso de uso

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”

2. El ACADEMICO EVALUADOR da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 El ACADEMICO EVALUADOR visualiza la lista de

PROYECTOS con PRESENTACIONES pendientes.
Reglas de   RN-12: Las evaluaciones futuras se filtran por fecha (≥ hoy).

negocio:
Incluye:    Ninguno

Extiende:   CU-19 Registrar Evaluación Parcial

#### Diagrama de comunicacion

#### Prototipos

[FIGURA: contenido gráfico en la página 120 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 121 del PDF original — 1 imagen(es)]

### CU - 22 Actualizar Perfil

**Descripción del caso de uso**

- **ID:** CU-22

Nombre:     Actualizar Perfil
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE puede realizar modificaciones en su perfil para que sea

más acorde a él
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Actualizar Perfil
- **Precondiciones:** PRE-01 El perfil del ESTUDIANTE existe en el sistema.

Flujo Normal: 1. EL SISTEMA obtiene los datos del ESTUDIANTE (Ver EX1)

2. EL SISTEMA muestra GUI_PerfilEstudiante en el cual muestra los
datos del ESTUDIANTE y dando la opción de modificar el correo
y número de teléfono
3. El ESTUDIANTE modifica correo y/o número de teléfono
4. El ESTUDIANTE da click en “Actualizar” (Ver FA 4.1)

5. EL SISTEMA valida que no haya campos vacíos (Ver FA 5.1)
6. EL SISTEMA valida que el correo tenga un formato valido (Ver
FA 6.1)
7. EL SISTEMA valida que el número de teléfono tenga un formato
válido (Ver FA 7.1)

8. EL SISTEMA realiza la actualización de la información del
ESTUDIANTE (Ver EX1)
9. EL SISTEMA muestra GUI_ActualizacionExitosa con el mensaje
“La modificación se realizo con éxito”.
10. Termina el caso de uso

Flujos Alternos: FA 4.1 Cancelar Actualización
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el
mensaje “¿Estas seguro de que deseas cancelar?”

2. El ESTUDIANTE da click en “Si”
3. Termina el caso de uso
FA 5.1 Campos vacíos

1. EL SISTEMA detecta que hay campos vacíos
2. EL SISTEMA muestra GUI_CamposVacios con el mensaje “No
puede haber campos vacíos”
3. El ESTUDIANTE da click en “Regresar”
4. Regresa al paso 2 del flujo normal

FA 6.1 Correo Invalido
1. EL SISTEMA detecta un formato incorrecto en el correo

2. EL SISTEMA muestra GUI_CorreoInvalido con el mensaje
“Formato incorrecto del correo”
3. El ESTUDIANTE da click en “Regresar”
4. Regresa al paso 2 del flujo normal

FA 7.1 Teléfono Invalido
1. EL SISTEMA detecta un formato incorrecto en el teléfono
2. EL SISTEMA muestra GUI_TelefonoInvalido con el mensaje
“Formato incorrecto del número de teléfono”

3. El ESTUDIANTE da click en “Regresar”
4. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”
2. El ESTUDIANTE da click en “Cerrar”
3. Termina el caso de uso

- **Postcondiciones:** POST-01 Los datos del perfil del ESTUDIANTE se actualizan.

Reglas de   RN-13: El correo debe usar un formato valido
negocio:    RN-14: El teléfono debe tener 10 dígitos.

Incluye:    Ninguno
Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 124 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 125 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 126 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 127 del PDF original — 1 imagen(es)]

### CU - 23 Registrar Solicitud de Proyecto

**Descripción del caso de uso**

- **ID:** CU-23

Nombre:     Registrar Solicitud de Proyecto
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE llena el formulario solicitud prácticas profesionales, para

solicitar un proyecto de los cargados en el sistema
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Registrar Solicitud de Proyecto
- **Precondiciones:** PRE-01 El ESTUDIANTE no tiene una solicitud de proyecto pendiente.

PRE-02 Existen proyectos disponibles en la BD.
Flujo Normal: 1. El SISTEMA Obtiene una lista de PROYECTOS validados (Ver
EX1)

2. EL SISTEMA muestra GUI_RegistrarSolicitud en donde deberá
llenar algunos criterios (Sector: Núm. de Usuarios directos, Núm.
de usuarios indirectos, objetivos inmediatos, objetivos mediatos,
metodología, Recursos humanos, económicos y materiales;
Responsabilidades, Días y horarios), los cuales deberán ser
llenados, incluyendo una lista para seleccionar el PROYECTO al
que se hace referencia
3. El ESTUDIANTE llena los campos con la información que se
solicita

4. El ESTUDIANTE da click en “Registrar Solicitud” (Ver FA 4.1)
5. EL SISTEMA valida que no haya campos vacíos (Ver FA 5.1)
6. EL SISTEMA crea la SOLICITUD_PROYECTO en la base de
datos (Ver EX1)

7. EL SISTEMA muestra GUI_RegistroExitoso con el mensaje “El
registro se ha realizado con éxito”
8. Termina el caso de uso

Flujos Alternos: FA 4.1 Cancelar Registro de solicitud
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el
mensaje “¿Estás seguro de que deseas cancelar?”

2. El ESTUDIANTE da click en “Si”
3. Termina el caso de uso
FA 5.1 Campos vacíos

1. EL SISTEMA detecta campos vacíos
2. EL SISTEMA muestra la GUI_CamposVacios con el mensaje “No
puede haber campos sin datos”
3. El ESTUDIANTE da click en “Regresar”
4. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con
el mensaje “No hay conexión a la base de datos”

2. El ESTUDIANTE da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 La solicitud se registra en la base de datos.

Reglas de   RN-01 El ESTUDIANTE tiene una inscripción activa en prácticas

negocio:    profesionales.
RN-14: Máximo 3 solicitudes activas por estudiante.
Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 130 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 131 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 132 del PDF original — 2 imagen(es)]

### CU - 24 Consultar Proyecto Asignado

**Descripción del caso de uso**

- **ID:** CU-24

Nombre:     Consultar Proyecto Asignado
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE puede consultar el PROYECTO que se le fue asignado

para conocer información relevante sobre el mismo
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Consultar proyecto asignado
- **Precondiciones:** PRE-01 El ESTUDIANTE tiene un proyecto asignado.

Flujo Normal: 1. EL SISTEMA obtiene el registro de proyecto_estudiante en donde
se encuentre la matricula del ESTUDIANTE (Ver EX1)

2. EL SISTEMA muestra GUI_ProyectoAsignado en donde muestra
información básica del PROYECTO como su nombre y el nombre
de la ORGANIZACION VINCULADA (Ver FA 2.1)
3. [Extensión opcional] Si el ESTUDIANTE da click en el botón
“Consultar Cronograma”, se ejecuta el caso de uso, “Consultar
Cronograma” (CU-25)
4. [Extensión opcional] Si el ESTUDIANTE da click en el botón

“Consultar evaluaciones”, se ejecuta el caso de uso, “Consultar
evaluaciones” (CU-28)
5. El ESTUDIANTE da click en “Ver detalles”
6. EL SISTEMA muestra GUI_DetallesProyecto en donde aparece el
nombre del PROYECTO, el nombre de la ORGANIZACION
VINCULADA, su REPRESENTANTE y la duración de las
practicas. (Ver EX1)

7. Termina el caso de uso

Flujos Alternos: FA 2.1 No hay proyecto asignado
1. EL SISTEMA muestra GUI_NoHayProyectoAsignado con el
mensaje “No se encontró ningún proyecto asignado a este
Estudiante”

2. El ESTUDIANTE da click en “Cerrar”
3. Termina el caso de uso

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”

2. El ESTUDIANTE da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 El ESTUDIANTE visualiza los detalles del PROYECTO

asignado.
Reglas de   RN-01 El ESTUDIANTE tiene una inscripción activa en prácticas

negocio:    profesionales.
Incluye:    Ninguno

Extiende:   CU-25 Consultar Cronograma

### CU-28 Consultar Evaluaciones

#### Diagrama de comunicación

#### Prototipos

[FIGURA: contenido gráfico en la página 135 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 136 del PDF original — 1 imagen(es)]

### CU - 25 Consultar cronograma

**Descripción del caso de uso**

- **ID:** CU-25

Nombre:     Consultar Cronograma
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE podrá ingresar a ver con detalle su cronograma de

actividades del PROYECTO al que esta asignado.
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Consultar Cronograma
- **Precondiciones:** PRE-02 El ESTUDIANTE tiene un CRONOGRAMA registrado.

Flujo Normal: 1. EL SISTEMA obtiene el CRONOGRAMA del PROYECTO al
cual esta asignado el ESTUDIANTE (Ver EX1)

2. EL SISTEMA muestra GUI_CronogramaProyecto en el cual
muestra un horario a cumplir en las practicas (Ver FA 2.1)
3. El ESTUDIANTE da click en “Regresar”
4. Termina el caso de uso

Flujos Alternos: FA 2.1 No hay cronograma

1. EL SISTEMA muestra la GUI_NoCronogramaProyecto con el
mensaje “El cronograma no se ha subido aun”
2. El ESTUDIANTE da click en “Regresar”
3. Termina el caso de uso

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el

mensaje “No hay conexión a la base de datos”
2. El ESTUDIANTE da click en “Cerrar”

3. Termina el caso de uso

- **Postcondiciones:** POST-01 El ESTUDIANTE visualiza el cronograma de actividades.

Reglas de   RN-17: Las horas prácticas no pueden exceder 8 horas diarias.
negocio:

Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de comunicación

#### Prototipos

[FIGURA: contenido gráfico en la página 139 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 140 del PDF original — 1 imagen(es)]

### CU - 26 Registrar Autoevaluación

**Descripción del caso de uso**

- **ID:** CU-26

Nombre:     Registrar Autoevaluación
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE realiza el registro de su AUTOEVALUACION llenando

la plantilla correspondiente
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Registrar Autoevaluación
- **Precondiciones:** PRE-01 El ESTUDIANTE está asignado a un PROYECTO.

PRE-02 No hay una autoevaluación previa registrada.
Flujo Normal: 1. EL SISTEMA verifica si existe algún registro de
AUTOEVALUACION que esté relacionado con el ESTUDIANTE
(Ver EX1)

2. EL SISTEMA muestra GUI_Autoevaluacion que contiene una
plantilla con una rubrica para realizar la AUTOEVALUACION, en
donde puede seleccionar criterios para cada uno de los campos
(Ver FA 2.1)
3. El ESTUDIANTE llena todos los criterios correspondientes a su
criterio

4. El ESTUDIANTE da click en “Registrar” (FA 4.1)
5. EL SISTEMA valida que no haya criterios sin marcar (Ver FA 5.1)
6. EL SISTEMA calcula el promedio
7. EL SISTEMA crea la AUTOEVALUACION

8. EL SISTEMA muestra la GUI_AutoevaluacionRegistrada con el
mensaje “La Autoevaluación a sido registrada con éxito” (Ver
EX1)
9. Termina el caso de uso

Flujos Alternos: FA 2.1 Autoevaluación ya registrada
1. EL SISTEMA detecta que ya se ha realizado la
AUTOEVALUACION

2. EL SISTEMA muestra la GUI_AutoevaluacionExistente con el
mensaje “La Autoevaluación ya ha sido registrada”
3. El ESTUDIANTE da click en “Regresar”
4. Termina el caso de uso

FA 4.1 Cancelar Registro Autoevaluación
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el
mensaje “¿Estas seguro de que deseas cancelar?”
2. El ESTUDIANTE da click en “Si”

3. Termina el caso de uso
FA 3.1 Criterios sin marcar
1. EL SISTEMA detecta criterios sin marcar
2. EL SISTEMA muestra GUI_CriteriosSinMarcar con el mensaje

“No puede hacer criterios sin marcar”
3. El ESTUDIANTE da click en “Regresar”
4. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”
2. El ESTUDIANTE da click en “Cerrar”

3. Termina el caso de uso
- **Postcondiciones:** PRE-01 La AUTOEVALUACION se guarda en la base de datos.

PRE-02 EL SISTEMA marca la autoevaluación como completada.
Reglas de   RN-18: La autoevaluación solo se envía una vez por periodo (mensual).

negocio:
Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 143 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 144 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 145 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 146 del PDF original — 1 imagen(es)]

### CU - 27 Registrar Reporte Mensual

**Descripción del caso de uso**

- **ID:** CU-27

Nombre:     Registrar Reporte Mensual
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE realiza el REPORTE MENSUAL de las prácticas

profesionales de su PROYECTO con ayuda de una plantilla
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Registrar Reporte Mensual
- **Precondiciones:** PRE-01 El ESTUDIANTE está asignado a un PROYECTO.

Flujo Normal: 1. EL SISTEMA verifica que en los REPORTES registrados por el
ESTUDIANTE la suma total de horas no sea 420 o más (Ver EX1)
(Ver FA 1.1)

2. EL SISTEMA muestra GUI_RegistroReporte que contiene una
plantilla en donde debe ingresar datos como el número de horas
trabajadas, las actividades que se realizaron, objetivo general del
proyecto, metodología, resultados obtenidos al momento y
observaciones
3. El ESTUDIANTE llena todos los campos correspondientes

4. El ESTUDIANTE da click en “Registrar” (Ver FA 4.1)
5. EL SISTEMA valida que no haya campos vacíos (Ver FA 5.1)
6. EL SISTEMA valida que no haya datos inválidos (horas en letras,
horas reportadas mayores a 130 horas) (Ver FA 6.1)

7. EL SISTEMA calcula el total de horas registradas
8. EL SISTEMA crea el REPORTE (Ver EX1)
9. EL SISTEMA muestra la GUI_ReporteRegistrado con el mensaje
“El reporte ha sido registrado con éxito”
10. Termina el caso de uso

Flujos Alternos: FA 1.1 Horas cumplidas
1. EL SISTEMA detecta que la suma de horas totales es igual o
mayor a 420 horas

2. EL SISTEMA muestra la GUI_HorasCompletadas con el mensaje
“Las horas a reportar se han completado”
3. El ESTUDIANTE da click en “Cerrar”
4. Termina el caso de uso

FA 4.1 Cancelar Registro de Reporte
1. EL SISTEMA muestra GUI_ConfirmacionCancelacion con el
mensaje “¿Estas seguro de que deseas cancelar?”
2. El ESTUDIANTE da click en “Si”

3. Termina el caso de uso
FA 5.1 Campos Vacios
1. EL SISTEMA detecta campos vacíos
2. EL SISTEMA muestra la GUI_CamposVacios con el mensaje “No

puede haber campos sin datos”
3. El ESTUDIANTE da click “Regresar”
4. Regresa al paso 2 del flujo normal
FA 6.1 Datos Inválidos

1. EL SISTEMA detecta que los datos no son validos
2. EL SISTEMA limpia los campos erróneos
3. EL SISTEMA muestra la GUI_DatosInvalidos con el mensaje “Los
datos ingresados son inválidos”

4. El ESTUDIANTE da click en “Regresar
5. Regresa al paso 2 del flujo normal

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”
2. El ESTUDIANTE da click en “Cerrar”

3. Termina el caso de uso
- **Postcondiciones:** POST-01 El REPORTE se guarda en la base de datos.
POST-02 EL SISTEMA actualiza el total de horas acumuladas.

Reglas de   RN-19: Las horas reportadas no pueden superar 130 horas/mes.
negocio:    RN-20: El reporte requiere al menos 3 actividades descritas.

Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de secuencia

[FIGURA: contenido gráfico en la página 149 del PDF original — 1 imagen(es)]

#### Prototipos

[FIGURA: contenido gráfico en la página 150 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 151 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 152 del PDF original — 2 imagen(es)]

### CU - 28 Consultar las evaluaciones

**Descripción del caso de uso**

- **ID:** CU-28

Nombre:     Consultar las evaluaciones
- **Responsable:** Estudiante

Fecha de    28/marzo/2025
actualización:
- **Descripción:** : El ESTUDIANTE consulta las evaluaciones realizadas a su PROYECTO

asignado
- **Actor(es):** AC-04-Estudiante

- **Disparador:** El ESTUDIANTE da click en Consultar Evaluaciones
- **Precondiciones:** PRE-01 El ESTUDIANTE tiene un PROYECTO asignado.

Flujo Normal: 1. EL SISTEMA obtiene una lista de EVALUACION
PRESENTACIONES (Ver EX1)

2. EL SISTEMA muestra la GUI_EvaluacionesPresentacion en la
cual muestra una lista de las evaluaciones con su respectivo
promedio (Ver FA 2.1)
3. El ESTUDIANTE selecciona una evaluación
4. EL ESTUDIANTE da click en “Ver Detalles” para poder ver la
rúbrica de evaluación de su PRESENTACION

5. EL SISTEMA muestra GUI_EvaluacionDetalles en el cual se
muestra la rubrica de evaluación de la PRESENTACION
6. Termina el caso de uso

Flujos Alternos: FA 2.1 No hay evaluaciones registradas
1. EL SISTEMA muestra GUI_NoEvaluacionesRegistradas con el
mensaje “No se encontraron evaluaciones registradas para este
proyecto”
2. El ESTUDIANTE da click en “Cerrar”

3. Termina el caso de uso

- **Excepciones:** EX1. No hay conexión con la base de datos
1. EL SISTEMA muestra la GUI_SinConexionBaseDeDatos con el
mensaje “No hay conexión a la base de datos”

2. El ESTUDIANTE da click en “Cerrar”
3. Termina el caso de uso
- **Postcondiciones:** POST-01 El ESTUDIANTE visualiza las evaluaciones registradas de su

PRESENTACION.
Reglas de   RN-21: Las evaluaciones con promedio < 6 se destacan en rojo.

negocio:
Incluye:    Ninguno

Extiende:   Ninguno

#### Diagrama de comunicación

#### Prototipos

[FIGURA: contenido gráfico en la página 155 del PDF original — 2 imagen(es)]

[FIGURA: contenido gráfico en la página 156 del PDF original — 1 imagen(es)]

## Definición del estándar

## Introducción

Al pasar del tiempo, como programadores hemos tenido la oportunidad de presenciar muchos proyectos, a
los cuales se le atribuyen ciertas características que conforman un código mal hecho o estructurado, para
evitar este problema, decidimos crear nuestro propio estándar a partir de otro, y así hacer una correcta
codificación de nuestro proyecto. El estándar, compuesto por reglas de variables, clases, métodos,
comentarios, etc., se explicará la razón del por qué incluimos nuestro estándar, y se especificarán las
reglas que llevaremos a cabo durante la creación del proyecto para que nuestro código sea considerado al

menos en la razón de este estándar, un buen código.

Propósito

El código mal estructurado puede ocasionar problemas de mantenimiento, legibilidad, adaptación y
eficiencia, por lo que hablaremos acerca de la razón por la cual estamos dirigiendo nuestra atención a este
estándar. Estableceremos ciertas reglas para el lenguaje Java, que consisten en nombramiento de
variables, constantes, clases y métodos, también promoveremos la consistencia del código y reduciendo la
complejidad de lectura y mantenimiento.
El documento está dirigido a los líderes técnicos y programadores que conformarán el proyecto. La

decisión de su implementación está basada en crear un proyecto que, de ser posible, no tenga errores,
fomente la seguridad, facilidad de uso y actúe de acuerdo a las reglas impuestas durante la descripción de
este estándar.

Reglas de nombrado

Entre las reglas que se describirán, entraremos en detalle con el nombramiento de las variables,
constantes, clases y métodos en Java, así como el idioma, el cual será el idioma inglés, mientras que la
interfaz gráfica debe manejarse en español.

Variables
Las variables deben ser descriptivas con el nombre, y tener un formato fácil de leer, para esto decidimos
implementar el formato “camelCase”, esto significa que la primera letra es siempre minúscula y la
primera letra de cada palabra que le prosigue, es mayúscula (E.J: librosDeTerror). Los nombres no deben
estar abreviados, deben ser completamente descriptivos, por ejemplo, en vez de llamar a una variable
“addr”, llamarle “customerAddress”.

Hay clases que utilizarán sufijos, por ejemplo: para la interfaz gráfica, se utilizan de sufijos los tipos de
objeto que sean, un ejemplo de esto podría ser “variableLabel”, se usa label para especificar que esta

variable es una etiqueta de JavaFX, pero ya que se usarán más sufijos, para especificar las demás, a
continuación usaremos una tabla:

Sufijo Descripción                      Ejemplo

Button Es la clase Button de JavaFX     “searchButton”

Field  Es la clase Field de JavaFx      “nameField”

Area   Es la clase Area de JavaFx       “descriptionArea”

Box    Es proveniente de la clase ChoiceBox de JavaFX “statusBox”

Picker Es proveniente de la clase DatePicker de JavaFX “startMonthPicker”

Password Es proveniente de la clase PasswordField de JavaFX “confirmPassword”

Container Se usará este sufijo para la clase VBox de JavaFX “inputContainer”

Ejemplo correcto:
String userName;

int maxConnections;
boolean isEnabled;

Ejemplo incorrecto:

String un; // Demasiado corto y ambiguo
int mc; // No es descriptivo
boolean e; // No indica su propósito

Constantes

Las constantes deben ser declaradas en MAYUSCULAS_CON_GUIONES_BAJOS y representar valores
inmutables, un ejemplo podría ser “MAX_CONECTIONS” o “DEFAUT_TIMEOUT”.
El nombre debe ser claro y descriptivo (PI = 3.1416 en vez de p = 3.14.16), y se deben declarar como
“static final” (public static final int MAX_RETRIES = 5;).
Ejemplos correctos:

public static final int MAX_LOGIN_ATTEMPTS = 3;
public static final double TAX_RATE = 0.16;

Ejemplos incorrectos:
public static final int maxRetries = 3; // No sigue el formato de mayúsculas

public static final double tr = 0.16; // No es descriptivo

Métodos

Los nombres de los métodos deben seguir el formato “camelCase” y comenzar con un verbo que indique
la acción que realizan, por ejemplo: “calculateTotal();”, “getUserInfo();”.
El nombre debe comenzar con un verbo que describa su función (“sendEmail();”, “validateInput();”),
debemos evitar nombres genéricos o poco descriptivos como “process();” o “handle();”.

Ejemplo correcto:
public void calculateDiscount(…) {…}
public boolean isUserActive(…) {…}

public String getUserName(…) {…}

Ejemplo incorrecto:

public void calc(…) {...} // No es descriptivo
public boolean check(…) {…} // No indica claramente

Clases
Los nombres de las clases deben seguir el formato PascalCase y ser sustantivos que representan entidades
o conceptos del dominio, por ejemplo: Customer o InvoiceManager.
El nombre debe ser singular y representar una entidad o concepto claro (“User” en vez de “Users”), evitar
nombres genéricos como “Manager” o “Processor”, y usar nombres que reflejen la responsabilidad de la

clase, como “PaymentGateway” en vez de “Pay”.
Para las clases de categoría “Data Transfer Object” y “Data Access Object”, se seguirán los patrones de
diseño de datos en la base de datos utilizando los sufijos “DTO” y “DAO” respectivamente.
En el caso de las interfaces gráficas, tenemos tres tipos de clases, la ventana, el controlador, y el archivo
de estilo FXML. En el caso de los controladores, se usará el prefijo GUI, guión bajo, seguido del nombre
de la clase, con el sufijo “Controller”, por ejemplo: “GUI_UseCaseController”. Para la ventana y el
archivo FXML, se usará el mismo estándar, exceptuando el sufijo “Controller”. Ejemplo:
“GUI_UseCase” y “GUI_UseCase.fxml”.

Se usarán clases de apoyo como servicios y validadores. Para los servicios, se usará el sufijo “Service”
para identificar que este es una clase de apoyo de servicio. Ejemplo: “UserService”. Por otro lado, para
identificar los validadores, se usará el sufijo “Validator”, por ejemplo: “PasswordValidator”. Tanto para
los servicios como para los validadores, se usará upper case.

Ejemplos correctos:
public class UserService(…) {…}
public class InvoiceProcessor(…) {…}

public class PaymentGateway(…) {…}
Ejemplo incorrecto:
public class userServices {…} // No sigue PascalCase
public class ProcessInvoice {…} // No es sustantivo

Interfaces

El nombramiento de las interfaces seguirá el formato con el prefijo “I” seguido del nombre de la interfaz a
crear. Al igual que las clases, exceptuando el prefijo, se utilizara PascalCase, siendo los nombres
sustantivos y descriptivos al objeto que se refiere del dominio. por ejemplo: “ILaptopKeyboard”.
Al igual que las clases “Data Transfer Object” y “Data Access Object”, se utilizaran los sufijos “DTO” y
“DAO” para las interfaces, por ejemplo: “IStudentDAO”.
Ejemplo correcto:

public interface ILaptopKeyboard {...}

Ejemplo incorrecto:

public interface laptopkeyboardinterface {...}

Pruebas
Las pruebas que se realicen para probar el código, llevarán el nombre de la clase que se está probando,,

pero con el sufijo “Test”, esto debido a que las pruebas deberían ser explícitas con el nombre, si tenemos
una clase que se necesita probar en cuanto a funcionamiento, no es recomendable usar otro nombre, y se
necesita especificar que es una prueba.
Estilo de código
Indentación

La unidad de indentación debe ser de cuatro espacios. Este patrón debe aplicarse de manera consistente en
todo el código para mantener la claridad y la coherencia.
Ejemplo correcto:
public class Example {

public static void main(String[] args) {
if (condition) {
System.out.println("La condición es verdadera.");
}

}
}

Ejemplo incorrecto:
public class Example {

public static void main(String[] args) {
if (condition) {
System.out.println("La condición es verdadera.");
}

}
}

Llaves de Apertura y Cierre
La llave de apertura puede estar al final de la línea de la declaración o en una nueva línea, dependiendo de
la preferencia del equipo, mientras que la llave de cierre debe estar en una nueva línea, alineada con la
declaración que abrió el bloque.
Ejemplo correcto:

if (condition) {
System.out.println("La condición es verdadera.");
} else {

System.out.println("La condición es falsa.");
}

Ejemplo incorrecto:
if (condition)
{
System.out.println("La condición es verdadera.");

}
else
{

System.out.println("La condición es falsa.");
}

Ajuste de Líneas
Si una línea supera el límite de 80-100 caracteres, debe dividirse siguiendo estas reglas:
- Romper después de una coma.

- Romper después de un operador.
- Alinear la nueva línea con el inicio de la expresión en el mismo nivel.

- Si estas reglas resultan en código confuso o demasiado pegado al margen derecho, simplemente
se debe indentar cuatro espacios.

Ejemplo correcto:

int resultado = calculateSum(number1, number 2, number 3,
number 4, number 5);
double result = (value1 * factor1) + (value2 * value2) +

(value3 * factor3) + (value4 * value4);

Ejemplo incorrecto:
int resultado = calcularSuma(número1, número2, número3,

número4, número5);

Espacios en blanco

Para los espacios en blanco, se deben usar dos líneas entre secciones principales del archivo (por ejemplo,
entre clases o interfaces) y una línea en blanco entre métodos, variables locales y la primera declaración,
y antes de comentarios de bloque.

Ejemplo correcto:

public class Example {

private int number;

public Example(int number) {
this.number = number;

}

public void methodOne() {
int x = 10;

// Este es un comentario de bloque
if (x > 5) {

System.out.println("Mayor que 5");
}
}

public void methodTwo() {
System.out.println("Otro método");

}
}

Ejemplo incorrecto:
public class Example {
private int number;
public Example(int number) {

this.number = number;
}
public void methodOne() {

int x = 10;
// Este es un comentario de bloque
if (x > 5) {

System.out.println("Mayor que 5");
}
}
public void methodTwo() {

System.out.println("Otro método");
}
}

Espacios
Para los espacios, es importante que siempre haya uno después de palabras reservadas para estructuras de
control como if, for, while o switch, ya que esto hace que el código sea más fácil de leer. También es
importante dejar un espacio alrededor de los operadores binarios como +, -, *, /, ==, !=, >, <, entre otros,

para evitar que las expresiones se vean muy juntas.

Cuando se trabaja con listas de argumentos o declaraciones, cada coma debe ir seguida de un espacio. Lo
mismo ocurre en la declaración de un bucle for, donde es recomendable dejar un espacio después de cada
punto y coma (;) para mejorar la claridad. Además, después de un cast, siempre debe haber un espacio
para diferenciar mejor la conversión del valor que se está asignando.

Por otro lado, en las llamadas a métodos, no debe haber un espacio entre el nombre del método y el
paréntesis de apertura

Ejemplo correcto:
public class SpacingExample {

public void method(int parameter1, int parameter2) {
int sum = parameter1 + parameter2;

if (sum > 10) {
System.out.println("La suma es mayor que 10");
}

for (int i = 0; i < 10; i++) {
System.out.println("Iteración: " + i);

}

double result = (double) sum;

System.out.println("Resultado: " + result);
}
}

Ejemplo incorrecto:
public class IncorrectSpacing {

public void method (int parameter1,int parameter2){
int sum=parameter1+parameter2;
if(sum>10){

System.out.println("La suma es mayor que 10");
}

for(int i=0;i<10;i++){
System.out.println("Iteración:"+i);
}

double result=(double)sum;
System.out.println("Resultado:"+result);
}

}

Estructuras de Control
Las estructuras de control son fundamentales para definir el flujo de ejecución de un programa. A
continuación, se describen las reglas y buenas prácticas para el uso de las estructuras de control en Java

If (If-else, if-else if-else)
La estructura “if” se utiliza para tomar decisiones basadas en condiciones. Se deben usar llaves ({}),
incluso para los bloques de una sola línea, evitar condiciones complejas en una sola línea; en su lugar usar
booleanas descriptivas. Evitar anidamientos excesivos que no sobrepasen los 2-3 niveles.
Ejemplo correcto:

if (isUserActive) {
System.out.println("El usuario está activo");
} else if (isUserPending) {

System.out.println("El usuario está pendiente");
} else {
System.out.println("El usuario está inactivo");

}
Ejemplo incorrecto:
if (isUserActive) System.out.println("El usuario está activo."); // Falta de llaves.
if (user != null && user.isActive() && user.hasPermission()) { // Condición compleja.

System.out.println("El usuario está activo y tiene permiso.");
}

While
El bucle while se utiliza para repetir un bloque de código mientras se cumpla una condición. Hay que
asegurarse que la condición tenga una salida clara para evitar bucles infinitos, hay que usar llaves ({})
incluso para bloques de una sola línea. Evitar condiciones complejas; en su lugar usar booleanas
descriptivas

Ejemplo correcto:
while (hasElements) {
processElement();
hasElements = checkForMoreElements();

}

Ejemplo incorrecto:

while (true) { // Bucle infinito sin una salida clara.
processElement();

}

do-while

El bucle do-while es similar al while pero garantizamos que el codigo se ejecute al menos una vez. Se
usara solo cuando sea necesario ejecutar el bloque al menos una vez, hay que mantener la condición
simple y usar llaves ({}) para el bloque de codigo

Ejemplo correcto:

do {
processElement();
hasElements = checkForMoreElements();

} while (hasElements);

Ejemplo incorrecto:
do processElement(); while (hasElements); // Falta de llaves.

for
El bucle for se utiliza para iterar sobre un rango de valores o elementos. Usar nombres descriptivos para

las variables de control, solo se podrá usar variables de nombre sencillo (por ejemplo, i, j, k) solo para
bucles simples. Para iterar sobre colecciones se usará un “for-each” cuando sea posible. También evitar
modificar la variable de control dentro del bucle

Ejemplo correcto:

for (int i = 0; i < 10; i++) {
System.out.println("Iteración: " + i);
}

for (String item : items) { // For-each para colecciones.
System.out.println("Objeto: " + item);
}

Ejemplo incorrecto:
for (int a = 0; a < 10; a++) { // Nombre no descriptivo.

System.out.println(a);
a++; // Modificación incorrecta de la variable de control.
}

Switch
La estructura switch se utilizará para seleccionar un bloque de código basado en el valor de una variable.
Se usará sólo cuando haya múltiples casos claros y bien definidos, incluiremos in caso default para el
manejo de valores inesperados, también usaremos break para evitar la caída entre casos. Preferir switch

con expresiones para simplificar el código.
Ejemplo correcto:
switch (userRole) {
case "ADMIN":

System.out.println("Acceso a admin garantizado.");
break;
case "USER":

System.out.println("Acceso a usuario garantizado.");
break;
default:

System.out.println("Acceso denegado.");
break;
}

Ejemplo incorrecto:
switch (userRole) {
case "ADMIN":

System.out.println("Acceso a admin garantizado.");
case "USER": // Falta el break, causando caída entre casos.
System.out.println("Acceso a usuario garantizado.");

}

Agrupamiento y organización del código

Cada clase debe tener la siguiente organización
1. Nombre de la clase

2. Atributos de la clase
3. Constructor
4. Métodos getter y setter
5. Métodos sobrescritos

6. Métodos de clase privados
7. Métodos de clase públicos

8. Métodos sobrecargados
9. Comentarios

Aunque los prefijos no siempre están permitidos, para los métodos getters y setters usaremos sus
respectivos prefijos (get y set)
.

Comentarios
Todos los comentarios necesarios serán en español.

Tareas Pendientes (TODO)

Vamos a utilizar los comentarios de tipo TODO los vamos a utilizar para marcar tareas pendientes o
mejoras futuras que deben abordarse. Usaremos el formato //TODO: [descripción de la tarea]. La
descripción deberá ser clara y especifica, indicando que debe hacerse y si es posible, el por qué. Se evitará
dejar comentarios TODO indefinidamente; deben ser resueltos en futuras iteraciones.

Ejemplo correcto:
// TODO: Implementar validación de contraseña segura.
// TODO: Optimizar esta función para manejar grandes volúmenes de datos.

Ejemplo incorrecto:
// TODO: Arreglar esto. // Descripción demasiado vaga.

Argumentación de decisiones

Utilizaremos comentarios para justificar decisiones tomadas cuando estas no son obvias o cuando se elige

una solución que podría parecer contra intuitiva. Usaremos el formato // [Explicación de la decisión]. La
explicación debe ser concisa y enfocarse en el beneficio o la razón técnica detrás de la decisión.
Evitaremos comentarios obvios o redundantes que no aporten valor
Ejemplo correcto:
// Se utiliza un HashMap en lugar de un TreeMap para mejorar el rendimiento en inserciones frecuentes.

Map<String, Integer> cache = new HashMap<>();

// Este enfoque evita un problema de concurrencia en entornos multi-hilo.
synchronized (this) {

// Código sincronizado.
}

Ejemplo incorrecto:
// Incrementar el contador.

counter++; // Comentario redundante, el código ya es claro.

## Estructura del proyecto

El proyecto se basa de arquitectura en capas, está construido con JavaFX pero usando archivos FXML
para la creación de las ventanas e interfaces gráficas. A continuación, explicaremos las diferentes capas
que tenemos definidas en la estructura:

Capa de interfaz gráfica

En esta capa se gestionan tareas como la consulta de información para el usuario, el registro de datos, y la
actualización de registros. En cuanto a los archivos de la estructura, se encuentran las interfaces FXML,
los controladores de las ventanas y las ventanas que funcionan con las dos anteriores. En esta capa

también se encuentra la autenticación por inicio de sesión para los académicos y estudiantes.

Capa lógica

Aquí se definen los DAOs y DTOs que conviven con la base de datos, también podremos encontrar los
validadores, servicios y utilidades que se usaron en las interfaces gráficas sin hacer uso directo de la base
de datos. También podremos encontrar las interfaces de los DAOs, excepciones personalizadas y
servicios externos como el de Gmail o Drive. En la capa lógica, podemos encontrar la clase principal para
ejecutar la aplicación.

Capa de acceso de datos

En realidad, esta capa solo conecta con la base de datos a diferente nivel, ya que conectarlo directamente
es una violación al patrón de capas, y podría generar vulnerabilidades. En un principio, pensamos en

poner los DAOs en esta capa, pero al ver la estructura del patrón DAO, notamos que cada clase de acceso
a los datos hace uso de interfaces y las interfaces de usuario hacen uso de la clase DAO, por lo que no
podría estar en esta misma capa.

Tecnologías

Al usar JavaFX, requerimos de un gestor de paquetes, usamos Maven para ello, y agregamos Logger,
JUnit, Mysql, y javafx dentro del archivo “pom”, todo ejecutado en Java 22.

Dependencias externas

Durante la realización de los casos de uso, nos percatamos que debíamos usar bibliotecas para el envío de
Emails, PDFs y archivos de Google drive, por lo que precisamente usamos esas dependencias, Gmail
API, iTextPDF, y Google drive API respectivamente.

Pruebas

Las pruebas unitarias están organizadas en un paquete con el directorio “tests/data_access/DAO” ya que
estas solo prueban los métodos para el acceso a los datos. Cada clase de prueba utiliza @TestInstance
para optimizar la gestión del ciclo de vida de las pruebas.

## Prácticas de programación defensiva

Con lo que aprendimos a lo largo del curso, construimos nuestro código de acuerdo con las buenas
prácticas, esto significa que usamos prácticas de programación defensiva como:

Validación de datos

Las ventanas de la interfaz de usuario implementan una validación de campos obligatorios, esto significa
que ningún campo debe ir vacío, desde “comboBox”, campos de texto, hasta horarios y campos
numéricos.
Esto se logra con los validadores de la capa lógica y algunas expresiones regulares definidas en la misma
capa.

Manejo de errores de formato

Algunos campos de texto requieren de un formato específico, un ejemplo podrían ser los campos que usan
números para su llenado (número de académico, IDs, avance crediticio, etc.). Todos los validadores de

formato están definidos en la capa lógica, más específicamente en el paquete “utils”.

Manejo de estados de error

Implementamos métodos para el manejo de estados de error específicos para diferentes escenarios:

- Sin proyecto asignado.
- Proyecto no encontrado.

- Error de carga.

Estos métodos están presentes en “showNoProjectAssigned()”, “showProjectNotFound()” y
“showErrorLoadingProject()” respectivamente, todos ellos en la clase
“GUI_AssignedProjectController.java”.

Trazabilidad

Todos los controladores hacen uso de “Logger” para la trazabilidad del proyecto, así, podremos ver los
errores, warnings y simples mensajes que necesitemos. Esto es necesario ya que mostrarlos en consola no
es una buena práctica para el producto final, así que lo configuramos e implementamos desde un inicio.

Desborde de campos

Por último, pero no menos importante, se agregaron prácticas para evitar ingresar más caracteres de lo
necesario, esto fue posible con constantes de máximo de caracteres.

## Sección de pruebas

Todas las clases de prueba implementan un patrón estándar de configuración, el cual es:

- @BeforeAll: Establece la conexión a la base de datos.
- @BeforeEach: Limpia las tablas y reinicia los datos para cada prueba.
- @AfterAll: Cierra conexiones y limpia recursos.

Tambien se desactivan temporalmente las restricciones de claves foráneas, se truncan todas las tablas
relacionadas y reinicia los contadores “AUTO_INCREMENT”.

Pruebas por componente

El proyecto implementa pruebas exhaustivas para cada componente DAO, organizadas por funcionalidad
específica, ya sea insertar, actualizar, buscar por algún criterio, o consultar todo.

Pruebas de Integridad Referencial

El sistema implementa pruebas específicas para verificar las restricciones de claves foráneas y la
integridad de datos esto significa que se prueba la relación entre tablas para comprobar su funcionamiento
en la llave foránea o la integridad de los datos que se están utilizando.

Pruebas de Casos Límite

El sistema hace pruebas para los casos en los cuales haya datos vacíos, inválidos, no existentes, o valores
límite (Máximo o mínimo), esto hace que se valide todo lo necesario para continuar con el proyecto sin
errores innecesarios.

Verificación de Estados

Después de cada prueba, la aplicación busca en la base de datos si los datos persistieron, esto se hace con
búsquedas independientes de cada dato necesario.

## Lecciones aprendidas

Angel

En un principio la creación del código se me hace confusa, no sé bien por donde empezar a programar,
antes de este proyecto no había tenido un encuentro tan cercano con una base de datos y el cómo se
pueden manipular sus datos. Fue la primera vez que utilice un patrón de diseño como puede ser el DAO
que, hasta inicios de este semestre, al menos en mi caso, no sabía de su existencia.

Me gustó mucho trabajar en el código e ir viendo como en un principio trabajaba de manera muy
diferente a como lo hago en este momento, sé que me queda mucho por mejorar pero tan solo con el buen
manejo de las excepciones, el utilizar un logger para poder tener un registro de las mismas, utilizar
JavaFX, el SceneBuilder, incluso el nuevo tema de programación a la defensiva me hicieron aprender
cosas de bastante interés que incluso procuramos utilizar en nuestros proyectos ya que tenemos ahora un
pensamiento más allá de que nuestro código solo funcione.

Tambien fue un poco a aprender a utilizar la ia para realizar tareas que suelen ser repetitivas, pero
sabiendo que está bien hecho y que está mal poder cuestionar las cosas que me da como respuesta y
adaptarlas o repararlas para que sea un código bien hecho que siga buenas prácticas.
Por último, quiero mencionar que fue uno de los primeros proyectos realmente largos que hemos

realizado en la carrera y el ver como todo fue tomando forma con los días de trabajo, las observaciones y
revisiones del profesor e incluso ayudarnos entre compañeros es una experiencia cansada, pero a la
vez gratificante.

Darlington

A lo largo de la creación de este proyecto y el curso de Principios de Construcción de Software, como
estudiante, he aprendido a hacer un buen uso de las excepciones, usar la programación defensiva,

perfeccionar código, seguir un estándar a la hora de escribir código, y a ayudarme de herramientas como
la IA, StackOverflow, buscar de una manera más específica en Google u otros motores de búsqueda, etc.

Si tuviera que elegir una de las cosas que más aprendí durante este proyecto, podría ser que ahora sé
seguir casos de uso y diagramas para construir código, sé usar patrones de diseño para este mismo y
estudiarlos para usarlos después. Sinceramente me gustaría seguir aprendiendo sobre la ingeniería de

software y las dificultades que esta presenta, aunque termine siendo un poco exhaustivo, tedioso e incluso
hasta difícil.

## Conclusiones de equipo y proyecto

Para la realización del proyecto, usamos algunas cosas que no imaginamos, como puede ser un logger,
javaFX, Maven, etc. Pero de acuerdo con el proyecto, empezamos con los requisitos desde el curso
pasado, por lo que veníamos con una idea de cómo hacerlo, así que no podríamos decir que estábamos
con las manos vacías, pero si fue algo difícil terminarlo hasta este punto. Sobre el proyecto, solo podemos
decir fue algo difícil tener que hablar con cada usuario que podría tener acceso al sistema, tener una
ventana para cada caso de uso y diseñarla ahí mismo, esto no solo es algo que lleva tiempo, sino algo que
se debe aprender para poder tener conocimientos como ingeniero de software, este proyecto tomó algo de
tiempo que era difícil de pensar, pero ahora que ya está en estas fases, podemos decir que vienen cosas

mas importantes, sino es que más difíciles.

## Referencias

- Naveen, S. (2011, mayo 8). Java Standards. www.nea.gov.bh.

https://www.nea.gov.bh/Attachments/eServices%20Standards/Java_standards_V1.0.pdf

- Fakhroutdinov, K. (s/f). Unified Modeling Language (UML) description, UML diagram
examples, tutorials and reference for all types of UML diagrams - use case diagrams, class,
package, component, composite structure diagrams, deployments, activities, interactions,
profiles, etc. Uml-diagrams.org. Recuperado el 20 de junio de 2025, de https://www.uml-

diagrams.org/

- Design patterns: Data access object. (s/f). Oracle.com. Recuperado el 20 de junio de 2025, de
https://www.oracle.com/java/technologies/data-access-object.html

- Java SE application design with MVC. (s/f). Oracle.com. Recuperado el 20 de junio de 2025, de

https://www.oracle.com/technical-resources/articles/javase/application-design-with-mvc.html

- Prácticas de Ingeniería de Software – Para estudiantes – Facultad de Estadística e Informática.
(s/f). Www.uv.mx. Recuperado el 20 de junio de 2025, de https://www.uv.mx/fei/practicas-
is/practicas-de-ingenieria-de-software-para-estudiantes/

## Declaración de uso de IA

En este proyecto se ha hecho uso de IA, específicamente las herramientas:

- Herramientas utilizadas: Durante la creación de este proyecto, se utilizaron herramientas como
Github Copilot, ChatGPT y ClaudeAI.

- Propósito: El uso de las herramientas antes mencionadas, fue con propósito de aprendizaje y
acortar tiempos en reutilización de código.

- Alcance: El uso de IA en su mayoría está presente en las partes repetitivas del código, por
ejemplo, los DTOs y DAOs, se hizo una clase de cada una de las mencionadas, y a partir de esas,
se crearon más con el uso de IA para reducir el tiempo de escritura de código.

- Revisión humana: Todo el código generado con IA fue revisado y analizado por los integrantes
del equipo.

- Porcentaje de IA utilizado: 40%

