using System.Collections.Generic;
using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    [SerializeField]
    private SeedData _seedData;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private List<SeedBehaviour> _seedBehaviourList;

    public void ChoosePlantSeed()
    {
        if (_inventory.GetAmount(_seedData) > 0)
        {
            foreach (SeedBehaviour seedBehaviour in _seedBehaviourList)
            {
                seedBehaviour.SeedData = _seedData;
            }
        }
    }
}
