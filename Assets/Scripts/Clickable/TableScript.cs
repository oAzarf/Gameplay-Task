using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : ClickablePropScript
{
    public float originalScale;


  

    // Start is called before the first frame update
    void Awake()
    {
        imProp = Props.Table;
        originalScale = transform.localScale.x;
        print(originalScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
