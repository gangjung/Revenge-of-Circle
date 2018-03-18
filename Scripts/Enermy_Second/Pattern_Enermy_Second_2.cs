using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Pattern_Enermy_Second_2 : MonoBehaviour {

    GameObject bullet;
    public Transform firePos;
    public GameObject[,] vector = new GameObject[4, 9];

    Vector3 attackPoint;
    WaitForSeconds time;
    WaitForSeconds time2;
    WaitForSeconds time3;

    //OnEnable
    void OnEnable()
    {
        StartCoroutine(Attack());
    }
	// Use this for initialization
	void Awake () {
	    attackPoint = new Vector3(0,10,0);
        time = new WaitForSeconds(0.2f);
        time2 = new WaitForSeconds(0.03f);
        time3 = new WaitForSeconds(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    Quaternion LookPlayerFromPoint(Vector3 startPoint)
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position - startPoint;
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다. 확인 ㄱㄱ
        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }

    IEnumerator Attack()
    {
        bullet = GameObject.Find("Prefabs_Manager").GetComponent<Prefabs_Manager>().Prefabs_Get_Second("Bullet_Second_2");

        // Function

        transform.DORotate(new Vector3(0, 0, 0), 1);
        transform.DOMove(attackPoint, 1);

        yield return time3;

        for (int i = 0; i < 9; i++)
        {
            vector[0, i] = (GameObject)Instantiate(bullet, firePos.position, firePos.rotation);
            vector[0, i].transform.rotation = Quaternion.Euler(0, 0, 45);

            vector[1, i] = (GameObject)Instantiate(bullet, firePos.position, firePos.rotation);
            vector[1, i].transform.rotation = Quaternion.Euler(0, 0, 135);

            vector[2, i] = (GameObject)Instantiate(bullet, firePos.position, firePos.rotation);
            vector[2, i].transform.rotation = Quaternion.Euler(0, 0, 225);

            vector[3, i] = (GameObject)Instantiate(bullet, firePos.position, firePos.rotation);
            vector[3, i].transform.rotation = Quaternion.Euler(0, 0, 315);
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if ((i == 0) && (j % 2 == 1))
                    vector[j, i].transform.Translate(0, 1.5f, 0);
                else
                    vector[j, i].transform.Translate(0, 3, 0);

                if (i != 8)
                    vector[j, i + 1].transform.DOMove(vector[j, i].transform.position, 0.1f);
            }
            yield return time;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 270; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                vector[0, j].transform.RotateAround(firePos.position, transform.forward, -2);
                vector[2, j].transform.RotateAround(firePos.position, transform.forward, -2);

                vector[1, j].transform.RotateAround(firePos.position, transform.forward, 2);
                vector[3, j].transform.RotateAround(firePos.position, transform.forward, 2);
            }
            yield return time2;
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                vector[j, i].transform.rotation = LookPlayerFromPoint(vector[j, i].transform.position);
            }

            yield return time;

            for (int j = 0; j < 4; j++)
            {
                vector[j, i].GetComponent<Bullet_Second_2>().state = STATE.ALIVE;
                Destroy(vector[j, i], 2);
            }

            yield return time;
        }

        PatternManager_Enermy_Second.runRoutin_Second = false;
        GetComponent<PatternManager_Enermy_Second>().enabled = false;
        enabled = false;
    }
}
