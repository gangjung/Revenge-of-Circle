using UnityEngine;
using System.Collections;

public class Pattern_RounBall : MonoBehaviour
{
    public float radius = 2;
    float speed = 0.1f;

    string objName = "Bullet_RoundBall";

    Vector3 vector = new Vector3(0, 0, 0);
    Vector3[] originVector = new Vector3[4];

    void OnEnable()
    {
        StartCoroutine(RoundBall());
        radius = 2;

        transform.Find("Bullet_RoundBall1").transform.position = originVector[0];
        transform.Find("Bullet_RoundBall2").transform.position = originVector[1];
        transform.Find("Bullet_RoundBall3").transform.position = originVector[2];
        transform.Find("Bullet_RoundBall4").transform.position = originVector[3];
        
        Debug.Log(transform.Find("Bullet_RoundBall1").transform.position);
        Debug.Log(transform.Find("Bullet_RoundBall2").transform.position);
        Debug.Log(transform.Find("Bullet_RoundBall3").transform.position);
        Debug.Log(transform.Find("Bullet_RoundBall4").transform.position);
    }

    void OnDisable()
    {
       StopAllCoroutines();
    }

    // Use this for initialization
    void Awake()
    {
        originVector[0] = transform.Find("Bullet_RoundBall1").transform.position;
        originVector[1] = transform.Find("Bullet_RoundBall2").transform.position;
        originVector[2] = transform.Find("Bullet_RoundBall3").transform.position;
        originVector[3] = transform.Find("Bullet_RoundBall4").transform.position;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey("z"))
        {
            if (radius < 15.0f)
            {
                for (int i = 1; i <= 4; i++)
                {
                    objName = string.Format("Bullet_RoundBall{0}", i);
                    // transfome.positon을 하게되면 space.world의 좌표를 전송해준다. 따라서 현재 위치의 좌표로 바꿔준다.
                    vector.x = GetDistance(transform.Find(objName).transform.position.x - GameObject.Find("Player").transform.position.x);
                    vector.y = GetDistance(transform.Find(objName).transform.position.y - GameObject.Find("Player").transform.position.y);
                    transform.Find(objName).transform.position += vector;
                }
                radius += speed;
            }
        }
        else if(Input.GetKey("x"))
        {
            if (radius > 2.0f)
            {
                for (int i = 1; i <= 4; i++)
                {
                    objName = string.Format("Bullet_RoundBall{0}", i);
                    // transfome.positon을 하게되면 space.world의 좌표를 전송해준다. 따라서 현재 위치의 좌표로 바꿔준다.
                    vector.x = GetDistance(transform.Find(objName).transform.position.x - GameObject.Find("Player").transform.position.x);
                    vector.y = GetDistance(transform.Find(objName).transform.position.y - GameObject.Find("Player").transform.position.y);
                    transform.Find(objName).transform.position -= vector;
                }
                radius -= speed;
            }
        }
	}

    IEnumerator RoundBall()
    {
        Quaternion temp = this.transform.rotation;

        Vector3 rotate = new Vector3(0, 0, -10);

        WaitForSeconds time = new WaitForSeconds(0.01f);

        while (true)
        {
            this.transform.Rotate(rotate * Pattern_Enermy_Final_1.timepause);

            yield return time;
        }
    }

    float GetDistance(float value)
    {
        return value * speed / radius;
    }
}
