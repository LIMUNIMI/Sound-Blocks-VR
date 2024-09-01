# Sound Blocks VR

Sound Blocks VR is an Accessible Digital Musical Instrument (ADMI) designed to enable users to engage in collaborative musical performances within augmented and virtual reality (AR/VR) environments. Built using Unity, this project integrates various libraries and SDKs to manage virtual components, support the MIDI (Musical Instrument Digital Interface) protocol for controlling synthesizers, and provide an immersive experience via the Meta XR All-in-One SDK.

## Project Structure

### Main Scene

- **Scene Name**: `WithMetaAllInOne`
- **Path**: `Assets/Scenes/WithMetaAllInOne`
- **Description**: This scene serves as the core environment where user interactions and musical performances are managed.

### Key Prefabs

Located in `Assets/Prefabs/`:

1. **OnOverNote.prefab**
   - **Function**: The primary playable object in the scene. Users can interact with it by touching it to produce musical notes. It can be moved around the scene by grabbing it.

2. **Canvas.prefab**
   - **Function**: This canvas is used to set the musical parameters associated with each `OnOverNote.prefab` spawned in the scene, allowing for sound customization.

3. **MidiStreamPlayer.prefab**
   - **Function**: Facilitates the transmission of MIDI messages to control sound synthesis.

4. **PresetMajorparent.prefab**
   - **Function**: A collection of `OnOverNote.prefab` objects pre-configured to produce a major scale, allowing users to easily play a harmonious set of notes.

5. **ObjectsToSpawnCanvas.prefab**
   - **Function**: A canvas used to spawn `OnOverNote.prefab` and `PresetMajorparent.prefab` objects, enabling users to introduce new musical elements into the scene.

### Main Scripts

1. **Manager.cs**
   - **Path**: `Assets/Manager.cs`
   - **Function**: Contains common functions that handle the sending of MIDI messages, likely coordinating between user inputs and MIDI outputs.

2. **OnOverInteraction.cs**
   - **Path**: `Assets/OnOverInteraction.cs`
   - **Function**: Manages the interaction between the user’s hands or controllers and the in-scene objects, focusing on how users manipulate the `OnOverNote.prefab`.

3. **NoteSettings.cs**
   - **Path**: `Assets/NoteSettings.cs`
   - **Function**: Responsible for setting and managing the musical parameters of the objects, such as pitch, channel, and other note-specific settings.

4. **SpawnGO.cs**
   - **Path**: `Assets/SpawnGO.cs`
   - **Function**: Handles the spawning of `OnOverNote.prefab` and `PresetMajorparent.prefab` in the scene, enabling dynamic creation of musical elements during the performance.

## Libraries and SDKs Used

- **Meta XR All-in-One SDK**: Provides tools for creating an immersive VR experience within Unity.
- **MIDI Maestro Toolkit (Free Version)**: Integrates MIDI and sound synthesis functionalities into Unity, allowing for the creation and control of musical notes and instruments via MIDI.


---

This README provides a basic overview of the Sound Blocks VR project structure and key component For further details, refer to the specific scripts and assets within the project.
