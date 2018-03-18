using UnityEngine;
using System.Collections;

enum OBJECT { PLAYER, ENERMY_WEAK }

public class FireCtrl : MonoBehaviour
{

    public GameObject Bullet;
    public Transform firePos;
    public Transform firePos2;
    public Transform firePos3;
    public GameObject shield;
    WEAPON weapon;
    float nowTime = 0.0f;

    private BulletPool_Player _bulletPool;

    // Use this for initialization
    void Start()
    {
        weapon = GameObject.Find("Player").GetComponent<Player>().weapon;
        shield.GetComponent<CircleCollider2D>().enabled = false;
        shield.transform.Find("shield").gameObject.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        switch (weapon)
        {
            case WEAPON.NORMAL:
                {
                    nowTime += Time.deltaTime;

                    if (nowTime > 0.1)
                    {
                        nowTime = 0;
                        if (Input.GetKey("z"))
                        {
                            Fire();
                        }
                    }
                }
                break;
        }

        if (Input.GetKey("a") || Input.GetKeyUp("a"))
            Shield();
    }

    void Shield()
    {
        if (shield.GetComponent<Shield>().state == SHIELD.NORMAL)
        {
            // keydown으로 하고싶었으나 새로 태어났을 대에도 계속해서 쉴드를 눌러주는 경우가 발생할 수 있기 때문에 그것을 방지하기 위해서 이걸로 바꾸었다.
            if (Input.GetKey("a"))
            {

                GameObject.Find("Player").GetComponent<Player>().isNotShield = 0;
                // 방어막과 플레이어의 충돌 처리 거리가 거의 차이가 안나서 0으로 줄여줬다.
                GameObject.Find("Player").GetComponent<CircleCollider2D>().enabled = false;

                shield.GetComponent<CircleCollider2D>().enabled = true;
                shield.transform.Find("shield").gameObject.SetActive(true);
            }
            else if (Input.GetKeyUp("a"))
            {
                GameObject.Find("Player").GetComponent<Player>().isNotShield = 1;
                GameObject.Find("Player").GetComponent<CircleCollider2D>().enabled = true;
                shield.GetComponent<CircleCollider2D>().enabled = false;
                shield.transform.Find("shield").gameObject.SetActive(false);
            }
        }
    }

    void Fire()
    {
        CreateBullet();
    }

    void CreateBullet()
    {
        GameObject temp;

        if (_bulletPool == null)
            _bulletPool = BulletPool_Player.instance;   

        temp = _bulletPool.PopPool(firePos, "Bullet_Normal");
        temp.SetActive(true);

        temp = _bulletPool.PopPool(firePos2, "Bullet_Normal");
        temp.SetActive(true);
        firePos2.Rotate(0, 0, -45);

        temp = _bulletPool.PopPool(firePos2, "Bullet_Normal");
        temp.SetActive(true);
        firePos2.Rotate(0, 0, 45);

        temp = _bulletPool.PopPool(firePos3, "Bullet_Normal");
        temp.SetActive(true);
        firePos3.Rotate(0, 0, 45);

        temp = _bulletPool.PopPool(firePos3, "Bullet_Normal");
        temp.SetActive(true);
        firePos3.Rotate(0, 0, -45);
    }
}
