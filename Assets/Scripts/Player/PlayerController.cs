using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerInputControl inputControl;
    private Vector2 inputDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);

        var faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        else if (inputDirection.x < 0)
            faceDir = -1;
        // flip character
        transform.localScale = new Vector3(faceDir, 1, 1);
    }
}