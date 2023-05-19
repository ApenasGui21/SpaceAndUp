using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progresso : MonoBehaviour
{
    private Slider slider;

    private float targetProgress = 0;

    private void Awake() 
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IncrementoProgresso(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
            slider.value = ScoreManager.score / 4000;
    }

    void IncrementoProgresso(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
