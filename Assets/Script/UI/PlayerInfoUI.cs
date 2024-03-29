using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Update the player UI
/// </summary>
public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    private Merchant _merchant;

    [SerializeField]
    private PlayerMoney _money;

    [SerializeField]
    private List<SeedBehaviour> _seedBehaviours = new();

    // Start is called before the first frame update
    void Start()
    {
        _merchant.UpdateWarningForMerchant += UpdateMerchantText;
        _money.OnPlayerMoneyChange += UpdatePlayerMoneyText;

        for (int i = 0; i < _seedBehaviours.Count; i++)
        {
            _seedBehaviours[i].UpdateHarvestText += UpdateHarvestTestInfo;
        }
    }

    private void UpdateMerchantText(TextMeshProUGUI _text)
    {
        StartCoroutine(MerchantText(_text));
    }

    private void UpdatePlayerMoneyText(TextMeshProUGUI _text)
    {
        _text.text = _money.PlayerCurrentMoney.ToString();
    }

    private void UpdateHarvestTestInfo(TextMeshProUGUI _text, SeedBehaviour seedBehaviour)
    {
        StartCoroutine(PlantIsHarvestText(_text, seedBehaviour));
    }

    private IEnumerator MerchantText(TextMeshProUGUI _text)
    {
        _text.text = "You can't add more quantity";
        yield return (2);
        _text.text = "";
    }

    private IEnumerator PlantIsHarvestText(TextMeshProUGUI _text, SeedBehaviour seedBehaviour)
    {
        _text.text = "The plant" + seedBehaviour.SeedData.name + "is ready to harvest";
        yield return new WaitForSeconds(2);
        _text.text = "";
    }
}
