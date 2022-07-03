using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Coin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce);
                Destroy(gameObject);

                GameObject coin = Instantiate(_coin.gameObject, transform.position, transform.rotation);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
