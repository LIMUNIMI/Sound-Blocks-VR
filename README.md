# Sound Block VR
Sound Blocks VR is an Accessible Digital Musical Instrument built using Unity that allows users to engage in collaborative musical performances in augmented or virtual reality environments. It integrates various libraries to manage virtual components, supports the MIDI (Musical Instrument Digital Interface) protocol for controlling synthesizers, and provides an immersive experience using the Meta XR All-in-One SDK. 

Below is an overview of the project structure, key components, and scripts:
Project Structure

Main Scene
•	Scene Name: WithMetaAllInOne
•	Path: Assets\Scenes\WithMetaAllInOne
•	This scene is the core environment where the interaction and musical performance are managed.

Key Prefabs (Located in Assets/Prefabs/)
1.	OnOverNote.prefab
o	Function: This is the primary playable object in the scene. Users can interact with it by touching it to produce musical notes. It’s possible to move this type of object around the scene grabbing it.
2.	Canvas.prefab
o	Function: This canvas is used to set the musical parameters associated with each OnOverNote.prefab spawned in the scene, allowing customization of the sound.
3.	MidiStreamPlayer.prefab
o	Function: Facilitates the transmission of MIDI messages to control the sound synthesis.
4.	PresetMajorparent.prefab
o	Function: A collection of OnOverNote.prefab objects pre-configured to produce a major scale, allowing users to easily play a harmonious set of notes.
5.	ObjectsToSpawnCanvas.prefab
o	Function: A canvas used to spawn OnOverNote.prefab and PresetMajorparent.prefab objects, enabling users to introduce new musical elements into the scene.
Main Scripts
1.	Manager.cs
o	Path: Assets/Manager.cs
o	Function: This script contains common functions that handle the sending of MIDI messages, likely coordinating between the user inputs and the MIDI outputs.
2.	OnOverInteraction.cs
o	Path: Assets/OnOverInteraction.cs
o	Function: Manages the interaction between the user’s hands or controllers and the in-scene objects, particularly focusing on how users manipulate the OnOverNote.prefab.
3.	NoteSettings.cs
o	Path: Assets/NoteSettings.cs
o	Function: This script is responsible for setting and managing the musical parameters of the objects, such as pitch, channel, and other note-specific settings.
4.	SpawnGO.cs
o	Path: Assets/SpawnGO.cs
o	Function: Handles the spawning of OnOverNote.prefab and PresetMajorparent.prefab in the scene, enabling dynamic creation of musical elements and usibg them during the performance.

Libraries and SDKs Used
•	Meta XR All-in-One SDK: Provides the tools necessary for creating an immersive VR experience within Unity.
•	MIDI Maestro Toolkit (Free Version): Integrates MIDI and sound synthesis functionalities into Unity, allowing for the creation and control of musical notes and instruments via MIDI.

This setup allows users to create, manipulate, and perform music in a virtual environment, making it accessible for both solo and collaborative performances in augmented and virtual reality.


