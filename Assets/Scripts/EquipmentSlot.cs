using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{
	public Item item;
	public GameObject player;
	
	public Sprite defHead, defBody;
	
	private void Awake()
	{
		player = GameObject.Find("Player");
	}
	
	public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
	public class OnItemDroppedEventArgs : EventArgs
	{
		public Item droppedItem;
	}
	
    public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			Item item = eventData.pointerDrag.GetComponent<DragDrop>().item;
			OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { droppedItem = item });
		}
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		if (item.itemType == "Head")
		{
			player.GetComponent<CharacterEquipment>().hood.GetComponent<SpriteRenderer>().sprite = defHead;
			player.GetComponent<CharacterEquipment>().headItem = null;
		}
		else if (item.itemType == "Body")
		{
			player.GetComponent<CharacterEquipment>().torso.GetComponent<SpriteRenderer>().sprite = defBody;
			player.GetComponent<CharacterEquipment>().bodyItem = null;
		}
		
		player.GetComponent<CharacterController2D>().inventory.AddItem(item);
		item = null;

		this.transform.Find("sprite").GetComponent<Image>().sprite = null;
	}
}
