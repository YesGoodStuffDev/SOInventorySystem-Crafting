using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "InventorySystem/Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    public List<ItemObject> ingredients;
    public ItemObject outcome;
}
