using UnityEngine;

/// <summary>
/// Select the seed to plant
/// </summary>
public class SeedSelection : MonoBehaviour
{
    [SerializeField]
    private SeedData _seedData;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private PlayerChooseField _playerChooseField;

    /// <summary>
    /// Choose the seed to plant
    /// </summary>
    public void ChoosePlantSeed()
    {
        if (_inventory.GetAmount(_seedData) > 0)
        {
            _playerChooseField.SeedBehaviour.SeedData = _seedData;
        }
    }
}
