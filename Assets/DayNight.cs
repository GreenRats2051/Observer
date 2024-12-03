using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float dayDuration = 10f;
    private float timer;
    private List<IDayNightObserver> observers = new List<IDayNightObserver>();

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dayDuration)
        {
            timer = 0f;
        }
        NotifyObservers();
    }

    void NotifyObservers()
    {
        float phase = timer / dayDuration * 4f;
        foreach (var observer in observers)
        {
            observer.OnDayNightChange(phase);
        }
    }

    public interface IDayNightObserver
    {
        void OnDayNightChange(float currentPhase);
    }

    public void RegisterObserver(IDayNightObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(IDayNightObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
}
