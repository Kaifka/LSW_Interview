using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="Assets/Item")]
public class Item : ScriptableObject
{
	public enum itemType 
	{
		head, 
		body
	}
	
	public string itemID;
	public string itemName;
	public int itemCost;
	public Sprite itemSprite;
}


