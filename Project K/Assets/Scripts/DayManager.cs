using Orders;
using UnityEngine;

//[ExecuteInEditMode]
public class DayManager : MonoBehaviour
{
    [SerializeField] 
    private OrderManager orderManager;

    [SerializeField]
    private int totalMin;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float hour, clampHour;
    [SerializeField]
    private int min;

    private int _totalDays;
    
    public int getTotalDays => _totalDays;
    public float getClampHour => clampHour;
    // Start is called before the first frame update
    private void Awake()
    {
        totalMin = 1440;
    }
    //for every 1.5 seconds, subtract 1 from _totalMin

    // Update is called once per frame
    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        //Timer cycle for Day
        timer += Time.deltaTime;
        while (timer >= 1.5f)
        {
            timer = 0f;
            totalMin--;
            min++;
            clampHour = 24f - ((float)totalMin / 60f);
            hour = Mathf.Floor(clampHour);
        }
        DayTime();
    }
    private void DayTime()
    {
        //Resets Minute and add Hour
        if (min >= 60)
        {
            min = 0;
        }

        //Resets Day and Hour
        if (hour < 24) return;
        //hour = 0;
        totalMin = 1440;
        AddDay();
    }

    private void AddDay()
    {
        //Adds day and checks and iterates difficulty
        _totalDays++;
        if (_totalDays % 3 == 0 && orderManager.getCurrentState == OrderManager.Difficulty.VeryHard)
        {
            orderManager.AddDifficulty();
        }
        StartCoroutine(orderManager.StartOfDay());
    }
}