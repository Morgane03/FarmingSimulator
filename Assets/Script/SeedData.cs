using UnityEngine;

[CreateAssetMenu(fileName = "SeedData", menuName = "ScriptableObjects/SeedData", order = 1)]
public class SeedData : ScriptableObject
{
    public string seedName;
    public Sprite seedSprite;
    public int growthTime;


    public int purchasePrice;
    public int sellPrice;
}
