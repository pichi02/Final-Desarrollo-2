using UnityEngine;
using System;

namespace TankGame
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private float time;
        public Action<float> OnTimeChange;
        public Action OnTimeFinish;

        private bool canUpdateTime = true;
        void Update()
        {
            if (canUpdateTime)
            {
                OnTimeChange?.Invoke(time);
                if (time > 0.0f)
                    time -= Time.deltaTime;
                else
                    OnTimeFinish?.Invoke();
            }

        }
        public void DisableCanUpdateTime()
        {
            canUpdateTime = false;
        }
    }
}
