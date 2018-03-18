using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Bullet_Final_Pattern1_1_R : MonoBehaviour
{
    Vector3 vector;
    Quaternion rot;
    float angle;
    STATE state;
    public float speed = 20.0f;

    private void OnEnable()
    {
        state = STATE.CREATE;

        vector = NextVector(4);

        transform.DOMove(vector, 1);

        Invoke("NextPhase", 1);
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.ALIVE:
                transform.Translate(0, speed * Time.deltaTime * Time.timeScale * Pattern_Enermy_Final_1.timepause, 0);
                break;
        }
    }

    Vector3 NextVector(float distance)
    {
        float angle = transform.rotation.eulerAngles.z + 90;

        // 왜인지모르겠지만 Mathf.PI*2* angle/360 이렇게가 아니라 angle이거만 해주면 이상하게나온다.
        return transform.position + new Vector3(Mathf.Cos(Mathf.PI * 2 * angle / 360) * distance, Mathf.Sin(Mathf.PI * 2 * angle / 360) * distance, 0);
    }

    void NextPhase()
    {
        state = STATE.ALIVE;
        transform.Rotate(0, 0, -90);
    }
}