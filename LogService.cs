namespace JDR;

using System;
using System.Collections.Generic;

public class LogService
{
    private readonly List<string> _logs = new List<string>();
    private const int MaxLogCount = 30;

    public event Action OnLogUpdated;

    public void Log(string message)
    {
        _logs.Add(message);
        
        if (_logs.Count > MaxLogCount)
        {
            _logs.RemoveAt(0);
        }

        OnLogUpdated?.Invoke();
    }

    public IEnumerable<string> GetLogs() => _logs;
}