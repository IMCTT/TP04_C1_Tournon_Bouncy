# Bouncy — Trabajo Práctico N°04

Juego de Pong para 2 jugadores desarrollado en Unity, con mecánicas personalizadas, físicas reales y configuración vía Scriptable Objects.

🎮 **Jugalo en Itch.io:** [https://sueni.itch.io/bouncy]

---

## 📋 Descripción

Pong clásico de 2 jugadores con:

- Movimiento basado en físicas (`Rigidbody2D` + `AddForce`).
- Velocidad de la pelota que aumenta con cada impacto.
- Partidos al mejor de 5 (configurable).
- Límite de tiempo por posesión: si un jugador no convierte el gol antes de que se acabe el tiempo, pierde el punto.
- Paletas que cambian de color al chocar contra los límites de la pantalla o al golpear la pelota.
- Controles duales: WASD y flechas horizontales.

---

## 🕹️ Controles

JUGADOR IZQUIERDA:                                       

Movimiento: WASD                                                 

Cambiar color: R                                                            

JUGADOR DERECHA:

Movimiento: Flechas de teclado

Cambiar color: R 

PAUSA/PAUSE: ESC

Cada jugador está limitado a su propio lado de la cancha (medio y arco correspondiente).

---

## ⚙️ Scriptable Objects — GameSettings

El juego usa un `ScriptableObject` como fuente única de configuración, referenciado por los distintos scripts (`GameManager`, `Ball`, `GoalTimer`, etc.) en vez de tener valores hardcodeados o repetidos.

Parámetros configurables desde el asset (sin tocar código):

- **Points To Win**: puntos necesarios para ganar el partido (default: 3, mejor de 5).
- **Goal Time Limit**: segundos que tiene un jugador para convertir el gol antes de que se lo hagan en contra (default: 20).
- **Initial Ball Speed**: velocidad inicial de la pelota.
- **Speed Increase Per Hit**: incremento de velocidad en cada impacto.
- **Max Ball Speed**: tope máximo de velocidad de la pelota.

---


## 🔧 Mecánicas técnicas

- **Físicas**: jugadores y pelota se mueven exclusivamente con `Rigidbody2D` (sin `transform.position` directo), cumpliendo con el uso de `AddForce` / velocity pedido por la cátedra.
- **Rebote de la pelota**: reflejo de velocidad calculado con `Vector2.Reflect` sobre la normal de colisión, manteniendo velocidad constante salvo el incremento configurado por impacto.
- **Cambio de color de paddle**:
  - Al chocar contra un límite de pantalla → color negro.
  - Al golpear la pelota → color aleatorio.
- **Timer de gol**: cada vez que la pelota entra en la mitad de cancha de un jugador, arranca la cuenta regresiva definida en `GameSettings.goalTimeLimit`; si se agota sin gol convertido, se anota el punto en contra.

---


---

## 👤 Créditos

- **Desarrollo**: Tomas Tournon
- **Assets utilizados**: https://kenney.nl/assets/ui-pack  https://kenney.nl/assets/planets https://kenney.nl/assets/simple-space
- **Cátedra**: Fede Olive

---

## 📌 Estado del TP

- [x] Movimiento por físicas (Rigidbody + AddForce)
- [x] Rebote de pelota con incremento de velocidad
- [x] Scriptable Object `GameSettings`
- [x] Mejor de 5 configurable
- [x] Límite de tiempo por posesión configurable
- [x] Cambio de color de paddle (límites / impacto)
- [x] Sistema de obstáculos (avanzado)
- [ ] Sistema de power-ups con Object Pool (avanzado)
