using UnityEngine;

public class Field : MonoBehaviour
{
    public bool _isOcupied = false;

    [SerializeField]
    private GameObject _seedSelect;

    [SerializeField]
    private GameObject _cropPrefab;

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
        if(!_isOcupied)
        {
            _isOcupied = true;
            _seedBehaviour.PlantSeed();
        }
    }

    private void Harvest()
    {
        if (_isOcupied)
        {
            _isOcupied = false;

            // Harvest
        }
    }
}
