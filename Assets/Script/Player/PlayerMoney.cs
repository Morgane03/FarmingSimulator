using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Manage the money of the player
/// </summary>
public class PlayerMoney : MonoBehaviour
{
    public event Action<TextMeshProUGUI> OnPlayerMoneyChange;

    [SerializeField]
    private TextMeshProUGUI _moneyText;

    [SerializeField]
    private int _playerBaseMoney;

    public int PlayerCurrentMoney { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        PlayerCurrentMoney = _playerBaseMoney;
        OnPlayerMoneyChange?.Invoke(_moneyText);
    }

    /// <summary>
    /// Add money to the player and update the UI
    /// </summary>
    /// <param name="money"></param>
    public void AddMoney(int money)
    {
        PlayerCurrentMoney += money;
        OnPlayerMoneyChange?.Invoke(_moneyText);
    }

    /// <summary>
    /// Remove money to the player and update the UI
    /// </summary>
    /// <param name="money"></param>
    public void RemoveMoney(int money)
    {
        PlayerCurrentMoney -= money;
        OnPlayerMoneyChange?.Invoke(_moneyText);
    }
}
