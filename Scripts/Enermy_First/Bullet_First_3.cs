using UnityEngine;
using System.Collections;
using System.Threading;

public class Bullet_First_3 : MonoBehaviour
{
    private BulletPool_Enermy _bulletPool;
    private Bullet _bullet;
    private IEnumerator coroutine;
    private float _speed;
    private bool isReady;

    void OnEnable()
    {
        if (isReady == false)
        {
            init();
            
            return;
        }

        transform.Find("image").gameObject.SetActive(true);
        _speed = _bullet.speed;

        coroutine = Boom();
        StartCoroutine(coroutine);

        GameManager.OnBulletClear += BulletClear;
    }

    void OnDisable()
    {
        GameManager.OnBulletClear -= BulletClear;
    }

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, _speed * Time.deltaTime, 0);
	}

    private void init()
    {
        _bullet = transform.GetComponent<Bullet>();
        _bullet.SetName("Bullet_First_3");
        _speed = _bullet.speed;

        isReady = true;
    }

    Quaternion LookPlayer()
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position -transform.position;
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다. 확인 ㄱㄱ
        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }

    IEnumerator Boom()
    {
        Quaternion quaterToPlayer;
        WaitForSeconds time = new WaitForSeconds(0.01f);
        GameObject temp;

        _bulletPool = BulletPool_Enermy.instance;

        yield return new WaitForSeconds(1);

        // 얼음덩이의 child로 고드름이 생성되기에 일단 보이지 않게만 해놨다.
        _speed = 0;
        transform.Find("image").gameObject.SetActive(false);

        quaterToPlayer = LookPlayer();
        transform.rotation = quaterToPlayer;

        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0, 0, Random.Range(-40, 40));

            temp = _bulletPool.PopPool(transform, "Bullet_First_3_1");
            temp.SetActive(true);

            // 랜덤 방향으로 생성한 뒤, 다시 방향 초기화
            transform.rotation = quaterToPlayer;

            yield return time;
        }

        Destroy(this.gameObject);
    }

    void BulletClear()
    {
        Destroy(this.gameObject);
    }
}
