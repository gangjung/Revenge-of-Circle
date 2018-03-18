using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    public static float HP;

    public SHIELD state;
    public GameObject Ptc;

    float nowtime = 0;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case SHIELD.NORMAL:
                if ((GameObject.Find("Player").GetComponent<Player>().isNotShield == 1) && (HP < 100))
                {
                    if(nowtime < 0.1f)
                    {
                        nowtime += Time.deltaTime;
                    }
                    else
                    {
                        nowtime = 0;
                        HP += 1;
                    }
                }
                break;
        }
    }

    public void Init()
    {
        HP = 100.0f;
        state = SHIELD.NORMAL;
        GetComponent<CircleCollider2D>().enabled = false;
        transform.Find("shield").gameObject.SetActive(false);
    }

    IEnumerator RechargeHP()
    {
        WaitForSeconds time = new WaitForSeconds(0.1f);

        while (HP < 100.0f)
        {
            HP += 2.0f;

            yield return time;
        }

        state = SHIELD.NORMAL;
    }

    // 부모 오브젝트가 rigidbody를 가지고 있고 자식 오브젝트가 rigidbody를 가지고 있지 않으면 자식 collider에 부모 trigger가 실행된다.
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("BULLET_ENERMY")
            || coll.gameObject.tag.Equals("BULLET_ENERMY_OVER_WALL"))
        {
            HP -= 20;

            Instantiate(Ptc, transform.position, transform.rotation);

            if (HP <= 0)
            {
                HP = 0;
                state = SHIELD.DISTROYED;

                GameObject.Find("Player").GetComponent<Player>().isNotShield = 1;
                GameObject.Find("Player").GetComponent<CircleCollider2D>().enabled = true;

                GetComponent<CircleCollider2D>().enabled = false;
                transform.Find("shield").gameObject.SetActive(false);

                StartCoroutine(RechargeHP());
            }
            if(coll.gameObject.tag.Equals("BULLET_ENERMY"))
                Destroy(coll.gameObject);
        }
    }
}
