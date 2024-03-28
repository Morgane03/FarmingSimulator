﻿using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<SeedData, int> _seedInventory = new Dictionary<SeedData, int>();

    public void AddSeed(SeedData seed, int amount)
    {
        Debug.Log($"Avant ajout : " + seed.name + GetAmount(seed));

        if (_seedInventory.ContainsKey(seed))
        {
            _seedInventory[seed] += amount;
        }
        else
        {
            _seedInventory.Add(seed, amount);
        }

        Debug.Log($"Après ajout : " + seed.name + GetAmount(seed));

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
