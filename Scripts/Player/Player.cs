using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static int death_Count;

    public float moveSpeed;
    public float isNotShield;
    float distanceX;
    float distanceY;
    float nowTIme;

    public STATE state;
    public WEAPON weapon;
    public GameObject ptc_Destroy;

    // Use this for initialization
    void Awake()
    {
        weapon = WEAPON.NORMAL;
        state = STATE.CREATE;
        death_Count = 0;
        nowTIme = 0;
        isNotShield = 1.0f;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.CREATE:
                {
                    InvokeRepeating("CreatePlayer", 0, 0.2f);
                    Invoke("ColliderControl", 3);
                }
                break;

            case STATE.ALIVE:
                moveControl();
                break;

            case STATE.DIE:
                {
                    if (nowTIme > 1)
                    {
                        nowTIme = 0;

                        death_Count++;

                        state = STATE.CREATE;
                    }

                    nowTIme += Time.deltaTime;
                    Init();
                }
                break;
        }
    }

    void Init()
    {
        isNotShield = 1;

        moveSpeed = 5.0f;

        GetComponentInChildren<Shield>().Init();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<FireCtrl>().enabled = false;
        GetComponent<Pattern_Player>().enabled = false;

        transform.position = new Vector3(0, -16, 0);

        // roundball에서 위치를 초기화 시켜줄 때 원본의 위치를 미리 옮겨줘야 한다. 왜냐하면 오브젝트가 활성화가 되면 player의 위치에 종속되기 때문이다.
        GetComponent<Pattern_Player>().enabled = true;
    }

    void CreatePlayer()
    {
        if (transform.position.y > -10)
        {
            CancelInvoke("CreatePlayer");

            state = STATE.ALIVE;

            moveSpeed = 15.0f;

            GetComponent<FireCtrl>().enabled = true;

        }

        transform.Translate(0, moveSpeed * Time.deltaTime * Pattern_Enermy_Final_1.timepause * GameManager.timepause_special, 0);
    }

    void ColliderControl()
    {
        GetComponent<CircleCollider2D>().enabled = true;

        // 음.. 왜인지 모르지만 기본 invoke도 cancle해주지 않으면 다음 invoke가 실행되지않는다.
        // 이러한 특징때문인지 update에서 계속 실행되어도 중복 실행되지 않는다.
        // 한 번 invoke된 함수는 오브젝트가 비활성화 되기전까진 cancel을 하지 않는이상 다시 invoke를 사용할 수 없다.
        CancelInvoke("ColliderControl");
    }

    // update안에다가 코루틴을 실행하게되면 CREATE에서 있는 frame수 만큼 코루틴이 중복실행되어 문제가 발생한다.
    // update에서 사용한다면, 따로 조건문을 둬서 실행이 되지 않도록 하던지, invoke를 사용해서 시간을 멈추자.
    IEnumerator ColliderControl(float time)
    {
        yield return new WaitForSeconds(time);

        GetComponent<CircleCollider2D>().enabled = true;
    }

    void moveControl()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6.0f;
            GetComponent<CircleCollider2D>().radius = 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 15.0f;
            GetComponent<CircleCollider2D>().radius = 0.37f;
        }

        distanceX = 0;
        distanceY = 0;

        distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed * isNotShield * Pattern_Enermy_Final_1.timepause * GameManager.timepause_special;
        distanceY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed * isNotShield * Pattern_Enermy_Final_1.timepause * GameManager.timepause_special;

        this.gameObject.transform.Translate(distanceX, distanceY, 0);

        // player의 움직임 범위 제한.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12.5f, 12.5f), Mathf.Clamp(transform.position.y, -15f, 15f), 0);
    }

    // oncollision함수는 매개변수로 collision형을 받고
    // ontriger함수는 매개변수로 collider형을 받는다.
    // 그리고 tag확인하는 방법도 다르니 주의할 것.
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("BULLET_ENERMY")
            || coll.gameObject.tag.Equals("ENERMY")
            || coll.gameObject.tag.Equals("BULLET_ENERMY_OVER_WALL")
            || coll.gameObject.tag.Equals("BULLET_ABSOLUTE_KILL"))
        {
            Instantiate(ptc_Destroy, transform.position, transform.rotation);
            GameManager.instance.PlaySound_Explosion();
            state = STATE.DIE;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag.Equals("BULLET_ENERMY")
            || coll.collider.tag.Equals("ENERMY")
            || coll.collider.tag.Equals("BULLET_ENERMY_OVER_WALL")
            || coll.collider.tag.Equals("BULLET_ABSOLUTE_KILL"))
        {
            Instantiate(ptc_Destroy, transform.position, transform.rotation);
            GameManager.instance.PlaySound_Explosion();
            state = STATE.DIE;
        }
    }
}
