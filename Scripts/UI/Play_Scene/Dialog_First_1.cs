using UnityEngine;
using System.Collections;

public class Dialog_First_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c"))
        {
            GameObject.Find("Canvas").transform.Find("Dialog_First_2").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
	}
}
