using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _coin;

    private void Start()
    {
        _coin = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider && hit.distance < 0.41f)
        {
            _coin.AddForce(Vector2.up * _jumpForce);
            _jumpForce /= 2;
        }
    }
}
