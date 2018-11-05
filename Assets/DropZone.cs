using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    private int cardsDropped_Q;
    private int cardsDropped_M;
    private int cardsDropped_F;

    void Start()
    {
        cardsDropped_Q = 0;
        cardsDropped_M = 0;
        cardsDropped_F = 0;
    }

    public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
		//Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null)
        {
            if (gameObject.name.Contains("Quarter") && (cardsDropped_Q < 4 || !d.abilitiesUI.text.Contains("Player")))
            {
                d.parentToReturnTo = this.transform;
                if (d.abilitiesUI.text.Contains("Player"))
                    cardsDropped_Q ++;
            }

            if (gameObject.name.Contains("Middle") && (cardsDropped_M < 4 || !d.abilitiesUI.text.Contains("Player")))
            {
                d.parentToReturnTo = this.transform;
                if (d.abilitiesUI.text.Contains("Player"))
                    cardsDropped_M ++;
            }

            if (gameObject.name.Contains("Forward") && (cardsDropped_F < 3 || !d.abilitiesUI.text.Contains("Player")))
            {
                d.parentToReturnTo = this.transform;
                if (d.abilitiesUI.text.Contains("Player"))
                    cardsDropped_F ++;
            }

            if (gameObject.name.Contains("Hand"))
            {
                d.parentToReturnTo = this.transform;
            }

        }
            

	}
}
