using UnityEngine;
using System.Collections;

using DG.Tweening;
using System.Collections.Generic;

public class PatternManager_Enermy_Final : MonoBehaviour
{

    // Declaration variables
    PHASE phase;

    public Transform firePos;

    public static bool runRoutin;

    // Use this for initialization

    void OnEnable()
    {
        if (!runRoutin)
        {
            runRoutin = true;

            switch (phase)
            {
                case PHASE.ONE:
                    GetComponent<Pattern_Enermy_Final_1>().enabled = true;
                    break;
            }
        }
    }
    void Awake()
    {
        phase = PHASE.ONE;
        runRoutin = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
