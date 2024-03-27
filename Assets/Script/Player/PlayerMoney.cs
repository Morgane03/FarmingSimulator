using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _moneyText;

    [SerializeField]
    private int PlayerBaseMoney;
    private int _playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        _moneyText.text = PlayerBaseMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
