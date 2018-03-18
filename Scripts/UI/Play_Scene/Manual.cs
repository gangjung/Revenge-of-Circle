using UnityEngine;
using System.Collections;

public class Manual : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("c"))
        {
            GameObject.Find("Canvas").transform.Find("Wait_First").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
	}
}
