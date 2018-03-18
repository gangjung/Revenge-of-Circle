using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_First_3 : MonoBehaviour {

    public Transform firePos;

    private BulletPool_Enermy _bulletPool;
    private WaitForSeconds time;

    void OnEnable()
    {
        StartCoroutine(Attack());
    }

	// Use this for initialization
	void Awake () {
        time = new WaitForSeconds(0.8f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    Quaternion LookPlayer()
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position - firePos.position;
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다. 확인 ㄱㄱ
        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }

    IEnumerator Attack()
    {
        Quaternion preQuaternion = firePos.rotation;
        Vector3 vector = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0);
        GameObject temp;

        _bulletPool = BulletPool_Enermy.instance;

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < 8; i++)
        {
            firePos.rotation = LookPlayer();
            temp = _bulletPool.PopPool(firePos, "Bullet_First_3");
            temp.SetActive(true);

            transform.DOMove(vector, 0.8f);
            vector = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0);

            yield return time;
        }

        yield return new WaitForSeconds(1);

        firePos.rotation = preQuaternion;
        PatternManager_Enermy_First.runRoutin_First = false;
        GetComponent<PatternManager_Enermy_First>().enabled = false;
        enabled = false;
    }
}
