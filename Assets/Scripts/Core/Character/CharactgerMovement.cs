using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactgerMovement : MonoBehaviour
{

    private InputSystem_Actions InputActions;
    [Header("Movement Settings")]
    [SerializeField] float speed = 1;
    Vector2 MoveInput;
    CharacterController _characterController;
    public SimpleControls _simpleControl;
    public Vector2 _position;
    float _yaw;
    float _pitch;
    public float rotationSensitivity = 0.5f;

    private Animator anim;
    CharacterController controller;
    void Awake()
    {
        InputActions = new InputSystem_Actions();
        //_simpleControl = new SimpleControls();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //_simpleControl.Enable();
        InputActions.Player.Enable();

        //klavye girdileri için hareket
        InputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        InputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        //_simpleControl.Disable();
        InputActions.Player.Disable();

        //klavye girdileri için hareket
        InputActions.Player.Move.performed -= ctx => MoveInput = ctx.ReadValue<Vector2>();
        InputActions.Player.Move.canceled -= ctx => MoveInput = Vector2.zero;
    }

    void Update()
    {
        //hareket kýsmý
        Vector3 move= transform.right*MoveInput.x + transform.forward*MoveInput.y;
        controller.Move(move*Time.deltaTime*speed);
    }

    /*public void GetInput()
    {
        _position = _simpleControl.gameplay.move.ReadValue<Vector2>();

        Vector2 lookDelta = _simpleControl.gameplay.look.ReadValue<Vector2>();
        _yaw += lookDelta.x * rotationSensitivity;
        _pitch += Math.Clamp(lookDelta.y * rotationSensitivity, -80, 80);
    }

    public void move()
    {
        Vector3 movement = new Vector3(_position.x, 0, _position.y);
        movement = Quaternion.Euler(0, _yaw, 0) * movement; 
        transform.position += movement * speed * Time.deltaTime;

        anim.SetBool("IsRun", _position.magnitude > 0.01f);
    }

    public void rotate()
    {
        transform.rotation = Quaternion.Euler(0f, _yaw, 0f);
    }*/
}
