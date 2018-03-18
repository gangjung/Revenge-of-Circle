using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_Second_3 : MonoBehaviour
{

    GameObject bullet;
    Vector3 vector;
    Vector3[] vector_Round = new Vector3[4];
    WaitForSeconds time;
    WaitForSeconds time2;
    WaitForSeconds time3;

    bool nowfinish;
    // OnEnable
    void OnEnable()
    {
        nowfinish = false;
        StartCoroutine(Attack());
    }

    // Use this for initialization
    void Awake()
    {
        time = new WaitForSeconds(1);
        time2 = new WaitForSeconds(0.1f);
        time3 = new WaitForSeconds(3);

        vector_Round[0] = new Vector3(0, 14, 0);
        vector_Round[1] = new Vector3(-11, 0, 0);
        vector_Round[2] = new Vector3(-0, -14, 0);
        vector_Round[3] = new Vector3(11, -0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = LookPlayer();
    }

    Quaternion LookPlayer()
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position - transform.position;
        
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;


        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }

    IEnumerator Attack()
    {
        bullet = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_Second("Bullet_Second_3");

        StartCoroutine(Ddong());

        for (int i = 0; i < 5; i++)
        {
            if (i == 4)
                transform.DOMove(vector_Round[0], 2);
            else
                transform.DOMove(vector_Round[i], 1);

            yield return time;
        }

        for (int i = 0; i < 7; i++)
        {
            while (true)
            {
                vector = new Vector3(Random.Range(-13, 13), Random.Range(-15, 15), 0);

                if ((vector.x < 10) && (vector.y < 11) && (vector.x > -10) && (vector.y > -11))
                    continue;
                else
                    break;
            }
            transform.DOMove(vector, 1);

            yield return time;
        }

        nowfinish = true;

        yield return time3;

        PatternManager_Enermy_Second.runRoutin_Second = false;
        GetComponent<PatternManager_Enermy_Second>().enabled = false;
        enabled = false;
    }

    IEnumerator Ddong()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, transform.rotation);

            yield return time2;

            if (nowfinish)
                break;
        }
    }
}
