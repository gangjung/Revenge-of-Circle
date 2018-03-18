using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject Bg;

    public static int timepause_special;

    WaitForSeconds time;
    WaitForSeconds time2;

    public AudioClip audio;
    AudioSource myAudio;

    void Awake()
    {
       timepause_special = 1;
    }

	// Use this for initialization
	void Start () {
        instance = this;

        time = new WaitForSeconds(0.05f);
        time2 = new WaitForSeconds(0.01f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play_Destroy()
    {
        StartCoroutine(Ani_Destroy());
    }
    IEnumerator Ani_Destroy()
    {
        Transform camera = GameObject.Find("Main Camera").transform;
        Vector3 temp = camera.position;
        float size = 0.2f;

        WaitForSeconds time = new WaitForSeconds(0.02f);

        for (int i = 0; i < 5; i++)
        {
            camera.Translate(size, 0, 0);
            yield return time;
            camera.position = temp;
            yield return time;
            camera.Translate(-size, 0, 0);
            yield return time;
            camera.position = temp;
            yield return time;

            size -= 0.02f;
        }
    }

    public void Play_Change_BG_Dark()
    {
        StartCoroutine(Change_BG_Dark());
    }

    public IEnumerator Change_BG_Dark()
    {
        Color color = Bg.GetComponent<Renderer>().material.GetColor("_TintColor");
        float unit = 1f / 255f;
        Color unit_c = new Color(unit, unit, unit, 0);

        for (int i = 0; i < 45; i++ )
        {
            color -= unit_c;

            Bg.GetComponent<Renderer>().material.SetColor("_TintColor", color);

            yield return time;
        }
    }

    public void Change_BG_Bright()
    {
        Color color = Bg.GetComponent<Renderer>().material.GetColor("_TintColor");
        float unit = 1f / 255f;
        Color unit_c = new Color(unit, unit, unit, 0);

        for (int i = 0; i < 45; i++)
        {
            color += unit_c;

            Bg.GetComponent<Renderer>().material.SetColor("_TintColor", color);
        }
    }

    public delegate void BulletClearHandler();
    public static event BulletClearHandler OnBulletClear;

    public void BulletClear()
    {
        OnBulletClear();
    }

    public void Play_WaitEnding()
    {
        StartCoroutine(WaitEnding(3));
    }

    IEnumerator WaitEnding(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Scene_End");
    }

    public void PlaySound_Explosion()
    {
        GetComponent<AudioSource>().PlayOneShot(audio, 1);
    }
}
