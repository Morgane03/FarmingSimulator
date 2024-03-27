using System.Collections;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public SeedData SeedData;
    private int growthStage = 0;
    private float startTime;
    public GameObject CurrentState;
    public bool IsHarvestable = false;

    [SerializeField]
    Inventory _inventory;

    public void PlantSeed()
    {
        if(SeedData.InPossession <= 0)
        {
            return;
        }
        else
        {
            _inventory.RemoveSeed(SeedData, SeedData.InPossession);
            CurrentState = Instantiate(SeedData.Seed, transform);
            startTime = Time.time;
            StartCoroutine(GrowPlant());
        }
    }

    private IEnumerator GrowPlant()
    {
        while (growthStage < 3)
        {
            float elapsedTime = Time.time - startTime;
            if (elapsedTime >= SeedData.GrowthTime)
            {
                // Change to next growth stage
                growthStage++;
                UpdatePlantPrefab();
                startTime = Time.time;
            }

            yield return null;
        }
    }

    private void UpdatePlantPrefab()
    {
        switch (growthStage)
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
