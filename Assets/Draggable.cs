using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

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
		Debug.Log ("OnEndDrag on round " + NextRound.roundNo);
        if ((abilitiesUI.text.Contains("+") || abilitiesUI.text.Contains("x")) && NextRound.roundNo > 3)
        {
            Debug.Log("Not a player");
            this.transform.SetParent(null);
            placeholder.transform.SetParent(null);

            foreach (Transform child in parentToReturnTo.transform)
            {
                int[] abilityExec = { 2, 2, 4, 4,
                    (child.gameObject).GetComponent<Draggable>().power,
                    (child.gameObject).GetComponent<Draggable>().defense };
                if (abilityIdx % 2 == 0)
                    (child.gameObject).GetComponent<Draggable>().power += abilityExec[abilityIdx];
                else
                    (child.gameObject).GetComponent<Draggable>().defense += abilityExec[abilityIdx];
                //Debug.Log("Power = " + (child.gameObject).GetComponent<Draggable>().power);
                (child.gameObject).GetComponent<Draggable>().updateCardUI(1, true);
                //child.GetComponent<Draggable>().power += 2;
                //child.GetComponent<Draggable>().updateCardUI(1, true);
            }
        }
        else if (leaderAbilitiesText.Any(abilitiesUI.text.Contains) && NextRound.roundNo > 3)
        {
            this.transform.SetParent(null);
            placeholder.transform.SetParent(null);

            foreach (Transform child in parentToReturnTo.transform)
            {
                int[] abilityExec = { 2 * (child.gameObject).GetComponent<Draggable>().power,
                    2 * (child.gameObject).GetComponent<Draggable>().defense,
                    (child.gameObject).GetComponent<Draggable>().power + (child.gameObject).GetComponent<Draggable>().defense,
                    (child.gameObject).GetComponent<Draggable>().defense + (child.gameObject).GetComponent<Draggable>().power,
                    (child.gameObject).GetComponent<Draggable>().power,
                    (child.gameObject).GetComponent<Draggable>().defense };
                if (abilityIdx % 2 == 0)
                    (child.gameObject).GetComponent<Draggable>().power += abilityExec[abilityIdx];
                else
                    (child.gameObject).GetComponent<Draggable>().defense += abilityExec[abilityIdx];
                //Debug.Log("Power = " + (child.gameObject).GetComponent<Draggable>().power);
                (child.gameObject).GetComponent<Draggable>().updateCardUI(1, true);
                //child.GetComponent<Draggable>().power += 2;
                //child.GetComponent<Draggable>().updateCardUI(1, true);
            }
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        }	
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);
	}

    //[Header("Text Boxes")]
    public Text abilitiesUI;
    public Text powerUI;
    public Text defenseUI;

    //[Header("Images on card")]
    public Image player;
    public Image frame;

    //[Header("Stats")]
    public int power;
    public int defense;

    public int abilityIdx;
    public string[] abilitiesText = { "+2 ATK", "+2 DEF", "+4 ATK", "+4 DEF", "x2 ATK", "x2 DEF" };
    public string[] leaderAbilitiesText = { "Blessing", "Spartan", "O.G.", "Speaker", "Godfather", "Skilled"};

    public void updateCardUI(int round, bool isPlayer)
    {
        powerUI.text = power.ToString();
        defenseUI.text = defense.ToString();
        abilitiesUI.text = isPlayer ? "Player" : abilitiesText[abilityIdx];
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
            abilitiesUI.text = leaderAbilitiesText[abilityIdx];
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
