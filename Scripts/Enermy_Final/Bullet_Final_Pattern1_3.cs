using UnityEngine;
using System.Collections;

public class Bullet_Final_Pattern1_3: MonoBehaviour {

    public float speed = 10;

    private void OnEnable()
    {
        Invoke("PushPool", 15);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed * Time.deltaTime * Pattern_Enermy_Final_1.timepause, 0);
	}

    private void PushPool()
    {
        BulletPool_Enermy.instance.PushPool(null, "Bullet_Final_1_3", this.gameObject);
    }
}
