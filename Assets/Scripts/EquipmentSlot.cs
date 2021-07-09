using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
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
}
