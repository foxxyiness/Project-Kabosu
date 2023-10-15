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
    public float timerTick;
    public int getTotalDays => _totalDays;
    public float getClampHour => clampHour;

    public bool doFastForward;
    // Start is called before the first frame update
    private void Awake()
    {
        totalMin = 1440;
        timerTick = 1.5f;
    }
    //for every 1.5 seconds, subtract 1 from _totalMin

    // Update is called once per frame
    private void Update()
    {
        Timer();
        if (doFastForward)
        {
            FastForward();
        }
    }

    public void FastForward()
    {
        //Debug.Log("FASTFOWRARD");
        if (totalMin > 20)
        {
            timerTick = 0.01f;
        }
        else
        {
            timerTick = 1.5f;
            doFastForward = false;
        }


    }

    private void Timer()
    {
        //Timer cycle for Day
        timer += Time.deltaTime;
        while (timer >= timerTick)
        {
            timer = 0f;
            totalMin--;
            min++;
            clampHour = 24f - (totalMin / 60f);
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
