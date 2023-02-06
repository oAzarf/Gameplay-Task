using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : ClickablePropScript
{
    [SerializeField]
    Transform pointLight;
    // Start is called before the first frame update
    void Awake()
    {
        imProp = Props.Picture;
    }

    public void ToggleLight()
    {
        pointLight.gameObject.SetActive(!pointLight.gameObject.activeInHierarchy);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
