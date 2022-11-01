using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningHowToProgram : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player bob = new Player("bob", 8, 5);
        bob.stats();
        test();
    }

    // Update is called once per frame
    void test()
    {
        Debug.Log("helloworld"); 
    }
}
