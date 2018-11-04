using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;


    public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log ("OnBeginDrag");
		
		placeholder = new GameObject();
		placeholder.transform.SetParent( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
		
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent( this.transform.parent.parent );
        NextRound.cardsChosen++;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		
		this.transform.position = eventData.position;

		if(placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}
	
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("OnEndDrag");
		this.transform.SetParent( parentToReturnTo );
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);
	}

    [Header("Text Boxes")]
    public Text abilitiesUI;
    public Text powerUI;
    public Text defenseUI;

    [Header("Images on card")]
    public Image player;
    public Image frame;

    [Header("Stats")]
    public int power;
    public int defense;
    /* aici depinde de voi cum retineti abilitatile. */
    public List<int> abilities = new List<int>();
    public string[] abilitiesText = { "Flying", "Trample", "Deathtouch", "Defender", "Reach", "First Strike" };

    public void updateCardUI(int round)
    {
        powerUI.text = power.ToString();
        defenseUI.text = defense.ToString();
        abilitiesUI.text = abilitiesText[abilities[0]];
        if (round == 1)
            player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
        if (round == 2)
        {
            player.sprite = Resources.Load<Sprite>("Func/" + Random.Range(1, 34).ToString());
            frame.sprite = Resources.Load<Sprite>("Spell");
            powerUI.text = "SPE";
            defenseUI.text = "LL";
        }
        if (round == 3)
        {
            player.sprite = Resources.Load<Sprite>("Leader/" + Random.Range(1, 40).ToString());
            frame.sprite = Resources.Load<Sprite>("Leader");
            powerUI.text = "LEA";
            defenseUI.text = "DER";
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
