﻿using NodaTime;
using System;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class Clock : Grid
    {
        private readonly SvgImage _clockHandHour;
        private readonly SvgImage _clockHandMinute;

        private EventHandler _click;

        public Clock()
        {
            var clockFace = new SvgImage("Garsonix.TimeGame.Content.Images.clock.svg");
            Children.Add(clockFace);

            _clockHandHour = new SvgImage("Garsonix.TimeGame.Content.Images.clock_little_hand.svg");
            Children.Add(_clockHandHour);

            _clockHandMinute = new SvgImage("Garsonix.TimeGame.Content.Images.clock_big_hand.svg");
            Children.Add(_clockHandMinute);

            Time = new LocalTime(3, 30);

            // Your label tap event
            var forgetPassword_tap = new TapGestureRecognizer();
            forgetPassword_tap.Tapped += (s, e) =>
            {
                //
                //  Do your work here.
                //
            };
            GestureRecognizers.Add(forgetPassword_tap);
        }

        public event EventHandler Clicked
        {
            add
            {
                lock (this)
                {
                    _click += value;
                    var g = new TapGestureRecognizer();
                    g.Tapped += (s, e) => _click?.Invoke(s, e);
                    GestureRecognizers.Add(g);
                }
            }
            remove
            {
                lock (this)
                {
                    _click -= value;
                    GestureRecognizers.Clear();
                }
            }
        }

        public LocalTime Time {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                _clockHandHour.Rotation = _time.Hour / 12.0 * 360.0;
                _clockHandMinute.Rotation = _time.Minute / 60.0 *360.0;
            }
        }

        private LocalTime _time;
    }
}