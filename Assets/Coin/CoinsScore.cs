using UnityEngine;
using TMPro;

public class CoinsScore : MonoBehaviour
{
    private TMP_Text _scoreVisualize;
    private int _coinsScore = 0;

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
