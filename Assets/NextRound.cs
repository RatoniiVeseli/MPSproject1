using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour {

    public GameObject cardTemplate;
    public Canvas canvas;
    public Button genDeck; // sper sa mearga lol
    public static int cardsChosen;

    // Use this for initialization
    void Start () {
        cardsChosen = 0;
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
                    child.parent = null;
                }

                foreach (Transform child in GameObject.Find("Middle").transform)
                {
                    child.parent = null;
                }
            }
        }

        if (cardsChosen == 17)
        {
            genDeck.interactable = true;

            // clean the table
            if (cardsChosen == 17)
                foreach (Transform child in GameObject.Find("Forward").transform)
                    child.parent = null;
        }

        if (cardsChosen == 19)
        {
            foreach (Transform child in GameObject.Find("Quarterback").transform)
            {
                child.parent = null;
            }

            foreach (Transform child in GameObject.Find("Middle").transform)
            {
                child.parent = null;
            }

            foreach (Transform child in GameObject.Find("Forward").transform)
            {
                child.parent = null;
            }
        }
    }

    public void nextHand()
    {
        genDeck.interactable = false;
        Debug.Log("Negat" + cardsChosen);
        for (int i = 0; i < 12 && cardsChosen < 11; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Quarterback").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            //Debug.Log(System.IO.Path.GetFileName("Footballers/" + Random.Range(40, 80).ToString()));
            newCard.GetComponent<Draggable>().updateCardUI(1);
        }

        for (int i = 0; i < 12 && cardsChosen < 11; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Middle").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            newCard.GetComponent<Draggable>().updateCardUI(1);
        }

        if (cardsChosen == 11)
            cardsChosen++;

        for (int i = 0; i < 10 && cardsChosen == 12; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Forward").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            //newCard.GetComponent<Draggable>().player.sprite = Resources.Load<Sprite>("Footballers/" + Random.Range(40, 80).ToString());
            newCard.GetComponent<Draggable>().updateCardUI(2);
        }

        if (cardsChosen == 17)
            cardsChosen++;

        for (int i = 0; i < 14 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Forward").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            newCard.GetComponent<Draggable>().updateCardUI(3);
        }
        for (int i = 0; i < 13 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Quarterback").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            newCard.GetComponent<Draggable>().updateCardUI(3);
        }
        for (int i = 0; i < 13 && cardsChosen == 18; i++)
        {
            GameObject newCard = Instantiate(cardTemplate);
            newCard.transform.SetParent(GameObject.Find("Middle").transform);
            newCard.GetComponent<Draggable>().power = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().defense = Random.Range(1, 10);
            newCard.GetComponent<Draggable>().abilities.Add(Random.Range(0, 6));
            newCard.GetComponent<Draggable>().updateCardUI(3);
        }
    }
}
