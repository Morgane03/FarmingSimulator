using TMPro;
using UnityEngine;

/// <summary>
/// Manage the money of the player
/// </summary>
public class PlayerMoney : MonoBehaviour
{
    public int PlayerCurrentMoney;

    [SerializeField]
    private TextMeshProUGUI _moneyText;

    [SerializeField]
    private int _playerBaseMoney;

    // Start is called before the first frame update
    private void Start()
    {
        _moneyText.text = _playerBaseMoney.ToString();
        PlayerCurrentMoney = _playerBaseMoney;
    }

    /// <summary>
    /// Add money to the player and update the UI
    /// </summary>
    /// <param name="money"></param>
    public void AddMoney(int money)
    {
        PlayerCurrentMoney += money;
        _moneyText.text = PlayerCurrentMoney.ToString();
    }

    /// <summary>
    /// Remove money to the player and update the UI
    /// </summary>
    /// <param name="money"></param>
    public void RemoveMoney(int money)
    {
        PlayerCurrentMoney -= money;
        _moneyText.text = PlayerCurrentMoney.ToString();
    }
}
