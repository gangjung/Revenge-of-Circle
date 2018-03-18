using UnityEngine;
using System.Collections;

public class Ptc_Hit_Shield : MonoBehaviour {

    public float time = 0.5f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
