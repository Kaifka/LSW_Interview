using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Inventory : MonoBehaviour
{
    public Inventory inventory;
	public Transform slotContainer;
	public Transform itemSlotTemplate;
	
	private void Awake()
	{
		slotContainer = transform.Find("slotContainer");
		itemSlotTemplate = slotContainer.Find("itemSlotTemplate");
	}
	
	public void SetInventory(Inventory inventory)
	{
		this.inventory = inventory;
		inventory.OnItemListChanged += Inventory_OnItemListChanged;
	}
	
	private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
	{
		RedrawInventory();
	}

	private void RedrawInventory()
	{
		// Clean the inventory before drawing again
		foreach (Transform child in slotContainer)
		{
			if (child == itemSlotTemplate) continue;
			Destroy(child.gameObject);
		}
		
		int x = 0;
		int y = 0;
		float itemSlotSize = 45f;
		// Loop all items in the inventory a draw a template for each
		foreach (Item item in inventory.GetList())
		{
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, slotContainer).GetComponent<RectTransform>();
			itemSlotTemplate.GetChild(1).GetComponent<DragDrop>().SetItem(item);
			itemSlotRectTransform.gameObject.SetActive(true);
			itemSlotRectTransform.anchoredPosition = new Vector3(x * itemSlotSize, y * itemSlotSize);
			Image image = itemSlotRectTransform.Find("sprite").GetComponent<Image>();
			image.sprite = item.itemSprite;
			x++;
			if (x > 4)
			{
				x = 0;
				y--;
			}
		}
	}
	
}
