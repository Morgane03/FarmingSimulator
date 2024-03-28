using TMPro;
using UnityEngine;

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

    public void AddMoney(int money)
    {
        PlayerCurrentMoney += money;
        _moneyText.text = PlayerCurrentMoney.ToString();
    }

    public void RemoveMoney(int money)
    {
        PlayerCurrentMoney -= money;
        _moneyText.text = PlayerCurrentMoney.ToString();
    }
}
