using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    private Text fps;
    private float deltaTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fps = GetComponent<Text>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fps.text = "FPS: " + (int) (1.0f / deltaTime);
    }
}
