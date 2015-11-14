using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	public static GameObject itemBeingDraged;
	Vector3 startPosition;
	Transform startParent;

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDraged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;

		GetComponent<Image> ().raycastTarget = false;
	}

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDraged = null;

		GetComponent<Image> ().raycastTarget = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		} else {
			Slot slot = transform.parent.gameObject.GetComponent<Slot>();
			Rune rune = GetComponent<Rune>();
			if (slot != null) {
				Scroll scroll = slot.transform.parent.gameObject.GetComponent<Scroll>();
				if (scroll != null && rune != null) {
					rune.place(scroll, slot.x, slot.y);
				}
			}
		}
	}
}
