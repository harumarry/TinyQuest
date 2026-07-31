using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}
