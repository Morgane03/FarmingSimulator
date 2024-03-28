using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the inventory of the player
/// </summary>
public class Inventory : MonoBehaviour
{
    private Dictionary<SeedData, int> _seedInventory = new Dictionary<SeedData, int>();

    public void AddSeed(SeedData seed, int amount)
    {
        if (_seedInventory.ContainsKey(seed))
        {
            _seedInventory[seed] += amount;
        }
        else
        {
            _seedInventory.Add(seed, amount);
        }
    }

    public void RemoveSeed(SeedData seed, int amount)
    {
        if (_seedInventory.ContainsKey(seed))
        {
            _seedInventory[seed] -= amount;

            if (_seedInventory[seed] <= 0)
            {
                _seedInventory.Remove(seed);
            }
        }
    }

    public int GetAmount(SeedData seed)
    {
        if (_seedInventory.ContainsKey(seed))
        {
            return _seedInventory[seed];
        }

        return 0;
    }
}
