using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title_Death_Count : MonoBehaviour {

    public int size = 3;
    Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();

        Invoke("Next", 1);
    }

    // Update is called once per frame
    void Update()
    {
        t.fontSize = Screen.height * size / 100;
    }

    void Next()
    {
        GameObject.Find("Canvas").transform.Find("Result").transform.Find("Result_Count").gameObject.SetActive(true);
    }
}
