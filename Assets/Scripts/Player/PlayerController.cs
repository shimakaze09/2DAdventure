using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private PlayerInputControl _inputControl;
    private Vector2 _inputDirection;
    private PhysicsCheck _physicsCheck;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _physicsCheck = GetComponent<PhysicsCheck>();
        _inputControl = new PlayerInputControl();

        _inputControl.Gameplay.Jump.started += Jump;
    }

    private void Update()
    {
        _inputDirection = _inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _inputControl.Enable();
    }

    private void OnDisable()
    {
        _inputControl.Disable();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_inputDirection.x * speed * Time.deltaTime, _rb.velocity.y);

        var faceDir = (int)transform.localScale.x;
        if (_inputDirection.x > 0)
            faceDir = 1;
        else if (_inputDirection.x < 0)
            faceDir = -1;
        // flip character
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (_physicsCheck.IsGround)
            _rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}