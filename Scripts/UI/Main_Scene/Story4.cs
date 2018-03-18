using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Story4 : MonoBehaviour {

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

        if (Input.GetKeyDown("z"))
        {
            Sound_Manager.instance.PlaySound_Click();

            SceneManager.LoadScene("Scene_Play");

            gameObject.SetActive(false);
        }
    }
}
