using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Image : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("Next", 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Next()
    {
        GameObject.Find("Canvas").transform.Find("Result").transform.Find("Title_Death_Count").gameObject.SetActive(true);
    }
}
