using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_First_1 : MonoBehaviour
{
    public Transform firePos;

    private BulletPool_Enermy _bulletPool;
    private GameObject bullet;

    void OnEnable()
    {
        StartCoroutine(Attack());
    }
	// Use this for initialization
	void Awake () {
        _bulletPool = BulletPool_Enermy.instance;
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator Attack()
    {
        /*****Variable*****/
        WaitForSeconds time = new WaitForSeconds(0.05f);
        WaitForSeconds time2 = new WaitForSeconds(1);
        Quaternion preRotation = firePos.rotation;
        Vector3 prePosition = firePos.position;
        GameObject temp;

        bullet = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_First("Bullet_First_1");

        /*****Function*****/
        transform.DOMove(new Vector3(0, 0, 0), 1);

        yield return time2;

        for(int i = 0; i<720; i+=5)
        {
            for (int j = 0; j < 4; j++)
            {
                temp = _bulletPool.PopPool(firePos.position, firePos.rotation, "Bullet_First_1");
                temp.SetActive(true);
                firePos.Rotate(0, 0, 90);
            }
            transform.Rotate(0, 0, 5);

            yield return time;
        }

        yield return time2;

        firePos.rotation = preRotation;

        PatternManager_Enermy_First.runRoutin_First = false;
        GetComponent<PatternManager_Enermy_First>().enabled = false;
        enabled = false;
    }
}
