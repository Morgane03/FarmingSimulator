using UnityEngine;

public class Field : MonoBehaviour
{
    private bool _isOcupied;

    [SerializeField]
    private GameObject _seedSelect;

    // Start is called before the first frame update
    void Start()
    {
        _isOcupied = false;
    }

    public void Selecte(bool toggle)
    {
        _seedSelect.SetActive(toggle);
    }

    private void PlanteSeed()
    {
        if (!_isOcupied)
        {
            _isOcupied = true;

            // Plant seed
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
