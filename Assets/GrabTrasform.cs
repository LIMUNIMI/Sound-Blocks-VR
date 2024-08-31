using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrasform :OneGrabFreeTransformer,ITransformer
{
    GameObject previusObject;
    public void BeginTransform()
    {
        base.BeginTransform();
        //setta parent precedente
        if (this.transform.parent == null) return;
        previusObject = this.transform.parent.gameObject;
        Debug.Log(previusObject.name);
        this.transform.SetParent(null, true);
       // throw new System.NotImplementedException();
    }

    public void EndTransform()
    {
        base.EndTransform();
        // riassegna parent precedente
        if (this.transform.parent == null) 
        this.transform.SetParent(previusObject.transform, true);
      //  throw new System.NotImplementedException();
    }

    public void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
       // throw new System.NotImplementedException();
    }

    public void UpdateTransform()
    {
        base.UpdateTransform();
       // throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
