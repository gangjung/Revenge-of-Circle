using UnityEngine;
using System.Collections;

public class Sound_Manager_BGM : MonoBehaviour {

    public AudioClip Menu;

    public AudioClip First_BGM;
    public AudioClip Second_BGM;
    public AudioClip Final_BGM;

    public AudioClip Ending;

    public static Sound_Manager_BGM instance;

    AudioSource myAudio;
	// Use this for initialization
    void Awake()
    {
        Sound_Manager_BGM.instance = this;
    }
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound_Menu()
    {
        myAudio.PlayOneShot(Menu);
    }

    public void PlaySound_First_BGM()
    {
        myAudio.PlayOneShot(First_BGM);
    }

    public void PlaySound_Second_BGM()
    {
        myAudio.PlayOneShot(Second_BGM);
    }

    public void PlaySound_Final_BGM()
    {
        myAudio.PlayOneShot(Final_BGM);
    }

    public void PlaySound_Ending()
    {
        myAudio.PlayOneShot(Ending);
    }
}
