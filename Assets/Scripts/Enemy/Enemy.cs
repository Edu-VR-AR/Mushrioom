using UnityEngine;

[RequireComponent(typeof(WaypointMovement))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Coin _coin;

    public WaypointMovement EnemyWaypoint { get { return GetComponent<WaypointMovement>(); } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Rigidbody2D playerBody = player.PlayerBody2D;

            if (playerBody.velocity.y < 0)
            {
                playerBody.AddForce(Vector2.up * _jumpForce);
                Destroy(gameObject);

                Coin coin = Instantiate(_coin, transform.position, transform.rotation);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
