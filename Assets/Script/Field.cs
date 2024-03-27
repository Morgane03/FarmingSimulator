using UnityEngine;

public class Field : MonoBehaviour
{
    public bool IsOcupied = false;
    public bool CanPlant = false;

    [SerializeField]
    private GameObject _seedSelect;

    [SerializeField]
    private SeedBehaviour _seedBehaviour;

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
        if (!IsOcupied && CanPlant)
        {
            IsOcupied = true;
            _seedBehaviour.PlantSeed();
        }
    }

    private void Harvest()
    {
        if (IsOcupied && _seedBehaviour.IsHarvestable)
        {
            IsOcupied = false;

            // Harvest
        }
    }
}
