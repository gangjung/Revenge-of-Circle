using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bullet_Second_Special : MonoBehaviour {

    WaitForSeconds time;
    WaitForSeconds time2;

	// Use this for initialization
	void Start () {
        time = new WaitForSeconds(0.4f);
        time2 = new WaitForSeconds(0.01f);
        StartCoroutine(Attack());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator Attack()
    {
        yield return time;

        for (int i = 0; i < 5; i++)
        {
            transform.Translate(0, 1.2f, 0);

            yield return time2;
        }

        yield return time;

        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag.Equals("PLAYER"))
        {
            Debug.Log("충돌");
            GameObject.Find("SpecialAttack").transform.Find("Second").GetComponent<SpecialAttack_Second>().Fail();
        }
    }
}
