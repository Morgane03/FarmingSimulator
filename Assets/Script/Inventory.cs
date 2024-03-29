using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the inventory of the player
/// </summary>
public class Inventory : MonoBehaviour
{
    private Dictionary<SeedData, int> _seedInventory = new Dictionary<SeedData, int>();

    /// <summary>
    /// Add seed/plant to the inventory
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="amount"></param>
    public void AddSeed(SeedData seed, int amount)
    {
        Debug.Log("Add seed: " + seed.SeedName + " amount: " + amount);
        if (_seedInventory.ContainsKey(seed))
        {
            _seedInventory[seed] += amount;
        }
        else
        {
            _seedInventory.Add(seed, amount);
        }
    }

    /// <summary>
    /// Remove seed/plant from the inventory
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="amount"></param>
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

    /// <summary>
    /// Get the amount of seed/plant in the inventory
    /// </summary>
    /// <param name="seed"></param>
    /// <returns></returns>
    public int GetAmount(SeedData seed)
    {
        if (_seedInventory.ContainsKey(seed))
        {
            return _seedInventory[seed];
        }

        return 0;
    }
}
