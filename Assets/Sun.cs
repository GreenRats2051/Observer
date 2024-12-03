using UnityEngine;
using static DayNight;

public class Sun : MonoBehaviour, IDayNightObserver
{
    private DayNight dayNightManager;

    void Start()
    {
        dayNightManager = FindObjectOfType<DayNight>();
        dayNightManager.RegisterObserver(this);
    }

    public void OnDayNightChange(float currentPhase)
    {
        float angle = currentPhase * 90f;
        transform.position = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * 5;
    }
}