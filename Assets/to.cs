
using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using UnityEngine;

public class to : MonoBehaviour
{
    public MidiStreamPlayer midiStreamPlayer;   // Initialized at Start() or could be set in the Inspector
    private MPTKEvent mptkEvent;
    [Range(0, 127)]
    public int Key;
    private Renderer renderer;
    Color prevColor;

    // Preset 
    [Range(0, 127)]
    public int Preset;
    private bool active = false;



    // Start is called before the first frame update
    void Start()
    {
      //  Key = NoteSettings.KeyValue;
        Debug.Log("Start: dynamically load MidiStreamPlayer prefab from the hierarchy.");
        midiStreamPlayer = FindObjectOfType<MidiStreamPlayer>();

        if (midiStreamPlayer == null)
            Debug.LogWarning("Can't find a MidiStreamPlayer Prefab in the current scene hierarchy. You can add it with the Maestro menu in Unity editor.");
        else
            Debug.Log("<color=green>Use key <Space> to play a note.</color>");
        renderer = GetComponent<Renderer>();
        prevColor = renderer.material.color;
    }

    public void NoteOnManager()
    {
        // Assign our "Hello, World!" (using MPTKEvent's defaults value, so duration = -1 for an infinite note playing
        // Value = 60 for playing a C5 (HelperNoteLabel class could be your friend)
        mptkEvent = new MPTKEvent()
        {
            Value = Key,
            Channel = 0, // from 0 to 15, 9 reserved for drum
            Duration = -1, // note duration in millisecond, -1 to play undefinitely, MPTK_StopChord to stop
            Velocity = 120, // from 0 to 127, sound can vary depending on the velocity
            Delay = 0, // delay in millisecond before playing the note
        };

        // Start playing our "Hello, World!" note C5
        midiStreamPlayer.MPTK_PlayEvent(mptkEvent);
        renderer.material.color = prevColor.gamma;
    }


    public void NoteOffManager()
    {
        // Stop playing our "Hello, World!" note C5
        midiStreamPlayer.MPTK_StopEvent(mptkEvent);
        renderer.material.color = prevColor;
    }
    public void ChangePreset()
    {
        //Change preset if needed. We can use always the channel 0 because all MidiStreamPlayer are using
        // an independant synthesizer, like different keyboards connected with a MIDI wire.
        // So changing the preset on one will not change others MidiStreamPlayer settings.
        if (midiStreamPlayer.MPTK_Channels[mptkEvent.Channel].PresetNum != Preset)
            midiStreamPlayer.MPTK_Channels[mptkEvent.Channel].PresetNum = Preset;
    }
    public void OnTriggerEnter(Collider collision)
    {
        activateManager();

        Debug.Log(collision.gameObject.name);

    }

    private void activateManager()
    {
        if (active)
        {
            NoteOffManager();
            active = false;

        }
        else
        {
            NoteOnManager();
            ChangePreset();
            active = true;

        }
        Debug.Log(active);
    }
}