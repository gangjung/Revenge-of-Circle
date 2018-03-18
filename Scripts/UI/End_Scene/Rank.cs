using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rank : MonoBehaviour {

    public int size = 3;
    Text t;
    int count;
    char rank;

	// Use this for initialization
	void Start () {
        count = Player.death_Count;

	    t = GetComponent<Text>();

        if ((0 <= count) && (count < 5))
            rank = 'S';
        else if ((5 <= count) && (count < 10))
            rank = 'A';
        else if ((10 <= count) && (count < 15))
            rank = 'B';
        else if ((15 <= count) && (count < 20))
            rank = 'C';
        else
            rank = 'F';

        Invoke("Next", 1);
	}
	
	// Update is called once per frame
	void Update () {
        t.fontSize = Screen.height * size / 100;

        t.text = rank.ToString();
	}

    void Next()
    {
        GameObject.Find("Canvas").transform.Find("Result").transform.Find("Question").gameObject.SetActive(true);
    }
}
