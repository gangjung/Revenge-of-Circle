using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PatternManager_Enermy_First : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public static bool runRoutin_First;

    PHASE state;
    float count_Special_Attack = 0;
    PHASE check_Random_Same;

    void OnEnable()
    {
        if(!runRoutin_First)
        {
            runRoutin_First = true;

            switch(state)
            {
                case PHASE.ONE:
                    GetComponent<Pattern_Enermy_First_1>().enabled = true;
                    check_Random_Same = PHASE.ONE;
                    break;

                case PHASE.TWO:
                    GetComponent<Pattern_Enermy_First_2>().enabled = true;
                    check_Random_Same = PHASE.TWO;
                    break;

                case PHASE.THREE:
                    GetComponent<Pattern_Enermy_First_3>().enabled = true;
                    check_Random_Same = PHASE.THREE;
                    break;

                case PHASE.SPECIAL:
                    StartSpecialAttack();
                    check_Random_Same = PHASE.SPECIAL;
                    break;
            }

            count_Special_Attack++;

            if(count_Special_Attack == 3)
            {
                state = PHASE.SPECIAL;
                count_Special_Attack = 0;
            }
            else
            {
                do
                {
                    state = (PHASE)Random.Range(0, 3);
                } while (state == check_Random_Same);
            }
        }
    }

	// Use this for initialization
	void Awake () {
        runRoutin_First = false;
        state = (PHASE)Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void StartSpecialAttack()
    {
        transform.DOMove(new Vector3(0, 10, 0), 0.5f);
        GameObject.Find("SpecialAttack").transform.Find("First").gameObject.SetActive(true);
    }
}
