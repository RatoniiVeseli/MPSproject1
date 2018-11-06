using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour {

    public GameObject cardTemplate;
    public Canvas canvas;
    public Button genDeck; // sper sa mearga lol
    public static int cardsChosen;
    public static int roundNo;
    public static int score;

    // Use this for initialization
    void Start () {
        cardsChosen = 0;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (cardsChosen == 11)
        {
            genDeck.interactable = true;

            // clean the table
            if (cardsChosen == 11)
            {
                foreach (Transform child in GameObject.Find("Quarterback").transform)
                {
                    child.SetParent(null);
                }

                foreach (Transform child in GameObject.Find("Middle").transform)
                {
                    child.SetParent(null);
                }
            }
        }

        if (cardsChosen == 17)
        {
            genDeck.interactable = true;

            // clean the table
            if (cardsChosen == 17)
                foreach (Transform child in GameObject.Find("Forward").transform)
                    child.SetParent(null);
        }

        if (cardsChosen == 19)
        {
            genDeck.interactable = true;

            foreach (Transform child in GameObject.Find("Quarterback").transform)
            {
                child.SetParent(null);
            }

            foreach (Transform child in GameObject.Find("Middle").transform)
            {
                child.SetParent(null);
            }

            foreach (Transform child in GameObject.Find("Forward").transform)
            {
                child.SetParent(null);
            }
        }

        if (roundNo == 6)
        {
            genDeck.interactable = true;

            foreach (Transform child in GameObject.Find("Quarterback").transform)
            {
                child.SetParent(null);
            }

            foreach (Transform child in GameObject.Find("Middle").transform)
            {
                child.SetParent(null);
            }

            foreach (Transform child in GameObject.Find("Forward").transform)
            {
                child.SetParent(null);
            }
        }
    }

    public static int getScore()
    {
        score = 0;
        foreach (Transform child in GameObject.Find("Forward").transform)
        {
            score += (child.gameObject).GetComponent<Draggable>().defense + (child.gameObject).GetComponent<Draggable>().power;
        }

        foreach (Transform child in GameObject.Find("Quarterback").transform)
        {
            score += (child.gameObject).GetComponent<Draggable>().defense + (child.gameObject).GetComponent<Draggable>().power;
        }

        foreach (Transform child in GameObject.Find("Middle").transform)
        {
            score += (child.gameObject).GetComponent<Draggable>().defense + (child.gameObject).GetComponent<Draggable>().power;
        }

        return score;
    }

    public void nextHand()
    {
        roundNo++; // next round
        if (roundNo < 3)
        {
            genDeck.interactable = false;
            if (roundNo == 1)
                genDeck.GetComponentInChildren<Text>().text = "SPELLS";
            else if (roundNo == 2)
                genDeck.GetComponentInChildren<Text>().text = "LEADERS";
        }
        else if (roundNo == 3)
            genDeck.GetComponentInChildren<Text>().text = "PLAY";
        else if (roundNo == 4)
            genDeck.GetComponentInChildren<Text>().text = "SPELLS";
        else if (roundNo == 5)
            genDeck.GetComponentInChildren<Text>().text = "FINISH";
        else
            genDeck.interactable = false;

        //Debug.Log("Negat" + cardsChosen);
        bool isPlayer = true;
        for (int i = 0; i < 12 && cardsChosen < 11; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Quarterback").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            //Debug.Log(System.IO.Path.GetFileName("Footballers/" + Random.Range(40, 80).ToString()));
            newCard.GetComponent<Draggable>().updateCardUI(1, isPlayer);
        }

        for (int i = 0; i < 12 && cardsChosen < 11; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Middle").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            newCard.GetComponent<Draggable>().updateCardUI(1, isPlayer);
        }

        if (cardsChosen == 11)
            cardsChosen++;

        for (int i = 0; i < 10 && cardsChosen == 12; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Forward").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            newCard.GetComponent<Draggable>().updateCardUI(2, !isPlayer);
        }

        if (cardsChosen == 17)
            cardsChosen++;

        for (int i = 0; i < 14 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Forward").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            newCard.GetComponent<Draggable>().updateCardUI(3, !isPlayer);
        }
        for (int i = 0; i < 13 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Quarterback").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            newCard.GetComponent<Draggable>().updateCardUI(3, !isPlayer);
        }
        for (int i = 0; i < 13 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Middle").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilityIdx = Random.Range(0, 6);
            newCard.GetComponent<Draggable>().updateCardUI(3, !isPlayer);
        }
    }
}
