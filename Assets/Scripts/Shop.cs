using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	private Transform container;
	private Transform shopItemTemplate;
	private IShopCustomer shopCustomer;

	private void Awake()
	{
		container = transform.Find("container");
		shopItemTemplate = container.Find("shopItemTemplate");
		this.gameObject.SetActive(false);
	}
	
	private void Start()
	{
		Item hai = ShopItemDatabase.GetItemByID("0");
		Item hey = ShopItemDatabase.GetItemByID("1");
		Item hoy = ShopItemDatabase.GetItemByID("2");
		
		Item a = ShopItemDatabase.GetItemByID("3");
		Item b = ShopItemDatabase.GetItemByID("4");
		Item c = ShopItemDatabase.GetItemByID("5");
		
		// Create Items by using programmable objects
		CreateItemButton(hai.itemSprite, hai.itemID, hai.itemName, hai.itemCost, 0);
		CreateItemButton(hey.itemSprite, hey.itemID, hey.itemName, hey.itemCost, 1);
		CreateItemButton(hoy.itemSprite, hoy.itemID, hoy.itemName, hoy.itemCost, 2);
		
		CreateItemButton(a.itemSprite, a.itemID, a.itemName, a.itemCost, 3);
		CreateItemButton(b.itemSprite, b.itemID, b.itemName, b.itemCost, 4);
		CreateItemButton(c.itemSprite, c.itemID, c.itemName, c.itemCost, 5);
	}

	private void CreateItemButton(Sprite itemSprite, string itemID, string itemName, int itemCost, int positionIndex)
	{
		Transform shopItemTransform = Instantiate(shopItemTemplate, container);
		RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
		
		float shopItemHeight = 55f;
		shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
		
		shopItemTransform.Find("itemName").GetComponent<Text>().text = itemName;
		shopItemTransform.Find("itemPrice").GetComponent<Text>().text = itemCost.ToString();
		shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
		
		shopItemTransform.Find("BuyBtn").GetComponent<Button>().onClick.AddListener(() => { shopBuyItem(itemID); });
		shopItemTransform.Find("SellBtn").GetComponent<Button>().onClick.AddListener(() => { shopSellItem(itemID); });
	}
	
	private void shopBuyItem(string itemID)
	{
		shopCustomer.BoughtItem(itemID);
	}
	
	private void shopSellItem(string itemID)
	{
		shopCustomer.SoldItem(itemID);
	}
	
	public void Show(IShopCustomer shopCustomer)
	{
		this.shopCustomer = shopCustomer;
		gameObject.SetActive(true);
		
	}
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}
	
}