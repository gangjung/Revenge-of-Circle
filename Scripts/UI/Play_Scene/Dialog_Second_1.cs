using UnityEngine;
using System.Collections;

public class Dialog_Second_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c"))
        {
            GameObject.Find("Canvas").transform.Find("Dialog_Second_2").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
	}
}
