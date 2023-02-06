using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterMovingScript : MonoBehaviour
{

    [SerializeField]
    public  PlayerInput playerInput;
    [SerializeField]
    private float speed = 6.0f;

    private float upDown;
    private Vector2 inputXYAxis;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.BasicPlayer.Move.performed += OnMovementPerformed;
        playerInput.BasicPlayer.Move.canceled += OnMovementCancelled;

        playerInput.BasicPlayer.UpAndDown.performed += OnMovementPullUpOrDown;
        playerInput.BasicPlayer.UpAndDown.performed += miguel => { Debug.Log(miguel); };
        playerInput.BasicPlayer.UpAndDown.canceled += miguel => { Debug.Log(miguel); };
        playerInput.BasicPlayer.UpAndDown.canceled += OnMovementCancelledUpDown;
    }
    private void OnDisable()
    {
        playerInput.Disable();

        playerInput.BasicPlayer.Move.performed -= OnMovementPerformed;
        playerInput.BasicPlayer.Move.canceled -= OnMovementCancelled;
        playerInput.BasicPlayer.UpAndDown.performed -= OnMovementPullUpOrDown;
        playerInput.BasicPlayer.UpAndDown.canceled -= OnMovementCancelledUpDown;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        slider.onValueChanged.AddListener(OnValueChanged);
    }
   
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        inputXYAxis = value.ReadValue<Vector2>();  
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        inputXYAxis = Vector2.zero;
    }
    private void OnMovementPullUpOrDown(InputAction.CallbackContext value)
    {
        upDown = value.ReadValue<float>();
    }
    private void OnMovementCancelledUpDown(InputAction.CallbackContext value)
    {
        upDown = 0;
    }


    private void MovePlayer()
    {
        moveDirection = cameraTransform.forward* inputXYAxis.y  + 
                        cameraTransform.up*upDown               + 
                        cameraTransform.right *inputXYAxis.x ;

        controller.Move(moveDirection.normalized * speed * Time.deltaTime);
    }
    void OnValueChanged(float value)
    {
        speed = Mathf.Round(value * 4.0f) / 4.0f;
        slider.value = speed;
    }

    void Update()
    {

        //float upDown=0;
        //if (Input.GetKey(KeyCode.Q)) upDown = -1;
        //else if(Input.GetKey(KeyCode.E)) upDown = 1;

        //moveDirection = cameraTransform.forward * Input.GetAxisRaw("Vertical") + cameraTransform.up*upDown + cameraTransform.right * Input.GetAxisRaw("Horizontal");
        //controller.Move(moveDirection.normalized* speed * Time.deltaTime);

        MovePlayer();
    }

    
}