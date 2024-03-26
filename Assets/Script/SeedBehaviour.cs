using System.Collections;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public SeedData seedData;
    private int growthStage = 0;
    private float startTime;
    private GameObject _currentState;

    public void PlantSeed()
    {
        _currentState = Instantiate(seedData.Seed, transform);
        startTime = Time.time;
        StartCoroutine(GrowPlant());
    }

    private IEnumerator GrowPlant()
    {
        while (growthStage < 3)
        {
            float elapsedTime = Time.time - startTime;
            if (elapsedTime >= seedData.GrowthTime)
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
                Destroy(_currentState);
                _currentState = Instantiate(seedData.Seedling, transform.position, Quaternion.identity);
                break;
            case 2:
                Destroy(_currentState);
                _currentState = Instantiate(seedData.Harvestable, transform.position, Quaternion.identity);
                break;
        }
    }
}
