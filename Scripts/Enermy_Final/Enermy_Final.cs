using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enermy_Final : MonoBehaviour {

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
        switch (state)
        {
            case STATE.WAIT:
                {
                    if (nowtime > 1)
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

                        GameObject.Find("Canvas").transform.Find("Boss_Final_HP").gameObject.SetActive(true);

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

                    GameObject.Find("Canvas").transform.Find("Boss_Final_HP").gameObject.SetActive(false);

                    GameManager.instance.Play_WaitEnding();

                    Destroy(this.gameObject);
                }
                break;
        }
    }

    void Fire()
    {
        GetComponent<PatternManager_Enermy_Final>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag.Equals("BULLET"))
        {
            HP -= coll.gameObject.GetComponent<Bullet_Normal>().GetDamage();

            Instantiate(ptc, transform.position, transform.rotation);

            Destroy(coll.gameObject);
            
            if (HP < 0)
            {
                Destroy(transform.Find("BulletPool_Final").gameObject);

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

            Instantiate(ptc, transform.position, transform.rotation);

            if (HP < 0)
            {
                Instantiate(ptc_Destroy, transform.position, transform.rotation);
                state = STATE.DIE;
            }
        }
    }
}
