using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Story_End : MonoBehaviour {

    public int size = 3;
    Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.fontSize = Screen.height * size / 100;

        if (Input.GetKeyDown("c"))
        {
            GameObject.Find("Canvas").transform.Find("Result").gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
