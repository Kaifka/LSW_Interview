using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private Item headItem;
	private Item bodyItem;
	private Item handItem;
	
	public Item GetHeadItem()
	{
		return headItem;
	}
	
	public Item GetBodyItem()
	{
		return bodyItem;
	}
	
	public Item GetHandItem()
	{
		return handItem;
	}
	
	public void SetHeadItem(Item item)
	{
		headItem = item;
	}
	
	public void SetBodyItem(Item item)
	{
		bodyItem = item;
	}
	
	public void SetHandItem(Item item)
	{
		handItem = item;
	}
	
}
