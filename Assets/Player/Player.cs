using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction CoinCatchedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            CoinCatchedUp?.Invoke();
        }
    }
}
