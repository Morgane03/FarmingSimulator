﻿using UnityEngine;

/// <summary>
/// Allows to recolor and plant 
/// </summary>
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

    /// <summary>
    /// Allows to select the plot
    /// </summary>
    /// <param name="toggle"></param>
    public void Selecte(bool toggle)
    {
        _seedSelect.SetActive(toggle);
    }

    /// <summary>
    /// Allows to plant a seed if the plot is not occupied
    /// </summary>
    public void PlanteSeed()
    {
        if (!IsOcupied && IsChoose)
        {
            IsOcupied = true;
            _seedBehaviour.PlantSeed();
        }
    }

    /// <summary>
    /// Allows to harvest the seed if the plot is occupied
    /// </summary>
    public void Harvest()
    {
        if (IsOcupied && _seedBehaviour.IsHarvestable)
        {
            IsOcupied = false;
            _inventory.AddSeed(_seedBehaviour.SeedData, _seedBehaviour.SeedData.Amount);
            Destroy(_seedBehaviour.CurrentState);

            _seedBehaviour.IsHarvestable = false;
            _seedBehaviour.GrowthStage = 0;
        }
    }
}
