using UnityEngine;
using System.Collections;

public class Bullet_RoundBall : MonoBehaviour {

    public float damage = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        damage = 100 - (GameObject.Find("RoundBall").GetComponent<Pattern_RounBall>().radius * 3);
	}
}
