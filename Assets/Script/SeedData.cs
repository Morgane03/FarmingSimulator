using UnityEngine;

[CreateAssetMenu(fileName = "SeedData", menuName = "ScriptableObjects/SeedData", order = 1)]
public class SeedData : ScriptableObject
{
    public string SeedName;
    public Sprite SeedSprite;
    public int GrowthTime;

    public int PurchasePrice;
    public int SellPrice;
}
