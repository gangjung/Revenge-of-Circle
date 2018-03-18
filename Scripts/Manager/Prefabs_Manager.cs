using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Prefabs_Manager : MonoBehaviour {

    public static Prefabs_Manager instance;

    public static Dictionary<string, GameObject> _cashe_Player = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> _cashe_First = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> _cashe_Second = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> _cashe_Final = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> _cashe_Enermy_weak = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> _cashe_All = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Awake () {
        instance = this;

        Prefabs_Load_Player("Player");
        Prefabs_Load_Enermy_weak("Bullet_Enermy");
        Prefabs_Load_First("Enermy_First");
        Prefabs_Load_Second("Enermy_Second");
        Prefabs_Load_Final("Enermy_Final");
	}

    public void Prefabs_Load_Player(string subfolder)
    {
        object[] temp = Resources.LoadAll(subfolder);

        GameObject temp2;

        for (int i = 0; i < temp.Length; i++)
        {
            temp2 = (GameObject)temp[i];

            _cashe_Player[temp2.name] = temp2;
            _cashe_All[temp2.name] = temp2;
        }
    }
    public void Prefabs_Load_Enermy_weak(string subfolder)
    {
        object[] temp = Resources.LoadAll(subfolder);

        GameObject temp2;

        for (int i = 0; i < temp.Length; i++)
        {
            temp2 = (GameObject)temp[i];

            _cashe_Enermy_weak[temp2.name] = temp2;
            _cashe_All[temp2.name] = temp2;
        }
    }
    public void Prefabs_Load_First(string subfolder)
    {
        object[] temp = Resources.LoadAll(subfolder);

        GameObject temp2;

        for (int i = 0; i < temp.Length; i++)
        {
            temp2 = (GameObject)temp[i];

            _cashe_First[temp2.name] = temp2;
            _cashe_All[temp2.name] = temp2;
        }
    }
    public void Prefabs_Load_Second(string subfolder)
    {
        object[] temp = Resources.LoadAll(subfolder);

        GameObject temp2;

        for (int i = 0; i < temp.Length; i++)
        {
            temp2 = (GameObject)temp[i];

            _cashe_Second[temp2.name] = temp2;
            _cashe_All[temp2.name] = temp2;
        }
    }
    public void Prefabs_Load_Final(string subfolder)
    {
        object[] temp = Resources.LoadAll(subfolder);

        GameObject temp2;

        for (int i = 0; i < temp.Length; i++)
        {
            temp2 = (GameObject)temp[i];

            _cashe_Final[temp2.name] = temp2;
            _cashe_All[temp2.name] = temp2;
        }
    }

    public GameObject Prefabs_Get_Player(string key)
    {
        return _cashe_Player[key];
    }
    public GameObject Prefabs_Get_Enermy_weak(string key)
    {
        return _cashe_Enermy_weak[key];
    }
    public GameObject Prefabs_Get_First(string key)
    {
        return _cashe_First[key];
    }
    public GameObject Prefabs_Get_Second(string key)
    {
        return _cashe_Second[key];
    }
    public GameObject Prefabs_Get_Final(string key)
    {
        return _cashe_Final[key];
    }

    public Dictionary<string, GameObject> Prefabs_Get_Player_All()
    {
        return _cashe_Player;
    }
    public Dictionary<string, GameObject> Prefabs_Get_Final_All()
    {
        return _cashe_Final;
    }
    public Dictionary<string, GameObject> Prefabs_Get_All()
    {
        return _cashe_All;
    }

    public void Remove_Player(params string[] arg)
    {
        string key;
        for (int i = 0; i < arg.Length; i++)
        {
            key = arg[i];
            _cashe_Player.Remove(key);
        }
    }
    public void Remove_Enermy_weak(params string[] arg)
    {
        string key;
        for (int i = 0; i < arg.Length; i++)
        {
            key = arg[i];
            _cashe_Enermy_weak.Remove(key);
        }
    }
    public void Remove_First(params string[] arg)
    {
        string key;
        for (int i = 0; i < arg.Length; i++)
        {
            key = arg[i];
            _cashe_First.Remove(key);
        }
    }
    public void Remove_Second(params string[] arg)
    {
        string key;
        for (int i = 0; i < arg.Length; i++)
        {
            key = arg[i];
            _cashe_Second.Remove(key);
        }
    }
    public void Remove_Final(params string[] arg)
    {
        string key;
        for (int i = 0; i < arg.Length; i++)
        {
            key = arg[i];
            _cashe_Final.Remove(key);
        }
    }
}
