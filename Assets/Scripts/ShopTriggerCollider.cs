using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour {

	[SerializeField] private Shop shop;
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
		
		if (shopCustomer != null)
		{
			shop.Show(shopCustomer);
		}
	}
	
	private void OnTriggerExit2D(Collider2D collider)
	{
		IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
		if (shopCustomer != null)
		{
			shop.Hide();
		}
	}

}