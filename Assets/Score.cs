using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
    bool endGame;
	// Use this for initialization
	void Start () {
        endGame = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (NextRound.roundNo == 6 && !endGame)
        {
            score.text = (NextRound.getScore()).ToString();
            endGame = true;
        }
    }


}
