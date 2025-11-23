
---
![Gameplay](MultiplayerLocal.gif)

### 🚀 How to Run

1. Open the project in **Unity 6000.2** or higher
2. Load the scene `Assets/Scenes/PA4.unity`
3. Press **Play** in the Editor
4. Use the mentioned controls for each player
5. Reach the goals to complete the level

---

### ⚙️ Important Configuration

#### **Physics 2D**
- Ensure the **Layer Collision Matrix** allows collision between "Player" and "Ground"
- Tilemaps must have `Rigidbody2D` with **Body Type: Static**

#### **Layers**
- `Player`: Players
- `Ground`: Platforms and ground
- `Minimap`: Minimap indicators
- `P1Particles`: Camera P1 exclusive particles
- `P2Particles`: Camera P2 exclusive particles

#### **Tags**
- `Player`: Assigned to both players for trigger detection

---

### 📊 Technical Specifications

- **Engine:** Unity 6000.2
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Renderer:** 2D
- **Physics:** Physics 2D with Composite Colliders
- **Input:** New Input System with Action Maps

---

### 👥 Author

**Aldhair Vera Camacho**

🌐 More projects: [https://aldhairvera.netlify.app/](https://aldhairvera.netlify.app/)

---

### 📄 License

Educational project. Character assets by third parties (see attributions in sprites).

---
---

<a name="español"></a>
## 🇪🇸 Versión en Español

![Gameplay](MultiplayerLocal.gif)

### 📝 Descripción

Juego de plataformas 2D para **2 jugadores locales** desarrollado en Unity 6. Los jugadores compiten para llegar a sus metas respectivas mientras evitan caer en zonas de muerte. El juego incluye cámaras divididas, minimapas, efectos de partículas y sistema de respawn.

---

### 🎮 Controles

#### **Jugador 1 (Ninja Frog)**
- **A / D**: Moverse izquierda/derecha
- **Espacio**: Saltar

#### **Jugador 2 (Virtual Guy)**
- **Numpad 4 / Numpad 6**: Moverse izquierda/derecha
- **Numpad 8**: Saltar

---

### ✨ Características

#### **Gameplay**
- ✅ Multijugador local para 2 jugadores
- ✅ Niveles independientes para cada jugador
- ✅ Sistema de detección de suelo (ground check)
- ✅ Zonas de muerte con respawn automático
- ✅ Metas individuales con celebración
- ✅ Reinicio automático cuando ambos jugadores completan sus objetivos

#### **Cámaras y UI**
- ✅ 4 cámaras en total:
  - 2 cámaras principales con pantalla dividida (split-screen)
  - 2 minimapas independientes
- ✅ Cámaras con seguimiento mediante Cinemachine
- ✅ Límites de cámara (camera confiner)
- ✅ Indicadores visuales en minimapas para jugadores y metas

#### **Efectos Visuales**
- ✅ Sistema de partículas de nieve (Player 1)
- ✅ Sistema de partículas de viento con polvo (Player 2)
- ✅ Explosión de confeti al llegar a la meta (cada 3 segundos)
- ✅ Camera shake al alcanzar la meta
- ✅ Partículas visibles solo en cámaras específicas (culling layers)

---

### 🛠️ Arquitectura Técnica

#### **Scripts Principales**

##### `PlayerMovement2D.cs`
Controla el movimiento y comportamiento de los jugadores.
- Movimiento horizontal con Rigidbody2D
- Sistema de salto con verificación de suelo mediante `Physics2D.OverlapCircle`
- Integración con Input System para múltiples jugadores
- Sistema de habilitación/deshabilitación de controles
- Método de respawn para zonas de muerte

##### `DeathZone.cs`
Gestiona las zonas de muerte del nivel.
- Detección por trigger de colisiones con jugadores
- Teletransportación a puntos de spawn definidos
- Reset de velocidad del Rigidbody2D

##### `GoalTrigger.cs`
Sistema de metas y condiciones de victoria.
- Detección de llegada de cada jugador a su meta
- Desactivación de controles al completar objetivo
- Activación de efectos de camera shake
- Coroutine para explosiones de confeti recurrentes
- Verificación de ambos jugadores para reiniciar nivel

##### `CameraShake.cs`
Efectos de vibración de cámara.
- Patrón Singleton para acceso global
- Control independiente para ambas cámaras
- Integración con Cinemachine BasicMultiChannelPerlin
- Temporizadores para duración de efectos

---

### 📦 Dependencias (Packages)

- **Unity Input System** (1.14.2) - Sistema moderno de inputs
- **Cinemachine** (3.1.5) - Cámaras virtuales y seguimiento
- **Universal RP** (17.2.0) - Render pipeline
- **2D Animation** (12.0.3) - Animaciones de personajes
- **2D Tilemap** (1.0.0) - Sistema de niveles
- **Unity Recorder** (5.1.3) - Grabación de gameplay

---

### 🎨 Assets

#### **Sprites**
- Personajes: Ninja Frog (P1) y Virtual Guy (P2)
- Backgrounds personalizados por jugador
- Tileset para construcción de niveles

#### **Estructura de Carpetas**
