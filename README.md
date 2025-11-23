
# 🕹️ Multiplayer Local Platformer – Unity 2D

![Gameplay](MultiplayerLocal.gif)

---

## 🚀 How to Run

1. Open the project in **Unity 6000.2** or higher  
2. Load the scene: `Assets/Scenes/PA4.unity`  
3. Press **Play** in the Editor  
4. Use the controls listed below for each player  
5. Reach the goals to complete the level  

---

## 🎮 Controls

### **Player 1 (Ninja Frog)**
- **A / D** – Move left/right  
- **Space** – Jump  

### **Player 2 (Virtual Guy)**
- **Numpad 4 / Numpad 6** – Move left/right  
- **Numpad 8** – Jump  

---

## ✨ Features

### **Gameplay**
- Local multiplayer for **2 players**
- Independent level lanes for each player  
- Ground detection system (OverlapCircle)  
- Death zones with automatic respawn  
- Individual goal triggers with celebration  
- Automatic level reset when both reach their goals  

### **Cameras & UI**
- **4 cameras total**:
  - 2 main cameras for split-screen  
  - 2 minimap cameras  
- Cinemachine virtual cameras with smooth follow  
- Camera boundaries using Confiner 2D  
- Minimap indicators for players and goals  

### **Visual Effects**
- Snow particles (Player 1)  
- Wind/dust particles (Player 2)  
- Confetti explosion every 3 sec on reaching goal  
- Camera shake on player goal  
- Per-camera particle visibility using culling masks  

---

## 🛠️ Technical Architecture

### **Key Scripts**

#### **PlayerMovement2D.cs**
Handles player movement and physics:
- Rigidbody2D horizontal movement  
- Jump system with ground check  
- Integration with Unity Input System  
- Ability to enable/disable controls  
- Respawn support for death zones  

#### **DeathZone.cs**
Manages death areas:
- Trigger detection  
- Teleportation to custom spawn points  
- Resets Rigidbody2D velocity  

#### **GoalTrigger.cs**
Handles goal completion:
- Detects when each player reaches their own goal  
- Disables controls on completion  
- Activates camera shake  
- Coroutine for looping confetti bursts  
- Level restart when both players finish  

#### **CameraShake.cs**
Implements screen shake:
- Singleton pattern  
- Independent shake for both cameras  
- Uses Cinemachine BasicMultiChannelPerlin  
- Configurable duration and strength  

---

## ⚙️ Important Configuration

### **Physics 2D**
- Ensure Layer Collision Matrix allows **Player ↔ Ground**  
- Tilemaps must include a `Rigidbody2D` set to **Static**  

### **Layers**
- **Player:** Both player characters  
- **Ground:** Platforms & ground tiles  
- **Minimap:** Icons and minimap elements  

### **Tags**
- **Player:** Assigned to both characters for trigger logic  

---

## 📦 Dependencies (Packages)

- **Unity Input System** (1.14.2)  
- **Cinemachine** (3.1.5)  
- **Universal Render Pipeline (URP)** (17.2.0)  
- **2D Animation** (12.0.3)  
- **2D Tilemap** (1.0.0)  
- **Unity Recorder** (5.1.3)  

---

## 🎨 Assets

### Sprites
- Ninja Frog (Player 1)  
- Virtual Guy (Player 2)  
- Custom background per player  
- Tilemap level set  

---

## 👤 Author
**Aldhair Vera Camacho**  
🌐 Portfolio: https://aldhairvera.netlify.app/

---

## 📄 License
Educational project. Sprite assets belong to their respective authors.

---

---

# 🇪🇸 Versión en Español

![Gameplay](MultiplayerLocal.gif)

---

## 🚀 Cómo Ejecutarlo

1. Abre el proyecto con **Unity 6000.2** o superior  
2. Carga la escena: `Assets/Scenes/PA4.unity`  
3. Presiona **Play** en el Editor  
4. Usa los controles indicados para cada jugador  
5. Llega a la meta para completar el nivel  

---

## 🎮 Controles

### **Jugador 1 (Ninja Frog)**
- **A / D** – Moverse izquierda/derecha  
- **Espacio** – Saltar  

### **Jugador 2 (Virtual Guy)**
- **Numpad 4 / Numpad 6** – Moverse izquierda/derecha  
- **Numpad 8** – Saltar  

---

## ✨ Características

### **Gameplay**
- Multijugador local para **2 jugadores**  
- Carriles independientes para cada jugador  
- Sistema de detección de suelo (OverlapCircle)  
- Zonas de muerte con respawn automático  
- Metas individuales con celebración  
- Reinicio automático cuando ambos llegan a su meta  

### **Cámaras y UI**
- **4 cámaras en total**:
  - 2 cámaras principales con pantalla dividida  
  - 2 minimapas independientes  
- Cámaras Cinemachine con seguimiento suave  
- Límites de cámara con Confiner 2D  
- Indicadores para jugadores y metas en minimapas  

### **Efectos Visuales**
- Partículas de nieve (Jugador 1)  
- Partículas de viento/polvo (Jugador 2)  
- Explosión de confeti cada 3 segundos al llegar a la meta  
- Cámara temblorosa (camera shake) al ganar  
- Partículas visibles solo en cámaras específicas (culling masks)  

---

## 🛠️ Arquitectura Técnica

### **Scripts Principales**

#### **PlayerMovement2D.cs**
Controla movimiento y físicas:
- Movimiento horizontal con Rigidbody2D  
- Salto con detección de suelo  
- Integración con Input System  
- Habilitar/deshabilitar controles  
- Respawn para zonas de muerte  

#### **DeathZone.cs**
Gestiona áreas de muerte:
- Detección por trigger  
- Teletransporte a puntos de respawn  
- Reinicio de velocidad del Rigidbody2D  

#### **GoalTrigger.cs**
Controla las metas:
- Detecta llegada del jugador  
- Desactiva controles al completar  
- Activa camera shake  
- Coroutine de confeti repetitivo  
- Reinicio del nivel cuando ambos ganan  

#### **CameraShake.cs**
Efecto de vibración:
- Patrón Singleton  
- Shake independiente por cámara  
- Cinemachine BasicMultiChannelPerlin  
- Duración configurable  

---

## ⚙️ Configuración Importante

### **Physics 2D**
- Asegurar colisión Player ↔ Ground en Layer Collision Matrix  
- Tilemaps deben tener un `Rigidbody2D` tipo **Static**  

### **Layers**
- **Player:** Ambos jugadores  
- **Ground:** Suelo y plataformas  
- **Minimap:** Elementos del minimapa  

### **Tags**
- **Player:** Para detección de triggers  

---

## 📦 Dependencias (Packages)

- **Unity Input System** (1.14.2)  
- **Cinemachine** (3.1.5)  
- **URP – Universal Render Pipeline** (17.2.0)  
- **2D Animation** (12.0.3)  
- **2D Tilemap** (1.0.0)  
- **Unity Recorder** (5.1.3)  

---

## 🎨 Assets

### Sprites
- Ninja Frog (Jugador 1)  
- Virtual Guy (Jugador 2)  
- Background personalizado por jugador  
- Tilemap del nivel  

---

## 👤 Autor
**Aldhair Vera Camacho**  
🌐 Portafolio: https://aldhairvera.netlify.app/

---

## 📄 Licencia
Proyecto educativo. Los sprites pertenecen a sus respectivos autores.
