using UnityEngine;
using System.Collections;

public class Wait_Second : MonoBehaviour {
    float nowTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (nowTime > 2)
        {
            GameObject.Find("Canvas").transform.Find("Dialog_Second_1").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
        nowTime += Time.deltaTime;  
	}
}
