using UnityEngine;
using static DayNight;

public class Sky : MonoBehaviour, IDayNightObserver
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        FindObjectOfType<DayNight>().RegisterObserver(this);
    }

    public void OnDayNightChange(float currentPhase)
    {
        Color skyColor;

        if (currentPhase < 1f)
        {
            skyColor = Color.Lerp(new Color(0.1f, 0.1f, 0.3f), Color.yellow, currentPhase);
        }
        else if (currentPhase < 2f)
        {
            skyColor = Color.Lerp(Color.yellow, Color.blue, currentPhase - 1f);
        }
        else if (currentPhase < 3f)
        {
            skyColor = Color.Lerp(Color.blue, new Color(1f, 0.5f, 0.2f), currentPhase - 2f);
        }
        else
        {
            skyColor = Color.Lerp(new Color(1f, 0.5f, 0.2f), new Color(0.1f, 0.1f, 0.3f), currentPhase - 3f);
        }

        mainCamera.backgroundColor = skyColor;
    }
}