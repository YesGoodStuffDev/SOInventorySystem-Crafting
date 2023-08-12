using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "InventorySystem/Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    //Add multiple items in the list if the crafting materials requires multiple of the same item
    public List<ItemObject> ingredients;
    public ItemObject outcome;
}
