using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;


public class Manager : MonoBehaviour
{
    public MidiStreamPlayer midiStreamPlayer;   // Initialized at Start() or could be set in the Inspector
    private MPTKEvent mptkEvent;
   
    private bool isNoteON = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Starter(MidiStreamPlayer midiStreamPlayer)
    {

        Debug.Log("Start: dynamically load MidiStreamPlayer prefab from the hierarchy.");
        //midiStreamPlayer = FindObjectOfType<MidiStreamPlayer>();

        if (midiStreamPlayer == null)
            Debug.LogWarning("Can't find a MidiStreamPlayer Prefab in the current scene hierarchy. You can add it with the Maestro menu in Unity editor.");
        else
            Debug.Log("<color=green>Use  key <Space> to play a note.</color>");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NoteOffManager(MidiStreamPlayer midiStreamPlayer, int pitchValue, int channel, int duration = -1, int velocity = 0, int delay = 0)
    {
        // if (!(isNoteON)) return;
        // Stop playing our "Hello, World!" note C5
        //   mptkEvent.Velocity = 0;
        midiStreamPlayer.MPTK_StopEvent(mptkEvent);
 
        Debug.Log("off " + mptkEvent);
    }
        
   public void ChangePreset(MidiStreamPlayer midiStreamPlayer, int preset, int channel)
    {
        //Change preset if needed. We can use always the channel 0 because all MidiStreamPlayer are using
        // an independant synthesizer, like different keyboards connected with a MIDI wire.
        // So changing the preset on one will not change others MidiStreamPlayer settings.
        if (midiStreamPlayer.MPTK_Channels[channel].PresetNum != preset)
            midiStreamPlayer.MPTK_Channels[channel].PresetNum = preset;

    }
       
   public void NoteOnManager(MidiStreamPlayer midiStreamPlayer, int pitchValue, int channel,int duration=-1, int velocity=120, int delay=0)
    {

        // if (isNoteON) return;
        mptkEvent = new MPTKEvent()
        {
            Command = MPTKCommand.NoteOn,
            Value = pitchValue,
            Channel = channel, // from 0 to 15, 9 reserved for drum
            Duration = duration, // note duration in millisecond, -1 to play undefinitely, MPTK_StopChord to stop
            Velocity = velocity, // from 0 to 127, sound can vary depending on the velocity
            Delay = delay, // delay in millisecond before playing the note
        };
        midiStreamPlayer.MPTK_PlayEvent(mptkEvent);
        isNoteON = true;
        Debug.Log("on " + mptkEvent);
    }
}

