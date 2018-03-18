using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Story1 : MonoBehaviour {

    public int size = 10;
    Text t;

    public AudioClip Click;
    AudioSource myAudio;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        t.fontSize = Screen.height * size / 100;

        if(Input.GetKeyDown("z"))
        {
            GameObject.Find("Canvas").transform.Find("Story2").gameObject.SetActive(true);
        }
    }
}
