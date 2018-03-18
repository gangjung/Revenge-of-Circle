using UnityEngine;
using System.Collections;

public class Dialog_Final_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c"))
        {
            GameObject.Find("All_Enermy").transform.Find("Enermy_Final").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
	}
}
