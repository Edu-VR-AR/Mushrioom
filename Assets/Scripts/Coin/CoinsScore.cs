using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class CoinsScore : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _scoreVisualize;
    private int _coinsScore = 0;

    private void OnEnable()
    {
        _player.CoinCatchedUp += CoinCatchedUp;
    }

    private void OnDisable()
    {
        _player.CoinCatchedUp -= CoinCatchedUp;
    }

    private void Start()
    {
        _scoreVisualize = GetComponent<TMP_Text>();
    }

    public void CoinCatchedUp()
    {
        _coinsScore++;
        _scoreVisualize.text = ("Coins: " + _coinsScore).ToString();
    }
}
