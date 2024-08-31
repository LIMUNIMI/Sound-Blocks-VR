using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGO : MonoBehaviour
{
    public GameObject OnHoverGO;
    private float offsetx=0;
    private float offsety;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        

    }


   public void Spawn()
   {
        GameObject newObj;
        offsetx = Random.Range(-0.1f, 0.2f);
        offsety = Random.Range(-0.1f, 0.2f);
        float x = (float)OnHoverGO.transform.position.x + offsetx;
        float y = (float)OnHoverGO.transform.position.y;
        float z = (float)OnHoverGO.transform.position.z;
        newObj = Instantiate(OnHoverGO);
        newObj.transform.position = new Vector3(x, y, z);

        renderer = newObj.GetComponent<Renderer>();

        // Pick a random, saturated and not-too-dark color
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        renderer.material.color = color;
   }
}
