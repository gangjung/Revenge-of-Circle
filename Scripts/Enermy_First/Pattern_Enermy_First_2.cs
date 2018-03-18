using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_First_2 : MonoBehaviour {

    public Transform firePos;

    private BulletPool_Enermy _bulletPool;

    // Enable
    void OnEnable()
    {
        StartCoroutine(Attack());
    }

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Attack()
    {
        WaitForSeconds time = new WaitForSeconds(0.2f);
        WaitForSeconds time2 = new WaitForSeconds(1);
        Vector3 prePosition = firePos.position;
        Quaternion preRotation = firePos.rotation;
        Vector3 vector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        GameObject temp;

        _bulletPool = BulletPool_Enermy.instance;

        yield return time2;

        // Function

        for (int i = 0; i < 5; i++)
        {

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 360; j += 10)
                {
                    temp = _bulletPool.PopPool(firePos, "Bullet_First_2");
                    temp.SetActive(true);
                    firePos.Rotate(0, 0, 10);
                }

                yield return time;
            }

            transform.DOMove(vector, 1.5f);

            vector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

            yield return time2;
        }

        transform.DOMove(prePosition, 1);

        yield return time2;

        PatternManager_Enermy_First.runRoutin_First = false;
        GetComponent<PatternManager_Enermy_First>().enabled = false;
        enabled = false;
    }
}
