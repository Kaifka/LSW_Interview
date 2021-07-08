using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer {
	
	void BoughtItem(string itemID);
	void SoldItem(string itemID);
	List<Item> GetInventory();
}