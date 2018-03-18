using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool_Enermy : MonoBehaviour {

    public static BulletPool_Enermy instance;
    public Vector3 pos;

    private Dictionary<string, GameObject> _prefabs;

    [SerializeField]
    private Dictionary<string, List<GameObject>> _poolList = new Dictionary<string, List<GameObject>>();

    // Use this for initialization
    void Start()
    {
        Init(null);
    }
    
    // 한 번에 만들어 둘 것인가, 필요할 때마다 만들 것인가...
    // 일단 필요할 때 마다 만드는 방향으로 감
    private void Init(Transform parent)
    {
        instance = this;
        pos = this.transform.position;

        _prefabs = Prefabs_Manager.instance.Prefabs_Get_All();
   
        foreach(var key in _prefabs.Keys)
        {
            Debug.Log(key);
            _poolList.Add(key, new List<GameObject>());
        }
    }

    // 부모를 잘 설정해줘야 한다. 왜나햐면, Instantiate할 때, Transform되는 곳의 자식으로 들어가기 때문이다.
    public GameObject CreateObject(Transform parent, string key)
    {
        GameObject temp = Instantiate(_prefabs[key], parent);

        temp.SetActive(false);

        return temp;
    }
  
    public void PushPool(Transform parent, string key, GameObject gameObject)
    {
        gameObject.transform.position = pos;
        gameObject.SetActive(false);

        _poolList[key].Add(gameObject);
    }

    public void PushPool(string key, GameObject gameObject)
    {
        gameObject.transform.position = pos;
        gameObject.SetActive(false);

        _poolList[key].Add(gameObject);
    }

    
    public GameObject PopPool(Transform parent, string key)
    {
        if (_poolList[key].Count == 0)
            _poolList[key].Add(CreateObject(this.transform, key));

        GameObject temp = _poolList[key][0];

        temp.transform.position = parent.position;
        temp.transform.rotation = parent.rotation;

        _poolList[key].RemoveAt(0);

        return temp;
    }

    public GameObject PopPool(Vector3 pos, Quaternion rot, string key)
    {
        if (_poolList[key].Count == 0)
            _poolList[key].Add(CreateObject(this.transform, key));

        GameObject temp = _poolList[key][0];
        temp.transform.position = pos;
        temp.transform.rotation = rot;

        _poolList[key].RemoveAt(0);

        return temp;
    }

    public void ClearObject(string number)
    {
        if (number.Equals("First"))
            Invoke("ClearPoolFirst", 2);
        else if(number.Equals("Second"))
            Invoke("ClearPoolSecond", 2);
        else if (number.Equals("Final"))
            Invoke("ClearPoolFinal", 2);
    }

    public void ClearPoolFirst()
    {
        foreach(GameObject temp in _poolList["Bullet_First_1"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_First_2"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_First_3"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_First_3_1"])
        {
            Destroy(temp);
        }
        _poolList.Remove("Bullet_First_1");
        _poolList.Remove("Bullet_First_2");
        _poolList.Remove("Bullet_First_3");
        _poolList.Remove("Bullet_First_3_1");
    }
    public void ClearPoolSecond()
    {
        _poolList.Remove("Bullet_Second_2");
        _poolList.Remove("Bullet_Second_3");
        _poolList.Remove("Bullet_Second_Sphere");
    }
    public void ClearPoolFinal()
    {
        foreach (GameObject temp in _poolList["Bullet_Final_1_1"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_Final_1_1_L"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_Final_1_1_R"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_Final_1_2_1"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_Final_1_2_2"])
        {
            Destroy(temp);
        }
        foreach (GameObject temp in _poolList["Bullet_Final_1_3"])
        {
            Destroy(temp);
        }

        _poolList.Remove("Bullet_Final_1_1");
        _poolList.Remove("Bullet_Final_1_1_L");
        _poolList.Remove("Bullet_Final_1_1_R");
        _poolList.Remove("Bullet_Final_1_2_1");
        _poolList.Remove("Bullet_Final_1_2_2");
        _poolList.Remove("Bullet_Final_1_3");
    }
}
