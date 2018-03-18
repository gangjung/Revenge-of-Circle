using UnityEngine;
using System.Collections;

public class Bullet_Final_Pattern1_2 : MonoBehaviour
{
    float speed = 30;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed * Time.deltaTime * Time.timeScale * Pattern_Enermy_Final_1.timepause, 0);
	}
}
