using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MidiPlayerTK;
//using UnityEditor.ShaderGraph.Internal;

public class NoteSettings : MonoBehaviour
{
    //public static int increment;
    [Range(0, 127)]
    public int KeyValue =60;
    public TMP_Text pitchLabel;

    public int ChannelValue = 0;
    public TMP_Text channelLabel;

    public int VelocityValue = 90;
    public TMP_Text VelocityLabel;


    public int PatchValue = 0;
    public TMP_Text PatchLabel;

    public int DelayValue = 0;
    public TMP_Text DelayLabel;

    private MidiStreamPlayer midiStreamPlayer;
    Manager myManager;
    public GameObject inputManagerGO;


    // Start is called before the first frame update
    void Start()
    {
        //pitchLabel.SetText("" + KeyValue);
        channelLabel.SetText("" + ChannelValue);
        pitchLabel.SetText("" + (ChannelValue == 9 ? HelperNoteLabel.LabelPercussion(KeyValue) :
        HelperNoteLabel.LabelFromMidi(KeyValue)) + ": " + KeyValue);
        VelocityLabel.SetText("" + VelocityValue);
        //PatchLabel.SetText("" + PatchValue);
        PatchLabel.SetText(""+ Starter.dizionario[ChannelValue]);
        DelayLabel.SetText("" + DelayValue);
        myManager = inputManagerGO.GetComponent<Manager>();
        midiStreamPlayer = FindObjectOfType<MidiStreamPlayer>();
        //myManager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        PatchLabel.SetText("" + Starter.dizionario[ChannelValue]);

    }
    void Test(){
        Debug.Log("hu");
    }
    

    public void ChangePitch(int increment)
    {
        KeyValue = KeyValue + increment;
        if(ChannelValue == 9)
        {
            if (KeyValue < 27) KeyValue = 27;
            if (KeyValue > 87) KeyValue = 87;
            PatchValue =0;
        }
        else
        {
            if (KeyValue < 0) KeyValue = 0;
            if (KeyValue > 127) KeyValue = 127;
        }

        pitchLabel.SetText("" + (ChannelValue == 9 ? HelperNoteLabel.LabelPercussion(KeyValue) :
                HelperNoteLabel.LabelFromMidi(KeyValue)) + ": " + KeyValue);
        
    }

    public void ChangeChannel(int increment)
    {
        ChannelValue = ChannelValue + increment;
        if (ChannelValue < 0) ChannelValue = 0;
        if (ChannelValue > 15) ChannelValue = 15;
        channelLabel.SetText("" + ChannelValue);
        ChangePitch(0);
       // ChangePatch(0);
                
    }

    public void ChangeVelocity(int increment)
    {
        VelocityValue = VelocityValue + increment;
        if (VelocityValue < 0) KeyValue = 0;
        if (VelocityValue > 127) VelocityValue = 127;
        VelocityLabel.SetText("" + VelocityValue);
    }

    public void ChangePatch(int increment)
    {
        Starter.dizionario[ChannelValue] = Starter.dizionario[ChannelValue] + increment;
        if (Starter.dizionario[ChannelValue] < 0) Starter.dizionario[ChannelValue] = 0;
        if (Starter.dizionario[ChannelValue] > 127) Starter.dizionario[ChannelValue] = 127;
        // Manager.dizionario[ChannelValue] = PatchValue;
        PatchLabel.SetText(""+Starter.dizionario[ChannelValue]);
        myManager.ChangePreset(midiStreamPlayer, Starter.dizionario[ChannelValue], ChannelValue);
        Debug.Log(Starter.dizionario[ChannelValue]);
       // Debug.Log(MidiPlayerTK.MidiPlayerGlobal.MPTK_GetPatchName(0,Starter.dizionario));

    }

    public void ChangeDelay(int increment)
    {
        DelayValue = DelayValue + increment*1000;
        if (DelayValue < 0) DelayValue = 0;
        if (DelayValue != 0)
            DelayLabel.SetText("" + DelayValue / 1000 + "s");
        else
            DelayLabel.SetText("" + DelayValue);
    }
}
