using UnityEngine;
using System.Collections;

public class Button_Start : MonoBehaviour {

    void OnDisable()
    {
        Sound_Manager.instance.PlaySound_Click();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
