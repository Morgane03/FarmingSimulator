using System.Collections;
using UnityEngine;

public class Field : MonoBehaviour
{
    public bool IsOcupied = false;
    public bool IsChoose = false;

    [SerializeField]
    private GameObject _seedSelect;

    [SerializeField]
    private SeedBehaviour _seedBehaviour;

    [SerializeField]
    private Inventory _inventory;

    // Start is called before the first frame update
    private void Start()
    {
        Selecte(false);
    }

    public void Selecte(bool toggle)
    {
        _seedSelect.SetActive(toggle);
    }

    public void PlanteSeed()
    {
        if (!IsOcupied && IsChoose)
        {
            Debug.Log("Planting seed...");
            IsOcupied = true;
            _seedBehaviour.PlantSeed();
        }
    }

    public void Harvest()
    {
        if (IsOcupied && _seedBehaviour.IsHarvestable)
        {
            Debug.Log("Harvesting seed...");
            IsOcupied = false;
            _inventory.AddSeed(_seedBehaviour.SeedData, _seedBehaviour.SeedData.Amount);
            Destroy(_seedBehaviour.CurrentState);

            _seedBehaviour.IsHarvestable = false;
            _seedBehaviour.GrowthStage = 0;
        }
    }
}
