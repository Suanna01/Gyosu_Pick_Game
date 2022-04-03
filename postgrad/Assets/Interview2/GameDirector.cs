using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public int shim_score = 0;
    public int kim_score = 0;
    public int lee_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("shim", shim_score);
        PlayerPrefs.SetInt("kim", kim_score);
        PlayerPrefs.SetInt("lee", lee_score);
    }
}
