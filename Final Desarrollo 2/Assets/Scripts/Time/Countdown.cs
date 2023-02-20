using UnityEngine;
using System;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float time;
    public Action<float> OnTimeChange;
    public Action OnTimeFinish;
    void Update()
    {
        OnTimeChange?.Invoke(time);
        if (time > 0.0f)
            time -= Time.deltaTime;
        else
            OnTimeFinish?.Invoke();
     
    }
}
