﻿using UnityEngine;

public class Field : MonoBehaviour
{
    public bool IsOcupied = false;
    public bool IsChoose = false;

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
        if (!IsOcupied && IsChoose)
        {
            IsOcupied = true;
            _seedBehaviour.PlantSeed();
        }
    }

    public void Harvest()
    {
        if (IsOcupied && _seedBehaviour.IsHarvestable)
        {
            IsOcupied = false;
            //Inventory.AddSeed(_seedBehaviour.seedData, _seedBehaviour.seedData.Amount);
            Destroy(_seedBehaviour.CurrentState);
        }
        _seedBehaviour.IsHarvestable = false;
    }
}
