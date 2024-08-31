using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using UnityEngine;


public class ToggleInteraction : MonoBehaviour
{
    public MidiStreamPlayer midiStreamPlayer;   // Initialized at Start() or could be set in the Inspector
    private MPTKEvent mptkEvent;
    [Range(0, 127)]
    public int pitch;
    private Renderer renderer;
    Color prevColor;

    // Preset 
    [Range(0, 127)]
    public int Preset;
    Manager myManager;
    public GameObject inputManagerGO;
    private bool active = false;



    // Start is called before the first frame update
    void Start()
    {
        myManager = inputManagerGO.GetComponent<Manager>();
        myManager.Starter(midiStreamPlayer);
        //pitch = NoteSettings.KeyValue;
        renderer = GetComponent<Renderer>();
        prevColor = renderer.material.color;
    }
    private void Update()
    {

    }    

    public void OnTriggerEnter (Collider collision)
    {
        activateManager();

        Debug.Log(collision.gameObject.name);
      
    }
    
private void activateManager()
{
        if(active){
           // myManager.NoteOffManager(midiStreamPlayer);
            active=false;
            renderer.material.color = prevColor;
           
        }
        else
        {
            myManager.NoteOnManager(midiStreamPlayer, pitch, 1);
            myManager.ChangePreset(midiStreamPlayer,Preset, 1);
            renderer.material.color = prevColor.gamma;
            active=true;
           
        }
        Debug.Log(active);
}

    /*
    public void OnTriggerExit(Collider other)
    {
        NoteOffManager();


    }
    */

}
