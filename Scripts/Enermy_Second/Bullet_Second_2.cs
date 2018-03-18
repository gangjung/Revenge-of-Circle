using UnityEngine;
using System.Collections;

public class Bullet_Second_2 : MonoBehaviour
{
    public STATE state;
    public float speed = 50.0f;

    // Use this for initialization
    void Start()
    {
        state = STATE.CREATE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.ALIVE:
                transform.Translate(0, speed * Time.deltaTime, 0);
                break;
        }
    }
}
