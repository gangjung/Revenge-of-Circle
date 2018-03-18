using UnityEngine;
using System.Collections;

public class Pattern_Player : MonoBehaviour
{

    public GameObject bullet;

    public Transform firePos;

    public WEAPON weapon;

    void OnEnable()
    {
        weapon = GameObject.Find("Player").GetComponent<Player>().weapon;
        
        switch(weapon)
        {
            case WEAPON.ROUNDBALL:
                this.gameObject.transform.Find("RoundBall").gameObject.SetActive(true);
                break;
        }
    }

    void OnDisable()
    {
        switch (weapon)
        {
            case WEAPON.ROUNDBALL:
                this.gameObject.transform.Find("RoundBall").gameObject.SetActive(false);
                break;
        }
    }

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
