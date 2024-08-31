using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePreset : MonoBehaviour
{
    public GameObject g1;
    public GameObject ns1;

    public GameObject ns2;
    public GameObject g2;
    NoteSettings myNoteSetting;
    // Start is called before the first frame update
    void Start()
    {
        myNoteSetting = ns1.GetComponent<NoteSettings>();
        myNoteSetting.KeyValue = 70;

        myNoteSetting = ns2.GetComponent<NoteSettings>();
        myNoteSetting.KeyValue = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
