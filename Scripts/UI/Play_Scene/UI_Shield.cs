using UnityEngine;
using System.Collections;

public class UI_Shield : MonoBehaviour {
    
    float max_HP;
    float now_HP;
    float persentage_HP;

    Vector3 vector;

	// Use this for initialization
	void Start () {
        max_HP = Shield.HP;
        now_HP = max_HP;
	}
	
	// Update is called once per frame
	void Update () {
        now_HP = Shield.HP;

        SetHP();
	}

    void SetHP()
    {
        persentage_HP = now_HP / max_HP;

        vector.Set(persentage_HP, transform.localScale.y, transform.localScale.z);

        transform.localScale = vector;
    }
}
