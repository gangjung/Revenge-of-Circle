using UnityEngine;
using System.Collections;

public class Boss_Second_HP : MonoBehaviour {

    public GameObject boss;

    float max_HP;
    float now_HP;
    float HP_Persentage;

    Vector3 vector;

    // Use this for initialization
    void Start()
    {
        max_HP = boss.GetComponent<Enermy_Second>().HP;
        now_HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        now_HP = boss.GetComponent<Enermy_Second>().HP;

        SetHP();
    }
    void SetHP()
    {
        HP_Persentage = now_HP / max_HP;

        vector.Set(HP_Persentage, transform.localScale.y, transform.localScale.z);

        transform.localScale = vector;
    }
}
