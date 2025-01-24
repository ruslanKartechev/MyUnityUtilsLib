using System;
using TMPro;
using UnityEngine;

namespace SleepDev
{
    public class UIDateTimeTimerView : MonoBehaviour, IDateTimeTimerView 
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetTime(TimeSpan data)
        {
            _text.text = $"{data.Minutes:00}:{data.Seconds:00}";
        }
    }
}