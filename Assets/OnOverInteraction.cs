using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using UnityEngine;
public class OnOverInteraction : MonoBehaviour
{
    private MidiStreamPlayer midiStreamPlayer;   // Initialized at Start() or could be set in the Inspector
    private Renderer renderer;
    Color prevColor;
    private bool isTrigger = false; 

    public Manager myManager;
    public GameObject inputManagerGO;

    NoteSettings myNoteSetting;
    public GameObject inputNoteSettingsGO;


    // Start is called before the first frame update
    void Start()
    {
       // myManager = inputManagerGO.GetComponent<Manager>();
        myNoteSetting = inputNoteSettingsGO.GetComponent<NoteSettings>();
        midiStreamPlayer = FindObjectOfType<MidiStreamPlayer>();
        myManager.Starter(midiStreamPlayer);
        renderer = GetComponent<Renderer>();
        prevColor = renderer.material.color;

    }
    private void Update()
    {

    } 
    
    public void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.layer == 3 && this.gameObject != null && this.gameObject.activeSelf)
        {
            myManager.NoteOffManager(midiStreamPlayer, myNoteSetting.KeyValue, myNoteSetting.ChannelValue);
            this.gameObject.SetActive(false);// Destroy(this.gameObject);
            return;
        }
        if (other.gameObject.layer != 6 || (isTrigger)) return;
         myManager.NoteOnManager(midiStreamPlayer, myNoteSetting.KeyValue, myNoteSetting.ChannelValue,
         -1, myNoteSetting.VelocityValue, myNoteSetting.DelayValue);
        renderer.material.color = prevColor.gamma;
      //  myManager.ChangePreset(midiStreamPlayer, Manager.dizionario[myNoteSetting.ChannelValue], myNoteSetting.ChannelValue);
        isTrigger = true;

    }
    
    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer != 6 || !(isTrigger)) return;
        myManager.NoteOffManager(midiStreamPlayer,myNoteSetting.KeyValue,myNoteSetting.ChannelValue);
        renderer.material.color = prevColor;
        isTrigger = false;
    }

    void OnDestroy() 
    {
        myManager.NoteOffManager(midiStreamPlayer, myNoteSetting.KeyValue, myNoteSetting.ChannelValue);
    }


}
