using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_CharacterEquipment : MonoBehaviour
{
	private EquipmentSlot headSlot;
	private EquipmentSlot bodySlot;
    private EquipmentSlot handSlot;
	private CharacterEquipment characterEquipment;
	
	private void Awake()
	{
		headSlot = transform.Find("equipSlotHead").GetComponent<EquipmentSlot>();
		bodySlot = transform.Find("equipSlotBody").GetComponent<EquipmentSlot>();
		handSlot = transform.Find("equipSlotHand").GetComponent<EquipmentSlot>();
	
		headSlot.OnItemDropped += HeadSlot_OnItemDropped;
		bodySlot.OnItemDropped += BodySlot_OnItemDropped;
		handSlot.OnItemDropped += HandSlot_OnItemDropped;
	}
	
	private void HeadSlot_OnItemDropped (object sender, EquipmentSlot.OnItemDroppedEventArgs e)
	{
		Image image = headSlot.transform.Find("sprite").GetComponent<Image>();
		image.sprite = e.droppedItem.itemSprite;
		characterEquipment.SetHeadItem(e.droppedItem);
		Debug.Log("Equip Head: " + e.droppedItem.itemName);
	}
	
	private void BodySlot_OnItemDropped (object sender, EquipmentSlot.OnItemDroppedEventArgs e)
	{
		Image image = headSlot.transform.Find("sprite").GetComponent<Image>();
		image.sprite = e.droppedItem.itemSprite;
		characterEquipment.SetBodyItem(e.droppedItem);
		Debug.Log("Equip Body: " + e.droppedItem.itemName);
	}
	
	private void HandSlot_OnItemDropped (object sender, EquipmentSlot.OnItemDroppedEventArgs e)
	{
		Image image = headSlot.transform.Find("sprite").GetComponent<Image>();
		image.sprite = e.droppedItem.itemSprite;
		characterEquipment.SetHandItem(e.droppedItem);
		Debug.Log("Equip Hand: " + e.droppedItem.itemName);
	}
	
	public void SetCharacterEquipment(CharacterEquipment characterEquipment)
	{
		this.characterEquipment = characterEquipment;
	}
	
	private void UpdateVisual()
	{
		
	}
	
}
