using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
	
	private static Notification instance;
	
	private Text messageTxt;
	private RectTransform backgroundRectTransform;
	private float textPaddingSize = 4f;
	
	private void Awake()
	{
		instance = this;
		backgroundRectTransform = transform.Find("NotificationBackground").GetComponent<RectTransform>();
		messageTxt = transform.Find("NotificationTxt").GetComponent<Text>();
		
		HideNotification();
	}
	
    private void ShowNotification(string message)
	{
		gameObject.SetActive(true);
		messageTxt.text = message;
		Vector2 backgroundSize = new Vector2(messageTxt.preferredWidth + textPaddingSize * 2f, messageTxt.preferredHeight + textPaddingSize * 2f); 
		backgroundRectTransform.sizeDelta = backgroundSize;
		StartCoroutine(NotificationTimer());
	}
	
	private void HideNotification()
	{
		gameObject.SetActive(false);
	}
	
	public static void ShowNotificationStatic (string message)
	{
		instance.ShowNotification(message);
	}
	
	public static void HideTooltip_Static ()
	{
		instance.HideNotification();
	}
	
	IEnumerator NotificationTimer()
	{
		yield return new WaitForSeconds(3);
		HideNotification();
	}
	
}
