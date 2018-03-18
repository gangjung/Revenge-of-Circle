using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage;
    public float speed;

    private string _bulletName;
    private bool isDestroyed; 
    /*
     * 위의 변수를 만든 이유는, Object Pool을 사용하면서 push 될 때,
     * 배경화면을 벗어나면 되도록 해놨는데, 중간에 Destroy되는 것도 벗어난다고 판단되서
     * pushPool되기 때문이다... 그래서 이걸 만들었음.
    */

	// Use this for initialization
	void Start () {
        isDestroyed = false;
	}
    
    public string GetName()
    {
        return _bulletName;
    }

    public void SetName(string name)
    {
        _bulletName = name;
    }

    public void PushPool()
    {
        BulletPool_Enermy.instance.PushPool(_bulletName, this.gameObject);
    }

    public void PushPool_Player()
    {
        BulletPool_Player.instance.PushPool(_bulletName, this.gameObject);
    }

    public void OnDestroy()
    {
        isDestroyed = true;
    }
}
