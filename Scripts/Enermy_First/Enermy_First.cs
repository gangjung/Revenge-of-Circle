using UnityEngine;
using System.Collections;

public class Enermy_First : MonoBehaviour
{

    public float HP = 2000;
    public float speed = 4.0f;
    public STATE state;
    public PHASE phase;
    public GameObject ptc;
    public GameObject ptc_Destroy;

    float nowtime = 0;

    // Use this for initialization
    void Start()
    {
        state = STATE.WAIT;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            state = STATE.DIE;

        switch (state)
        {
            case STATE.WAIT:
                {
                    if(nowtime > 1)
                    {
                        state = STATE.CREATE;

                        GameManager.instance.Play_Change_BG_Dark();
                        nowtime = 0;
                    }
                    else 
                    {
                        nowtime += Time.deltaTime;
                    }
                }
                break;

            case STATE.CREATE:
                {
                    this.gameObject.transform.Translate(0, speed * Time.deltaTime * (-1), 0);

                    if (transform.position.y <= 8.0f)
                    {
                        GetComponent<Collider2D>().enabled = true;
                        state = STATE.ALIVE;
                    }
                }
                break;

            case STATE.ALIVE:
                {
                    if (nowtime > 1)
                    {
                        Fire();

                        nowtime = 0;
                    }
                    else
                    {
                        nowtime += Time.deltaTime;
                    }
                }
                break;

            case STATE.DIE:
                {
                    GameManager.instance.PlaySound_Explosion();

                    GameManager.instance.Play_Destroy();
                    GameManager.instance.Change_BG_Bright();

                    GameObject.Find("Canvas").transform.Find("Boss_First_HP").gameObject.SetActive(false);

                    GameObject.Find("Canvas").transform.Find("Wait_Second").gameObject.SetActive(true);

                    BulletPool_Enermy.instance.ClearObject("First");

                    Destroy(this.gameObject);
                }
                break;
        }

    }

    void Fire()
    {
        GetComponent<PatternManager_Enermy_First>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag.Equals("BULLET_PLAYER_NORMAL"))
        {
            HP -= coll.gameObject.GetComponent<Bullet_Normal>().GetDamage();

            Instantiate(ptc, coll.transform.position, coll.transform.rotation);

            Destroy(coll.gameObject);

            if (HP <= 0)
            {
                Instantiate(ptc_Destroy, transform.position, transform.rotation);
                state = STATE.DIE;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("BULLET_ROUNDBALL"))
        {
            HP -= coll.gameObject.GetComponent<Bullet_RoundBall>().damage;

            Instantiate(ptc, coll.transform.position, coll.transform.rotation);

            if (HP <= 0)
            {
                Instantiate(ptc_Destroy, transform.position, transform.rotation);
                state = STATE.DIE;
            }
        }
    }
}
