using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample_GameDirector : MonoBehaviour
{
    GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text");
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = PlayerPrefs.GetInt("shim").ToString("F0");
    }
}
