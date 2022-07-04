using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _coin;
    private float _forceDecimator = 2.0f;
    private float _radius;
    

    private void Start()
    {
        _coin = GetComponent<Rigidbody2D>();
        _radius = GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider && hit.distance < _radius)
        {
            _coin.AddForce(Vector2.up * _jumpForce);
            _jumpForce /= _forceDecimator;
        }
    }
}
