using UnityEngine;
using System.Collections;

public class Sound_Manager : MonoBehaviour
{ 
    public AudioClip First_1;
    public AudioClip First_2;
    public AudioClip First_3;
    
    public AudioClip Second_1;
    public AudioClip Second_2;
    public AudioClip Second_3;

    public AudioClip Final_1;

    public AudioClip Explosion;

    public AudioClip Click;

    public static Sound_Manager instance;

    AudioSource myAudio;

    // Use this for initialization
    void Awake()
    {
        Sound_Manager.instance = this;
    }

    void start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound_First_1()
    {
        myAudio.PlayOneShot(First_1);
    }
    public void PlaySound_First_2()
    {
        myAudio.PlayOneShot(First_2);
    }
    public void PlaySound_First_3()
    {
        myAudio.PlayOneShot(First_3);
    }

    public void PlaySound_Second_1()
    {
        myAudio.PlayOneShot(Second_1);
    }
    public void PlaySound_Second_2()
    {
        myAudio.PlayOneShot(Second_2);
    }
    public void PlaySound_Second_3()
    {
        myAudio.PlayOneShot(Second_3);
    }

    
    public void PlaySound_Final_1()
    {
        myAudio.PlayOneShot(Final_1);
    }



    public void PlaySound_Explosion()
    {
        myAudio.PlayOneShot(Explosion);
    }

    public void PlaySound_Click()
    {
    }
}
