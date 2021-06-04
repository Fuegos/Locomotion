using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GUIController : MonoBehaviour
{
    public GameObject TimerText;
    public GameObject CountPersonal;
    public GameObject CountEvolution;

    public GameObject TitlePrevEvolution;
    public GameObject BestTimeLifePrevText;
    public GameObject BestDistancePrevText;
    public GameObject AvgTimeLifePrevText;
    public GameObject AvgDistancePrevText;

    public GameObject TitleTwoPrevEvolution;
    public GameObject BestTimeLifeTwoPrevText;
    public GameObject BestDistanceTwoPrevText;
    public GameObject AvgTimeLifeTwoPrevText;
    public GameObject AvgDistanceTwoPrevText;

    public Slider speedSlider;

    private float BestTimeLifePrev = -1;
    private float BestDistancePrev = -1;
    private float AvgTimeLifePrev = -1;
    private float AvgDistancePrev = -1;

    private float BestTimeLifeTwoPrev = -1;
    private float BestDistanceTwoPrev = -1;
    private float AvgTimeLifeTwoPrev = -1;
    private float AvgDistanceTwoPrev = -1;

    private float BestTimeLifeThreePrev = -1;
    private float BestDistanceThreePrev = -1;
    private float AvgTimeLifeThreePrev = -1;
    private float AvgDistanceThreePrev = -1;

    public TimerGUI timerGUI = new TimerGUI();

    void Start()
    {
        StartingTimerGUI();
        UpdateCountPersonal();
        UpdatePrevEvolution();
    }

    public void SpeedTime()
    {
        Time.timeScale = speedSlider.value;
        Debug.Log(Time.timeScale);
    }

    public void StartingTimerGUI()
    {
        CancelInvoke();
        InvokeRepeating("UpdateTimerGUI", 0, 1);
    }
    
    public void UpdateTimerGUI()
    {
        timerGUI.AddSecond();
        TimerText.GetComponent<Text>().text = timerGUI.ReturnTime();
    }

    public void UpdateCountPersonal()
    {
        CountPersonal.GetComponent<Text>().text = GameObject.FindGameObjectsWithTag("Personal").Length.ToString();
    }

    public void UpdateCountEvolution(int CountEvolution, List<Entity> Population)
    {
        this.CountEvolution.GetComponent<Text>().text = CountEvolution.ToString();

        BestTimeLifeThreePrev = BestTimeLifeTwoPrev;
        BestDistanceThreePrev = BestDistanceTwoPrev;
        AvgTimeLifeThreePrev = AvgTimeLifeTwoPrev;
        AvgDistanceThreePrev = AvgDistanceTwoPrev;

        BestTimeLifeTwoPrev = BestTimeLifePrev;
        BestDistanceTwoPrev = BestDistancePrev;
        AvgTimeLifeTwoPrev = AvgTimeLifePrev;
        AvgDistanceTwoPrev = AvgDistancePrev;
        Debug.Log(Population.Count);
        BestTimeLifePrev = Population.Max(x => x.TimeLife);
        
        BestDistancePrev = Population.Max(x => x.Distance);
        AvgTimeLifePrev = Population.Average(x => x.TimeLife);
        AvgDistancePrev = Population.Average(x => x.Distance);
        TitlePrevEvolution.GetComponent<Text>().text = "Evolution " + (CountEvolution - 1).ToString();
        TitleTwoPrevEvolution.GetComponent<Text>().text = "Evolution " + (CountEvolution - 2).ToString();
        UpdatePrevEvolution();
    }

    public void UpdateEvolution()
    {
        timerGUI.ZeroingTimerGUI();
        StartingTimerGUI();
        UpdateCountPersonal();
    }

    public void UpdatePrevEvolution()
    {
        if (BestTimeLifePrev != -1 && BestTimeLifeTwoPrev != -1)
        {
            BestTimeLifePrevText.GetComponent<Text>().text = "Best Time Life    " +
                Mathf.Round(BestTimeLifePrev) + FormatDelta(Mathf.Round(BestTimeLifePrev - BestTimeLifeTwoPrev));
            BestDistancePrevText.GetComponent<Text>().text = "Best Distance    " +
                Mathf.Round(BestDistancePrev) + FormatDelta(Mathf.Round(BestDistancePrev - BestDistanceTwoPrev));
            AvgTimeLifePrevText.GetComponent<Text>().text = "Avg Time Life     " +
                Mathf.Round(AvgTimeLifePrev) + FormatDelta(Mathf.Round(AvgTimeLifePrev - AvgTimeLifeTwoPrev));
            AvgDistancePrevText.GetComponent<Text>().text = "Avg Distance     " +
                Mathf.Round(AvgDistancePrev) + FormatDelta(Mathf.Round(AvgDistancePrev - AvgDistanceTwoPrev));
        }
        else if (BestTimeLifePrev != -1 && BestTimeLifeTwoPrev == -1)
        {
            BestTimeLifePrevText.GetComponent<Text>().text = "Best Time Life    " +
                Mathf.Round(BestTimeLifePrev);
            BestDistancePrevText.GetComponent<Text>().text = "Best Distance    " +
                Mathf.Round(BestDistancePrev);
            AvgTimeLifePrevText.GetComponent<Text>().text = "Avg Time Life     " +
                Mathf.Round(AvgTimeLifePrev);
            AvgDistancePrevText.GetComponent<Text>().text = "Avg Distance     " +
                Mathf.Round(AvgDistancePrev);
        }
        else
        {
            BestTimeLifePrevText.GetComponent<Text>().text = "";
            BestDistancePrevText.GetComponent<Text>().text = "";
            AvgTimeLifePrevText.GetComponent<Text>().text = "";
            AvgDistancePrevText.GetComponent<Text>().text = "";
            TitlePrevEvolution.GetComponent<Text>().text = "";
        }

        if (BestTimeLifeTwoPrev != -1 && BestTimeLifeThreePrev != -1)
        {
            BestTimeLifeTwoPrevText.GetComponent<Text>().text = "Best Time Life    " +
                Mathf.Round(BestTimeLifeTwoPrev) + FormatDelta(Mathf.Round(BestTimeLifeTwoPrev - BestTimeLifeThreePrev));
            BestDistanceTwoPrevText.GetComponent<Text>().text = "Best Distance    " +
                Mathf.Round(BestDistanceTwoPrev) + FormatDelta(Mathf.Round(BestDistanceTwoPrev - BestDistanceThreePrev));
            AvgTimeLifeTwoPrevText.GetComponent<Text>().text = "Avg Time Life     " +
                Mathf.Round(AvgTimeLifeTwoPrev) + FormatDelta(Mathf.Round(AvgTimeLifeTwoPrev - AvgTimeLifeThreePrev));
            AvgDistanceTwoPrevText.GetComponent<Text>().text = "Avg Distance     " +
                Mathf.Round(AvgDistanceTwoPrev) + FormatDelta(Mathf.Round(AvgDistanceTwoPrev - AvgDistanceThreePrev));
        }
        else if (BestTimeLifeTwoPrev != -1 && BestTimeLifeThreePrev == -1)
        {
            BestTimeLifeTwoPrevText.GetComponent<Text>().text = "Best Time Life    " +
                Mathf.Round(BestTimeLifeTwoPrev);
            BestDistanceTwoPrevText.GetComponent<Text>().text = "Best Distance    " +
                Mathf.Round(BestDistanceTwoPrev);
            AvgTimeLifeTwoPrevText.GetComponent<Text>().text = "Avg Time Life     " +
                Mathf.Round(AvgTimeLifeTwoPrev);
            AvgDistanceTwoPrevText.GetComponent<Text>().text = "Avg Distance     " +
                Mathf.Round(AvgDistanceTwoPrev);
        }
        else
        {
            BestTimeLifeTwoPrevText.GetComponent<Text>().text = "";
            BestDistanceTwoPrevText.GetComponent<Text>().text = "";
            AvgTimeLifeTwoPrevText.GetComponent<Text>().text = "";
            AvgDistanceTwoPrevText.GetComponent<Text>().text = "";
            TitleTwoPrevEvolution.GetComponent<Text>().text = "";
        }
    }

    private string FormatDelta(float value)
    {
        if (value > 0)
        {
            return " (+" + value + ")";
        }
        return " (" + value.ToString() + ")";
    }

    public void OnApplicationQuit()
    {
        Application.Quit();   
    }
}
