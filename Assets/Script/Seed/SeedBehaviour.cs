﻿using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Manage the seed behaviour and growth
/// </summary>
public class SeedBehaviour : MonoBehaviour
{
    public GameObject CurrentState;

    public int GrowthStage = 0;
    public bool IsHarvestable = false;

    private float _startTime;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private TextMeshProUGUI _warningText;

    public SeedData SeedData { get; set; }

    /// <summary>
    /// Plant the seed in the field
    /// </summary>
    public void PlantSeed()
    {
        if (_inventory.GetAmount(SeedData) <= 0)
        {
            return;
        }
        else
        {
            _inventory.RemoveSeed(SeedData, 1);
            CurrentState = Instantiate(SeedData.Seed, transform);
            _startTime = Time.time;
            StartCoroutine(GrowPlant());
        }
    }

    /// <summary>
    /// Grow the plant to the next stage
    /// </summary>
    /// <returns></returns>
    private IEnumerator GrowPlant()
    {
        while (GrowthStage < 3)
        {
            float elapsedTime = Time.time - _startTime;
            if (elapsedTime >= SeedData.GrowthTime)
            {
                Debug.Log(SeedData.name + CurrentState);
                GrowthStage++;
                UpdatePlantPrefab();
                _startTime = Time.time;
            }

            yield return null;
        }
    }

    /// <summary>
    /// Update the plant prefab based on the growth stage
    /// </summary>
    private void UpdatePlantPrefab()
    {
        switch (GrowthStage)
        {
            case 1:
                Destroy(CurrentState);
                CurrentState = Instantiate(SeedData.Seedling, transform.position, Quaternion.identity);
                break;
            case 2:
                Destroy(CurrentState);
                CurrentState = Instantiate(SeedData.Harvestable, transform.position, Quaternion.identity);
                IsHarvestable = true;
                StartCoroutine(PlantIsHarvestText());
                break;
        }
    }

    private IEnumerator PlantIsHarvestText()
    {
        _warningText.text = "The plant" + SeedData.name + "is ready to harvest";
        yield return new WaitForSeconds(2);
    }
}
