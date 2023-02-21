using Unity.VisualScripting;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    private void Start()
    {
        DisableTimeScale();
    }
    public void DisableTimeScale()
    {
        Time.timeScale = 0f;
    }
    public void EnableTimeScale()
    {
        Time.timeScale = 1f;
    }
}
