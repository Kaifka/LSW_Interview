using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour, IShopCustomer
{
	
	Rigidbody2D rigidbody2d;
	[SerializeField] float speed = 2f;
	Vector2 motionVector;
	
	public List<Item> inventory;
	
	
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
	
	private void Update()
	{
		motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    void FixedUpdate()
    {
        Move();
    }
	
	private void Move()
	{
		rigidbody2d.velocity = motionVector * speed;
	}
	
	public void BoughtItem(string itemID)
	{
		Item item = ShopItemDatabase.GetItemByID(itemID);
		inventory.Add (item);
		Debug.Log(item.itemName);
	}
	
	public void SoldItem(string itemID)
	{
		Item item = ShopItemDatabase.GetItemByID(itemID);
		inventory.Remove (item);
	}
	
	public List<Item> GetInventory()
	{
		return inventory;
	}

}
