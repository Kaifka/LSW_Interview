using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[SerializeField] private Canvas canvas;
	
	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	public Item item;
	
	public GameObject player;
	
	private void Awake()
	{
		player = GameObject.Find("Player");
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	public void SetItem(Item incomingItem)
	{
		item = incomingItem;
	}
	
    public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Clicked Item" + item.itemName);
		if (item.itemType == "Head")
		{
			if (player.GetComponent<CharacterEquipment>().GetHeadItem() == null)
			{
				player.GetComponent<CharacterEquipment>().SetHeadItem(item);
				player.GetComponent<CharacterController2D>().inventory.RemoveItem(item);
			}
			else
			{
				Item alreadyEquip = player.GetComponent<CharacterEquipment>().GetHeadItem();
				player.GetComponent<CharacterEquipment>().SetHeadItem(item);
				player.GetComponent<CharacterController2D>().inventory.RemoveItem(item);
				player.GetComponent<CharacterController2D>().inventory.AddItem(alreadyEquip);
			}

		}
		else if (item.itemType == "Body")
		{
			if (player.GetComponent<CharacterEquipment>().GetBodyItem() == null)
			{
				player.GetComponent<CharacterEquipment>().SetBodyItem(item);
				player.GetComponent<CharacterController2D>().inventory.RemoveItem(item);
			}
			else
			{
				Item alreadyEquip = player.GetComponent<CharacterEquipment>().GetBodyItem();
				player.GetComponent<CharacterEquipment>().SetBodyItem(item);
				player.GetComponent<CharacterController2D>().inventory.RemoveItem(item);
				player.GetComponent<CharacterController2D>().inventory.AddItem(alreadyEquip);
			}
		}
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("Dragging Item");
		
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
	
    public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("Dragging Item");
		canvasGroup.blocksRaycasts = false;
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("Stopped Dragging Item");
		canvasGroup.blocksRaycasts = true;
	}

}
