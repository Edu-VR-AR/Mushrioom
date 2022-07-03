using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider && hit.distance < 0.41f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce);
            _jumpForce /= 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<CoinsScore>().CoinCatchedUp();
    }
}
