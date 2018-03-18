using UnityEngine;
using System.Collections;

public class Ptc_Hit_Enermy : MonoBehaviour {

    float time = 0.5f;

	// Use this for initialization
	void Start () {
        transform.Rotate (-90, 0, 0);

        Destroy(this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
