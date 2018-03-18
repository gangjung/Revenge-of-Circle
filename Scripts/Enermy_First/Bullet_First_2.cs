using UnityEngine;
using System.Collections;

public class Bullet_First_2 : MonoBehaviour {

    private Bullet _bullet;
    private float _speed;

    // Use this for initialization
    void Start()
    {
        _bullet = transform.GetComponent<Bullet>();
        _bullet.SetName("Bullet_First_2");
        _speed = _bullet.speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }
}
