using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	public int x;
	public int y;
	public Scroll scroll;

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	
	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			DragHandler.itemBeingDraged.transform.SetParent(transform);
		}
	}

	public void init (Scroll scroll, int x, int y) {
		this.x = x;
		this.y = y;
		this.scroll = scroll;
	}
}
