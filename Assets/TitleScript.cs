using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject hitKeyText;

    private int time = 0;
    private bool hitKeyEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }

        time++;
        if(20 < time)
        {
            time = 0;
            hitKeyEnable = !hitKeyEnable;
            hitKeyText.SetActive(hitKeyEnable);
        }
    }
}
