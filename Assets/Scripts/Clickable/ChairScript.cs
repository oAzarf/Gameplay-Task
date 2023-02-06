using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : ClickablePropScript
{

    // Start is called before the first frame update
    void Awake()
    {
        imProp = Props.Chair;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(float thisMuch)
    {
        transform.eulerAngles += Vector3.up * thisMuch;
    }
}
