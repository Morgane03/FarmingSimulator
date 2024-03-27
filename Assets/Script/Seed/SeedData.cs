using UnityEngine;

/// <summary>
/// Contains the data of a seed
/// </summary>
[CreateAssetMenu(fileName = "SeedData", menuName = "ScriptableObjects/SeedData", order = 1)]
public class SeedData : ScriptableObject
{
    public string SeedName;

    public GameObject Seed;
    public GameObject Seedling;
    public GameObject Harvestable;

    public int GrowthTime;

    public int PurchasePrice;
    public int SellPrice;

    public int CanPlant;
    public int Amount;
}
