using TMPro;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField]
    private Inventory _playerInventory;

    [SerializeField]
    private PlayerMoney _playerMoney;

    [SerializeField]
    private SeedData _seedData;

    [SerializeField]
    private int _seedPossess;

    [SerializeField]
    private int _seedQuantity;

    public void Buy()
    {
        int _priceTotal = _seedData.PurchasePrice * _seedQuantity;

        if (_seedPossess >= _seedQuantity && _priceTotal <= _playerMoney.PlayerCurrentMoney)
        {
            _seedPossess -= _seedQuantity;
            _playerInventory.AddSeed(_seedData, _seedQuantity);
            _playerMoney.RemoveMoney(_priceTotal);
        }
        else
        {
            return;
        }
    }

    public void Sell()
    {
        if(_playerInventory.GetAmount(_seedData) >= _seedQuantity)
        {
            _seedPossess += _seedQuantity;
            _playerInventory.RemoveSeed(_seedData, _seedQuantity);
            _playerMoney.AddMoney(_seedData.SellPrice * _seedQuantity);
        }
        else
        {
            return;
        }
    }
}
