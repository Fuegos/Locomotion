using System.Collections;
using System.Collections.Generic;
using System;

public class TimerGUI
{
    private int seconds = -1;
    private int minutes = 0;

    public void AddSecond()
    {
        seconds++;
        CheckTime();
    }

    private void CheckTime()
    {
        if (seconds >= 60 )
        {
            minutes++;
            seconds = 0;
        }
    }

    public void ZeroingTimerGUI()
    {
        seconds = -1;
        minutes = 0;
    }

    public String ReturnTime()
    {
        return FormatTime(minutes.ToString()) + ":" + FormatTime(seconds.ToString());
    }

    private String FormatTime(String value)
    {
        if (value.Length == 1)
        {
            return "0" + value;
        }
        return value;
    }
}
