using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using UnityEngine;

public class SpawnOrClose : MonoBehaviour
{
    public GameObject inputCanva;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showCanvas()
    {
        inputCanva.SetActive(true);

    }
    public void hideCanvas()
    {
       inputCanva.SetActive(false);

    }

}
