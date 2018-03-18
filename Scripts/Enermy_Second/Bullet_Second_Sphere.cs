using UnityEngine;
using System.Collections;

public class Bullet_Second_Sphere : MonoBehaviour
{
    public float damage = 20;
    public float speed = 1500.0f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreateBullet());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CreateBullet()
    {
        WaitForSeconds time = new WaitForSeconds(0.01f);

        Vector3 scale = new Vector3(1.0f / (2 * 36), 1.0f / (2 * 36), 1.0f / (2 * 36));

        transform.localScale = new Vector3(0, 0, 0);

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 360; j += 10)
            {
                transform.Rotate(0, 0, 10);
                transform.localScale += scale;

                yield return time;
            }
        }
        
        transform.rotation = LookPlayer();

        yield return new WaitForSeconds(0.1f);

        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

        // Destroy함수도 계속해서 실행되면 파괴되는 시간이 계속해서 초기화된다.
        Destroy(this.gameObject, 1);
    }

    Quaternion LookPlayer()
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position - transform.position;
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다. 확인 ㄱㄱ
        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }

}
