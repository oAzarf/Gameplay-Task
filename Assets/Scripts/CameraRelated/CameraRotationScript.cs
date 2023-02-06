using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraRotationScript : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 200.0f;
    [SerializeField]
    private float minX = -60.0f;
    [SerializeField]
    private float maxX = 60.0f;

    private float rotY = 0.0f;
    private float rotX = 0.0f;
    
    [SerializeField]
    private Slider slider;


    void Start()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float value)
    {
        sensitivity = Mathf.Round(value * 4.0f) / 4.0f;
        slider.value = sensitivity;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotY += InputSystem.GetDevice<Mouse>().delta.ReadValue().x * sensitivity * Time.deltaTime;
            rotX += InputSystem.GetDevice<Mouse>().delta.ReadValue().y * sensitivity * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, minX, maxX);
            transform.localEulerAngles = new Vector3(-rotX, rotY, 0.0f);
        }
        
    }

    
}