using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed;
    private new Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (joystick != null && joystick.Direction != Vector2.zero)
        {
            Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            rigidbody.MovePosition(rigidbody.position + direction * (moveSpeed * Time.deltaTime));
            rigidbody.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
    }
}
