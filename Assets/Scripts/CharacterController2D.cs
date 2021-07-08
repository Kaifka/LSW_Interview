using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour, IShopCustomer
{
	
	Rigidbody2D rigidbody2d;
	[SerializeField] float speed = 2f;
	Vector2 motionVector;
	
	public List<Item> inventory;
	
	public int credits;
	
	public Text creditTxt;
	
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
		credits = 10;
		creditTxt = GameObject.Find("CreditTxt").GetComponent<Text>();
    }
	
	private void Update()
	{
		motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    void FixedUpdate()
    {
        Move();
		creditTxt.text = credits.ToString();
    }
	
	private void Move()
	{
		rigidbody2d.velocity = motionVector * speed;
	}
	
	private void handleUI()
	{
		
	}
	
	public void BoughtItem(string itemID)
	{
		Item item = ShopItemDatabase.GetItemByID(itemID);
		if (credits >= item.itemCost)
		{
			inventory.Add (item);
			Debug.Log(item.itemName);
			credits -= item.itemCost;
		}
		else
		{
			Notification.ShowNotificationStatic("Not Enough Credits");
		}

	}
	
	public void SoldItem(string itemID)
	{
		Item item = ShopItemDatabase.GetItemByID(itemID);
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemID == itemID)
			{
				credits += item.itemCost;
				inventory.Remove (inventory[i]);
				return;
			}
		}
		Notification.ShowNotificationStatic("No Item to Sell");
	}
	
	public List<Item> GetInventory()
	{
		return inventory;
	}

}
