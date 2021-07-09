using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEquipment : MonoBehaviour
{
    public Item headItem;
	public Item bodyItem;
	public Item handItem;
	
	public GameObject torso;
	public GameObject hood;
	
	public GameObject headSlot,bodySlot;
	
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
		headSlot.GetComponent<EquipmentSlot>().item = item;
		headSlot.transform.Find("sprite").GetComponent<Image>().sprite = item.itemSprite;
		hood.GetComponent<SpriteRenderer>().sprite = headItem.itemSprite;
	}
	
	public void SetBodyItem(Item item)
	{
		bodyItem = item;
		bodySlot.GetComponent<EquipmentSlot>().item = item;
		bodySlot.transform.Find("sprite").GetComponent<Image>().sprite = item.itemSprite;
		torso.GetComponent<SpriteRenderer>().sprite = bodyItem.itemSprite;
	}
	
	public void SetHandItem(Item item)
	{
		handItem = item;
	}
	
}
