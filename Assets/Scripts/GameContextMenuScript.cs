using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContextMenuScript : MonoBehaviour
{
    public static GameContextMenuScript instace;

    [SerializeField]
    private Image contextMenusBackGround;
    [SerializeField]
    List<Transform> contextMenusItems;
    [SerializeField]
    private Slider sliderScale;
    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button toogleButton;
    [SerializeField]
    private Button closeContextMenuButton;

    [SerializeField]
    private ClickablePropScript gameObjectToInteract;
    [SerializeField]
    Image disableAfterStart;

    float timeToDisable = 3f;
    float timeCount ;

    

    private void Awake()
    {
        if (instace==null)
        {
            instace = this;
        }
        else
        {
            Destroy(this);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sliderScale.onValueChanged.AddListener(SliderMoved);
        rightButton.onClick.AddListener(RotateButtonRightPressed);
        leftButton.onClick.AddListener(RotateButtonLeftPressed);
        toogleButton.onClick.AddListener(ButtonToggled);
        closeContextMenuButton.onClick.AddListener(CloseGameContexMenu);
        disableAfterStart.CrossFadeAlpha(timeCount / timeToDisable, timeToDisable, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount>timeToDisable*1.5)
        {
            disableAfterStart.gameObject.SetActive(false);
            return;
        }
        timeCount += Time.deltaTime;
    }

    public void ReadProp(ClickablePropScript theProp)
    {
        ClearGameContextMenu();
        closeContextMenuButton.transform.gameObject.SetActive(true);
        int indexInList = (int)theProp.imProp;
        Transform theObject = contextMenusItems[indexInList].transform; //the contextMenu To be seen On Screen
        theObject.gameObject.SetActive(true);
        contextMenusBackGround.enabled = true;
        gameObjectToInteract = theProp;

        switch (theProp.imProp)
        {
            case Props.Table:
                TableScript table = (TableScript)theProp;
                float newScale = theProp.transform.localScale.x / table.originalScale; //get the value to set the slider at
                sliderScale.value = newScale - 0.5f;
                break;
        }

    }

    public void ClearGameContextMenu()
    {
        foreach (var item in contextMenusItems)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void SliderMoved(float value)
    {
        if (gameObjectToInteract.imProp!=Props.Table)
        {
            return;
        }
        float newScale = Mathf.Lerp(0.5f, 1.5f, value);
        gameObjectToInteract.transform.localScale = newScale*100*Vector3.one;
    }
    public void ButtonToggled()
    {
        PictureScript picture = (PictureScript)gameObjectToInteract;
        picture.ToggleLight();
    }
    public void RotateButtonRightPressed()
    {
        ChairScript chair = (ChairScript)gameObjectToInteract;
        chair.Rotate(-45);
    }
    public void RotateButtonLeftPressed()
    {
        ChairScript chair = (ChairScript)gameObjectToInteract;
        chair.Rotate(45);

    }

    public void CloseGameContexMenu()
    {

        ClearGameContextMenu();
        closeContextMenuButton.transform.gameObject.SetActive(false);
        contextMenusBackGround.enabled = false;
    }




}
