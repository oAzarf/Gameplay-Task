using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseScript : MonoBehaviour
{
    

    float delay;
    float delayTime=0.5f;

    [SerializeField]
    private Material outlinemat;


    ClickablePropScript hoovered;
    ClickablePropScript lastHoovered;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay!=0)
        {
            if (delay < delayTime)
            {
                delay += Time.deltaTime;
            }
            else
            {
                delay = 0;
            }
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
           
            hoovered = hit.transform.GetComponent<ClickablePropScript>();
            if (hoovered)
            {
                if (lastHoovered==null)
                {
                    lastHoovered = hoovered;
                    hoovered.HighlightMe(outlinemat);
                }
                

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    GameContextMenuScript.instace.ReadProp(hoovered);
                    delay += Time.deltaTime;
                }
            }
            else
            {
                if (lastHoovered)
                {

                    lastHoovered.HighlightMe(outlinemat);
                    lastHoovered = null;
                }
            }
          
            
            

        }
       
        
    }

    
}
