using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public Item headItem;
	public Item bodyItem;
	public Item handItem;
	
	public GameObject torso;
	public GameObject hood;
	
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
		hood.GetComponent<SpriteRenderer>().sprite = headItem.itemSprite;
	}
	
	public void SetBodyItem(Item item)
	{
		bodyItem = item;
		torso.GetComponent<SpriteRenderer>().sprite = bodyItem.itemSprite;
	}
	
	public void SetHandItem(Item item)
	{
		handItem = item;
	}
	
}
