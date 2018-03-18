using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public const float scrollSpeed = 0.3f;

    private Material thisMaterial;
    private BulletPool_Enermy _bulletPool;

	// Use this for initialization
	void Start () {
        thisMaterial = GetComponent<Renderer>().material;
        _bulletPool = BulletPool_Enermy.instance;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newOffset = thisMaterial.mainTextureOffset;

        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime * Pattern_Enermy_Final_1.timepause * GameManager.timepause_special));

        thisMaterial.mainTextureOffset = newOffset;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag.Equals("BULLET_PLAYER_NORMAL")){
            coll.gameObject.GetComponent<Bullet>().PushPool_Player();
        }

        if (coll.gameObject.transform.tag.Equals("BULLET")
            || coll.gameObject.transform.tag.Equals("BULLET_ENERMY"))
        {
            coll.gameObject.GetComponent<Bullet>().PushPool();
        }
    }
}
