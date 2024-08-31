using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public static Dictionary<int, int> dizionario = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            dizionario.Add(i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
