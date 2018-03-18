using UnityEngine;
using System.Collections;

public class Bullet_Normal : MonoBehaviour {

    private Bullet _bullet;
    private float _speed;
    private float _damage;

    // Use this for initialization
    void Start () {
        // 이것을 써주게 되면 가끔 총알이 적과 충돌해서 튕겨저 나가는 현상이 있기에
        // 그러한 충돌 물리 법칙을 없애주기 위해 transform으로 총알을 움직여 준다.
        // start()에서만 써주는 것이므로 time으로 count할 수 없다.

        _bullet = transform.GetComponent<Bullet>();
        _bullet.SetName("Bullet_Normal");
        _speed = _bullet.speed;
        _damage = _bullet.damage;
    }
	
	// Update is called once per frame
	void Update () {
       this.gameObject.transform.Translate(0, _speed*Time.deltaTime*Pattern_Enermy_Final_1.timepause, 0);
	}

    public float GetDamage()
    {
        return _damage;
    }
}
