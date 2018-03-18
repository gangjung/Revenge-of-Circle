using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result_Count : MonoBehaviour
{
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

        t.text = Player.death_Count.ToString();
    }

    void Next()
    {
        GameObject.Find("Canvas").transform.Find("Result").transform.Find("Title_Rank").gameObject.SetActive(true);
    }
}
