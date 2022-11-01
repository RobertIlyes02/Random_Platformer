using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private Text Title;
    public int killscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        Title.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatescore(int score)
    {
        Title.text = score.ToString();
    }
}
