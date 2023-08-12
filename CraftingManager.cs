using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingManager : MonoBehaviour
{
    public InventoryObject playerInventory;

    //Call this function with a recipe when you want to craft an item
    public void CraftItem(Recipe recipe)
    {
        List<Item> removedItems = new List<Item>();
        int counter = 0;
        //loop through all items in the recipe
        foreach (ItemObject requiredItem in recipe.ingredients)
        {
            //go over each item in inventory
            for (int i = 0; i < playerInventory.GetSlots.Length; i++)
            {
                var slot = playerInventory.GetSlots[i];
                //if the item id is the same as the recipe, continue
                if (slot.item.Id == requiredItem.data.Id)
                {
                    //checks whether to remove the item or subtract one from its amount
                    if(slot.amount >= 2)
                    {
                        removedItems.Add(slot.item);
                        slot.UpdateSlot(slot.item, slot.amount - 1);
                        counter++;
                    }
                    else if(slot.amount == 1)
                    {
                        removedItems.Add(slot.item);
                        slot.RemoveItem();
                        counter++;
                    }
                }
            }
        }
        if (counter == recipe.ingredients.Count && playerInventory.EmptySlotCount >= 1)
        {
            playerInventory.AddItem(new Item(recipe.outcome), 1);
            Debug.Log("Crafted " + recipe.outcome.name);
        }
        else
        {
            for (int i = 0; i < removedItems.Count; i++)
            {
                playerInventory.AddItem(removedItems[i], 1);
            }
            Debug.Log("Unable to craft " + recipe.outcome.name);
        }
    }
}
