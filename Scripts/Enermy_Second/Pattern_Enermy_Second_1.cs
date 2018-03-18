using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_Second_1 : MonoBehaviour
{

    GameObject bullet;
    public Transform firePos;
    WaitForSeconds time = new WaitForSeconds(0.3f);
    WaitForSeconds time2 = new WaitForSeconds(1);
    Vector3 vector1, vector2, vector3, vector4, vector5, vector6;

    // OnEnable
    void OnEnable()
    {
        StartCoroutine(Attack());
        StartCoroutine(Looking());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

    Vector3 NextVector(Vector3 origin_Pos, float angle, float distance)
    {
        // 왜인지모르겠지만 Mathf.PI*2* angle/360 이렇게가 아니라 angle이거만 해주면 이상하게나온다.
        return origin_Pos + new Vector3(Mathf.Cos(Mathf.PI * 2 * angle / 360) * distance, Mathf.Sin(Mathf.PI * 2 * angle / 360) * distance, 0);
    }

    IEnumerator Looking()
    {
        while (true)
        {
            transform.rotation = LookPlayer();

            yield return null;
        }
    }

    IEnumerator Attack()
    {
        Vector3 vector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        bullet = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_Second("Bullet_Second_Sphere");

        for (int i = 0; i < 3; i++)
        {
            firePos = this.transform;

            vector1 = NextVector(firePos.position, firePos.rotation.eulerAngles.z, 3);
            vector2 = NextVector(firePos.position, firePos.rotation.eulerAngles.z, 6);
            vector3 = NextVector(firePos.position, firePos.rotation.eulerAngles.z, -3);
            vector4 = NextVector(firePos.position, firePos.rotation.eulerAngles.z, -6);
            vector5 = NextVector(firePos.position, firePos.rotation.eulerAngles.z + 90, 3);
            vector6 = NextVector(firePos.position, firePos.rotation.eulerAngles.z - 90, 3);
            Instantiate(bullet, vector1, firePos.rotation);

            yield return time;

            Instantiate(bullet, vector3, firePos.rotation);

            yield return time;

            Instantiate(bullet, vector2, firePos.rotation);

            yield return time;

            Instantiate(bullet,  vector4, firePos.rotation);

            yield return time;

            Instantiate(bullet, vector5, firePos.rotation);

            yield return time;

            Instantiate(bullet, vector6, firePos.rotation);

            yield return time;

            transform.DOMove(vector, 1);
            vector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
            
            yield return time2;
        }

        StopCoroutine(Looking());
        StopAllCoroutines();
        firePos.rotation = new Quaternion(0, 0, 0, 0);
        PatternManager_Enermy_Second.runRoutin_Second = false;
        GetComponent<PatternManager_Enermy_Second>().enabled = false;
        enabled = false;
    }
}
