using UnityEngine;

public class CharactgerMovement : MonoBehaviour
{
    public SimpleControls _simpleControl;
    public Vector2 _position;
    public float _yaw; 
    public float speed = 4;
    public float rotationSensitivity = 5f;

    private Animator anim;

    void Awake()
    {
        _simpleControl = new SimpleControls();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _simpleControl.Enable();
    }

    private void OnDisable()
    {
        _simpleControl.Disable();
    }

    void Update()
    {
        GetInput();
        move();
        rotate();
    }

    public void GetInput()
    {
        _position = _simpleControl.gameplay.move.ReadValue<Vector2>();

        Vector2 lookDelta = _simpleControl.gameplay.look.ReadValue<Vector2>();
        _yaw += lookDelta.x * rotationSensitivity; 
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
    }
}
