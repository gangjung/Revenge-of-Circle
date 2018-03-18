using UnityEngine;
using System.Collections;

public class Bullet_Second_3 : MonoBehaviour {

    public float speed;
    STATE state;

	// Use this for initialization
	void Start () {
        state = STATE.CREATE;
        speed = 10.0f;

        Invoke("move", 2);
	}
	
	// Update is called once per frame
	void Update () {
        switch(state)
        {
            case STATE.ALIVE:
                transform.Translate(0, speed * Time.deltaTime, 0);
                speed += 0.3f;
                break;
        }
	}

    void move()
    {
        state = STATE.ALIVE;
        transform.rotation = LookPlayer();
    }

    Quaternion LookPlayer()
    {
        Vector3 vectorToTarget = GameObject.Find("Player").transform.position - transform.position;
        // Mathf.Rad2Deg -> 라디안 to 각도.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // angle + 90하는 이유는 발사하는 방향이 y축이기 때문이다. 확인 ㄱㄱ
        // AngleAxis는 해당 축을 기준으로 angle만큼 이동시키겠다는 함수이다.
        return Quaternion.AngleAxis(angle - 90, transform.forward);
    }
}
