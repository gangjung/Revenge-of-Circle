using UnityEngine;
using System.Collections;

using DG.Tweening;
using System.Collections.Generic;

public class Pattern_Enermy_Final_1 : MonoBehaviour
{
    // Declaration variables
    public static int timepause = 1;
    GameObject TimePauseSound;
    public Transform boss;
    public Transform firePos;
    public Transform firePos2;

    public AudioClip audio;

    private BulletPool_Enermy _bulletPool;
    private List<GameObject> bullet_1_1 = new List<GameObject>();
    private List<GameObject> bullet_1_2_1 = new List<GameObject>();
    private List<GameObject> bullet_1_2_2 = new List<GameObject>();
    private List<GameObject> bullet_3 = new List<GameObject>();
    private List<GameObject> bullet_2_L = new List<GameObject>();
    private List<GameObject> bullet_2_R = new List<GameObject>();

    // Use this for initialization
    void OnEnable()
    {
        if (_bulletPool == null)
            _bulletPool = BulletPool_Enermy.instance;

        if(TimePauseSound == null)
            TimePauseSound = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_Final("TimePauseSound");

        StartCoroutine(DeplaytionWorld());
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DeplaytionWorld()
    {
        // Declaration veriables
        float distance = 1.0f;

        GameObject temp;
        Quaternion temp2 = firePos.rotation;
        Vector3 vector = new Vector3(Random.Range(-10, 10), Random.Range(6, 13), 0);

        WaitForSeconds time = new WaitForSeconds(0.1f);
        WaitForSeconds time2 = new WaitForSeconds(0.02f);

        // Start function
         StartCoroutine(DeplaytionWorld_1());

        yield return new WaitForSeconds(1.0f);

         StartCoroutine(DeplaytionWorld_2());

        // 앞쪽에 둔 이유는, 일정시간이 흐른 후에 사라지는 것 처럼 보이게 하기 위해서 ㅇㅇ
        CollectBullet(bullet_1_1, "Bullet_Final_1_1");
        CollectBullet(bullet_1_2_1, "Bullet_Final_1_2_1");
        CollectBullet(bullet_1_2_2, "Bullet_Final_1_2_2");

        bullet_1_1.Clear();
        bullet_1_2_1.Clear();
        bullet_1_2_2.Clear();

        transform.DOMove(vector, 1.5f); // move

        firePos.Rotate(0, 0, 180);

        for (int i = 0; i < 13; i++)
        {
            temp = _bulletPool.PopPool(firePos.position, LookPlayer(), "Bullet_Final_1_1");

            temp.SetActive(true);

            bullet_1_1.Add(temp);

            yield return time;
        }

        transform.DOMove(vector, 1.5f); // move

        DeplaytionWorld_Timepause_On();

        for (int i = 0; i < 25; i++)
        {
            // 필요없는 충돌 처리를 줄이기 위해, Collider가 있는 것과 없는 것을 번갈아가면서 생성.
            if(i%2 == 0)
            {
                foreach (GameObject obj in bullet_1_1)
                {
                    temp = _bulletPool.PopPool(NextVector(obj.transform.position, obj.transform.rotation.eulerAngles.z, distance), obj.transform.rotation, "Bullet_Final_1_2_1");
                    temp.SetActive(true);
                    bullet_1_2_1.Add(temp);

                    temp = _bulletPool.PopPool(NextVector(obj.transform.position, obj.transform.rotation.eulerAngles.z, -distance), obj.transform.rotation, "Bullet_Final_1_2_1");
                    temp.SetActive(true);
                    bullet_1_2_1.Add(temp);
                }
            }
            else
            {
                foreach (GameObject obj in bullet_1_1)
                {
                    temp = _bulletPool.PopPool(NextVector(obj.transform.position, obj.transform.rotation.eulerAngles.z, distance), obj.transform.rotation, "Bullet_Final_1_2_2");
                    temp.SetActive(true);
                    bullet_1_2_2.Add(temp);

                    temp = _bulletPool.PopPool(NextVector(obj.transform.position, obj.transform.rotation.eulerAngles.z, -distance), obj.transform.rotation, "Bullet_Final_1_2_2");
                    temp.SetActive(true);
                    bullet_1_2_2.Add(temp);
                }
            }

            distance += 1.0f;

            yield return time2;
        }

        yield return new WaitForSeconds(1);

        DeplaytionWorld_Timepause_False();

        yield return new WaitForSeconds(1);

        PatternManager_Enermy_Final.runRoutin = false;
        GameObject.Find("Enermy_Final").GetComponent<PatternManager_Enermy_Final>().enabled = false;
        enabled = false;
        firePos.rotation = temp2;
    }

    IEnumerator DeplaytionWorld_1()
    {
        GameObject temp;

        CollectBullet(bullet_2_L, "Bullet_Final_1_1_L");
        CollectBullet(bullet_2_R, "Bullet_Final_1_1_R");

        bullet_2_L.Clear();
        bullet_2_R.Clear();

        for (int i = 0; i < 360; i += 30)
        {
            temp = _bulletPool.PopPool(firePos.position, firePos.rotation, "Bullet_Final_1_1_L");

            temp.SetActive(true);
            firePos.Rotate(0, 0, 30);
            bullet_2_L.Add(temp);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 360; i += 30)
        {
            temp = _bulletPool.PopPool(firePos.position, firePos.rotation, "Bullet_Final_1_1_R");

            temp.SetActive(true);
            firePos.Rotate(0, 0, -30);
            bullet_2_R.Add(temp);
        }

        yield return new WaitForSeconds(4);


    }

    IEnumerator DeplaytionWorld_2()
    {
        Quaternion temp = firePos2.rotation;
        Quaternion temp2 = LookPlayer();
        GameObject temp3;

        bullet_3.Clear();

        /*****Function*****/
        for (int j = 0; j < 2; j++)
        {
            firePos2.rotation = temp2;

            if (count_1_3 % 2 == 0)
            {
                firePos2.Rotate(0, 0, 5);
            }

            temp3 = _bulletPool.PopPool(firePos2.position, firePos2.rotation, "Bullet_Final_1_3");
            temp3.SetActive(true);
            bullet_3.Add(temp3);

            for (int i = 1; i < (count_1_3 / 2); i++)
            {
                firePos2.Rotate(0, 0, 10);
                temp3 = _bulletPool.PopPool(firePos2.position, firePos2.rotation, "Bullet_Final_1_3");
                temp3.SetActive(true);
                bullet_3.Add(temp3);
            }

            firePos2.rotation = temp2;

            if (count_1_3 % 2 == 0)
            {
                firePos2.Rotate(0, 0, -5);
            }
            temp3 = _bulletPool.PopPool(firePos2.position, firePos2.rotation, "Bullet_Final_1_3");

            temp3.SetActive(true);
            bullet_3.Add(temp3);

            for (int i = 1; i < (count_1_3 / 2); i++)
            {
                firePos2.Rotate(0, 0, -10);
                temp3 = _bulletPool.PopPool(firePos2.position, firePos2.rotation, "Bullet_Final_1_3");
                temp3.SetActive(true);
                bullet_3.Add(temp3);
            }

            yield return new WaitForSeconds(1);
        }

        count_1_3++;
        firePos2.rotation = temp;
    }

    void CollectBullet(List<GameObject> bullet, string key)
    {
        if (bullet == null)
            return;

        foreach(GameObject obj in bullet)
            _bulletPool.PushPool(boss, key, obj);
    }

    void DeplaytionWorld_Timepause_On()
    {
        timepause = 0;
        GameObject.Find("Player").GetComponent<CircleCollider2D>().isTrigger = false;
        GameObject.Find("Player").GetComponent<FireCtrl>().enabled = false;

        Debug.Log(TimePauseSound);
        Instantiate(TimePauseSound, transform.position, transform.rotation);
    }
    void DeplaytionWorld_Timepause_False()
    {
        timepause = 1;
        GameObject.Find("Player").GetComponent<CircleCollider2D>().isTrigger = true;
        GameObject.Find("Player").GetComponent<FireCtrl>().enabled = true;

        Instantiate(TimePauseSound, transform.position, transform.rotation);
    }

    Vector3 NextVector(Vector3 origin_Pos, float angle, float distance)
    {
        angle -= 90;

        // 왜인지모르겠지만 Mathf.PI*2* angle/360 이렇게가 아니라 angle이거만 해주면 이상하게나온다.
        return origin_Pos + new Vector3(Mathf.Cos(Mathf.PI * 2 * angle / 360) * distance, Mathf.Sin(Mathf.PI * 2 * angle / 360) * distance, 0);
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
}
