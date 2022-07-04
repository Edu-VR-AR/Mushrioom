using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public event UnityAction CoinCatchedUp;

    public Rigidbody2D PlayerBody2D {get { return GetComponent<Rigidbody2D>(); } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            CoinCatchedUp?.Invoke();
        }
    }
}
