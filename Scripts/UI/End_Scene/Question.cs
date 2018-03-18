using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Question : MonoBehaviour {

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

        if(Input.GetKeyDown("z"))
        {
            SceneManager.LoadScene("Scene_Main");

            gameObject.SetActive(false);
        }
    }
}
