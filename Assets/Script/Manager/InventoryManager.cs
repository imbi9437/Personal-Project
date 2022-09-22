using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public InventoryUI playerInventory;
    public InventoryUI quickSlot;
    public InventoryUI armorSlot;
    public InventoryUI interactionSlot;
    public MoveSlot usingSlot;
}
