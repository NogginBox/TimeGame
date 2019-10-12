﻿using Garsonix.TimeGame.Controls.Events;
using NodaTime;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public interface IGameClocksPanel
    {
        event EventHandler<TimeChosenEventArgs> TimeClicked;

        void SetClockTimes(IList<LocalTime> times);

        void SetQuestionTime(LocalTime time);

        View View { get; }
    }

}