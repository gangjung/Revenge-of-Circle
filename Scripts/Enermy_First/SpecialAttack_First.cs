using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SpecialAttack_First : MonoBehaviour {
    public GameObject bullet_prefab;
    public GameObject bullet;
    public Transform bullet_pos;
    public GameObject arrow_prefab;
    public GameObject arrow;

    public GameObject ptc_Destroy;
    public GameObject ptc_Destroy_Enermy;

    float speed;

    int index;
    int[] answer = new int[10];

    Vector3[] direct = new Vector3[4];
    Vector3 pos_origin;
    Quaternion rot_origin;

    void OnEnable()
    {
        bullet_prefab = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_First("Bullet_First_Special");

        arrow_prefab = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_First("Arrows");

        bullet = (GameObject)Instantiate(bullet_prefab);
        bullet.transform.Translate(new Vector3(23, 0, 0));

        arrow = (GameObject)Instantiate(arrow_prefab);

        GameManager.timepause_special = 0;
        pos_origin = GameObject.Find("Player").transform.position;

        index = 0;

        GameObject.Find("Player").transform.DOMove(new Vector3(-10, 0, 0), 0.5f);

        for(int i = 0; i<10; i++)
        {
            answer[i] = Random.Range(0, 4);
            Debug.Log(answer[i]);
        }

        rot_origin = arrow.transform.rotation;

        DisplayArrow(answer[0]);
    }
	// Use this for initialization
	void Awake () {
        speed = 3;

        direct[0] = new Vector3(0, 0, 0);
        direct[1] = new Vector3(0, 0, 180);
        direct[2] = new Vector3(0, 0, 90);
        direct[3] = new Vector3(0, 0, 270);

	}
	
	// Update is called once per frame
	void Update () {
        bullet.transform.Translate(-1 * speed * Time.deltaTime,0,0);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(answer[index] == 0)
            {
                if(index == 9)
                {
                    Clear();
                }
                else
                {
                    index++;
                    DisplayArrow(answer[index]);
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (answer[index] == 1)
            {
                if (index == 9)
                {
                    Clear();
                }
                else
                {
                    index++;
                    DisplayArrow(answer[index]);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (answer[index] == 2)
            {
                if (index == 9)
                {
                    Clear();
                }
                else
                {
                    index++;
                    DisplayArrow(answer[index]);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (answer[index] == 3)
            {
                if (index == 9)
                {
                    Clear();
                }
                else
                {
                    index++;
                    DisplayArrow(answer[index]);
                }
            }
        }

        if(bullet.transform.position.x <= -1)
        {
            Fail();
        }
	}

    void Clear()
    {
        Destroy(bullet);
        Destroy(arrow);

        GameManager.instance.PlaySound_Explosion();
        GameManager.instance.Play_Destroy();
        Instantiate(ptc_Destroy_Enermy, new Vector3(0, 10, 0),Quaternion.identity);

        GameObject.Find("Player").transform.DOMove(pos_origin, 0.5f);
        GameObject.Find("All_Enermy").transform.Find("Enermy_First").GetComponent<Enermy_First>().HP -= 1000;

        GameManager.timepause_special = 1;

        PatternManager_Enermy_First.runRoutin_First = false;
        GameObject.Find("All_Enermy").transform.Find("Enermy_First").GetComponent<PatternManager_Enermy_First>().enabled = false;

        this.gameObject.SetActive(false);
    }

    void Fail()
    {
        Destroy(bullet);
        Destroy(arrow);

        Instantiate(ptc_Destroy, new Vector3(-10, 0, 0), Quaternion.identity);
        GameManager.instance.PlaySound_Explosion();
        GameObject.Find("Player").GetComponent<Player>().state = STATE.DIE;

        GameManager.timepause_special = 1;

        PatternManager_Enermy_First.runRoutin_First = false;
        GameObject.Find("All_Enermy").transform.Find("Enermy_First").GetComponent<PatternManager_Enermy_First>().enabled = false;

        this.gameObject.SetActive(false);
    }

    void DisplayArrow(int num)
    {
        if(num == 0)
        {
            // UpArrow
            arrow.transform.rotation = rot_origin;
            arrow.transform.Rotate(direct[0]);
        }
        else if (num == 1)
        {
            // DownArrow 
            arrow.transform.rotation = rot_origin;
            arrow.transform.Rotate(direct[1]);
        }
        else if (num == 2)
        {
            // LeftArrow
            arrow.transform.rotation = rot_origin;
            arrow.transform.Rotate(direct[2]);
        }
        else if (num == 3)
        {
            // RightArrow
            arrow.transform.rotation = rot_origin;
            arrow.transform.Rotate(direct[3]);
        }
    }
}

