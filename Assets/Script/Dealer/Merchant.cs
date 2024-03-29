using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Manage the merchant
/// </summary>
public class Merchant : MonoBehaviour
{
    [SerializeField]
    private Inventory _playerInventory;

    [SerializeField]
    private PlayerMoney _playerMoney;

    [SerializeField]
    private int _seedPossess;

    [SerializeField]
    private int _seedQuantity;

    [SerializeField]
    private TextMeshProUGUI _warningText;

    /// <summary>
    /// Player buys selected seeds/plants from the merchant
    /// </summary>
    /// <param name="seedData"></param>
    public void Buy(SeedData seedData)
    {
        int priceTotal = seedData.PurchasePrice * _seedQuantity;

        if (_seedPossess >= _seedQuantity && priceTotal <= _playerMoney.PlayerCurrentMoney)
        {
            _seedPossess -= _seedQuantity;
            _playerInventory.AddSeed(seedData, _seedQuantity);
            _playerMoney.RemoveMoney(priceTotal);
        }
        else
        {
            StartCoroutine(NotAddQuantity());
            return;
        }
    }

    /// <summary>
    /// Player sells selected seeds/plants to the merchant
    /// </summary>
    /// <param name="seedData"></param>
    public void Sell(SeedData seedData)
    {
        if (_playerInventory.GetAmount(seedData) >= _seedQuantity)
        {
            _seedPossess += _seedQuantity;
            _playerInventory.RemoveSeed(seedData, _seedQuantity);
            _playerMoney.AddMoney(seedData.SellPrice * _seedQuantity);
        }
        else
        {
            StartCoroutine(NotAddQuantity());
            return;
        }
    }

    /// <summary>
    /// Text tells the player that they cannot buy or sell
    /// </summary>
    /// <returns></returns>
    private IEnumerator NotAddQuantity()
    {
        _warningText.text = "You can't add more quantity";
        yield return new WaitForSeconds(3);
        _warningText.text = "";
    }
}
