using UnityEngine;
using static DayNight;

public class Stars : MonoBehaviour, IDayNightObserver
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        FindObjectOfType<DayNight>().RegisterObserver(this);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDayNightChange(float currentPhase)
    {
        if (currentPhase < 1f || currentPhase > 3f)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else
        {
            float alpha = Mathf.Lerp(1f, 0f, (currentPhase - 1f) / 2f);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }
}