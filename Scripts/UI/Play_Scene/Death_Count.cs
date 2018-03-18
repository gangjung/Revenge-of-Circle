using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Death_Count : MonoBehaviour {

    public int size = 10;
    Text t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        //size = t.fontSize;
	}
	
	// Update is called once per frame
	void Update () {
        t.fontSize = Screen.height * size / 100;

        t.text = Player.death_Count.ToString();
	}
}
