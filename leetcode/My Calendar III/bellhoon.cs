using System;
using System.Collections.Generic;

public class MyCalendarThree
{
    private SortedDictionary<int, int> events;

    public MyCalendarThree()
    {
        events = new SortedDictionary<int, int>();
    }

    public int Book(int startTime, int endTime)
    {
        if (!events.ContainsKey(startTime))
        {
            events[startTime] = 0;
        }
        if (!events.ContainsKey(endTime))
        {
            events[endTime] = 0;
        }

        events[startTime]++;
        events[endTime]--;

        int maxBooking = 0, ongoing = 0;
        foreach (var eventCount in events.Values)
        {
            ongoing += eventCount;
            maxBooking = Math.Max(maxBooking, ongoing);
        }

        return maxBooking;
    }
}
