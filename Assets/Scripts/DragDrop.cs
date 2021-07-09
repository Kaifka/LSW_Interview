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
			player.GetComponent<CharacterEquipment>().SetHeadItem(item);
		}
		else if (item.itemType == "Body")
		{
			player.GetComponent<CharacterEquipment>().SetBodyItem(item);
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
