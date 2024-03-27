using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _moneyText;

    [SerializeField]
    private int PlayerBaseMoney;
    public int PlayerCurrentMoney;

    // Start is called before the first frame update
    void Start()
    {
        _moneyText.text = PlayerBaseMoney.ToString();
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
