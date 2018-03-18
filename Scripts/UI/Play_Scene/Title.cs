using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title : MonoBehaviour {
    
    public int size = 10;
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
    }
}
