using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SpecialAttack_Second : MonoBehaviour
{
    GameObject bullet;

    point pos_player;
    public GameObject player;

    Vector3 pos_origin;
    Vector3[] distance_block = new Vector3[2];
    Vector3[] point_Attack = new Vector3[12];
    Quaternion[] rot = new Quaternion[4];

    public GameObject ptc_Destroy;
    public GameObject ptc_Destroy_Enermy;

    int rand_pos1;
    int rand_pos2;

    void OnEnable()
    {
        bullet = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_Second("Bullet_Second_Special");

        GameManager.timepause_special = 0;

        pos_origin = player.transform.position;

        pos_player.x = 0;
        pos_player.y = 0;
        distance_block[0] = new Vector3(3, 0, 0);
        distance_block[1] = new Vector3(0, 3, 0);
        player.transform.DOMove(new Vector3(0, 0, 0), 0.5f);
        player.GetComponent<Collider2D>().enabled = true;


        StartCoroutine(Attack());


    }

    // Use this for initialization
    void Awake()
    {
        point_Attack[0] = new Vector3(-3, 6, 0);
        point_Attack[1] = new Vector3(0, 6, 0);
        point_Attack[2] = new Vector3(3, 6, 0);
        point_Attack[3] = new Vector3(6, 3, 0);
        point_Attack[4] = new Vector3(6, 0, 0);
        point_Attack[5] = new Vector3(6, -3, 0);

        point_Attack[6] = new Vector3(3, -6, 0);
        point_Attack[7] = new Vector3(0, -6, 0);
        point_Attack[8] = new Vector3(-3, -6, 0);
        point_Attack[9] = new Vector3(-6, -3, 0);
        point_Attack[10] = new Vector3(-6, 0, 0);
        point_Attack[11] = new Vector3(-6, 3, 0);

        rot[0] = Quaternion.Euler(0, 0, 0);
        rot[1] = Quaternion.Euler(0, 0, 90);
        rot[2] = Quaternion.Euler(0, 0, 180);
        rot[3] = Quaternion.Euler(0, 0, 270);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void Clear()
    {
        GameManager.instance.PlaySound_Explosion();
        GameManager.instance.Play_Destroy();
        Instantiate(ptc_Destroy_Enermy, new Vector3(0, 13, 0), Quaternion.identity);

        GameObject.Find("Player").transform.DOMove(pos_origin, 0.5f);
        GameObject.Find("All_Enermy").transform.Find("Enermy_Second").GetComponent<Enermy_Second>().HP -= 1000;

        GameManager.timepause_special = 1;

        PatternManager_Enermy_Second.runRoutin_Second = false;
        GameObject.Find("All_Enermy").transform.Find("Enermy_Second").GetComponent<PatternManager_Enermy_Second>().enabled = false;

        this.gameObject.SetActive(false);
    }

    public void Fail()
    {
        Instantiate(ptc_Destroy, player.transform.position, Quaternion.identity);
        GameManager.instance.PlaySound_Explosion();
        GameObject.Find("Player").GetComponent<Player>().state = STATE.DIE;

        GameManager.timepause_special = 1;

        PatternManager_Enermy_Second.runRoutin_Second = false;
        GameObject.Find("All_Enermy").transform.Find("Enermy_Second").GetComponent<PatternManager_Enermy_Second>().enabled = false;

        this.gameObject.SetActive(false);
    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pos_player.y < 1)
            {
                pos_player.y += 1;

                player.transform.position += distance_block[1];
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pos_player.y > -1)
            {
                pos_player.y -= 1;

                player.transform.position -= distance_block[1];
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pos_player.x > -1)
            {
                pos_player.x -= 1;

                player.transform.position -= distance_block[0];
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pos_player.x < 1)
            {
                pos_player.x += 1;

                player.transform.position += distance_block[0];
            }
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < 5; i++)
        {
            rand_pos1 = Random.Range(0, 5);
            rand_pos2 = Random.Range(6, 11);

            if(rand_pos1 < 3)
            {
                Instantiate(bullet, point_Attack[rand_pos1], rot[2]);
            }
            else
            {
                Instantiate(bullet, point_Attack[rand_pos1], rot[1]);
            }

            if (rand_pos2 < 9)
            {
                Instantiate(bullet, point_Attack[rand_pos2], rot[0]);
            }
            else
            {
                Instantiate(bullet, point_Attack[rand_pos2], rot[3]);
            }

            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(1);

        Clear();
    }

    struct point
    {
        public int x, y;
    }
}
