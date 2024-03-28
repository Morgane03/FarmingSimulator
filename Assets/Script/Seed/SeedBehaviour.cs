using System.Collections;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public GameObject CurrentState;
    public SeedData SeedData;
    public int GrowthStage = 0;
    public bool IsHarvestable = false;

    private float startTime;

    [SerializeField]
    private Inventory _inventory;

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
            startTime = Time.time;
            StartCoroutine(GrowPlant());
        }
    }

    private IEnumerator GrowPlant()
    {
        while (GrowthStage < 3)
        {
            float elapsedTime = Time.time - startTime;
            if (elapsedTime >= SeedData.GrowthTime)
            {
                // Change to next growth stage
                GrowthStage++;
                UpdatePlantPrefab();
                startTime = Time.time;
            }

            yield return null;
        }
    }

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
                break;
        }
    }
}
