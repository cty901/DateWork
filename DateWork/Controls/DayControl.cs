﻿using DateWork.Heplers;
using DateWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DateWork.Controls
{
    public class DayControl : Control
    {
        static DayControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DayControl), new FrameworkPropertyMetadata(typeof(DayControl)));
        }

        #region Day DependencyProperty
        public DateTime Day
        {
            get { return (DateTime)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }
        public static readonly DependencyProperty DayProperty =
                DependencyProperty.Register("Day", typeof(DateTime), typeof(DayControl),
                new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(DayControl.OnDayPropertyChanged)));

        private static void OnDayPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is DayControl)
            {
                (obj as DayControl).OnDayValueChanged();
            }
        }

        protected void OnDayValueChanged()
        {
            RefreshDayName();
            RefreshMonthDayName();
            RefreshBackground();
        }
        #endregion

        #region DayName DependencyProperty
        public string DayName
        {
            get { return (string)GetValue(DayNameProperty); }
            set { SetValue(DayNameProperty, value); }
        }
        public static readonly DependencyProperty DayNameProperty =
                DependencyProperty.Register("DayName", typeof(string), typeof(DayControl),
                new PropertyMetadata(null, new PropertyChangedCallback(DayControl.OnDayNamePropertyChanged)));

        private static void OnDayNamePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is DayControl)
            {
                (obj as DayControl).OnDayNameValueChanged();
            }
        }

        protected void OnDayNameValueChanged()
        {

        }

        private void RefreshDayName()
        {
            DayName = Day.Day.ToString();
        }
        #endregion

        #region MonthDayName DependencyProperty
        public string MonthDayName
        {
            get { return (string)GetValue(MonthDayNameProperty); }
            set { SetValue(MonthDayNameProperty, value); }
        }
        public static readonly DependencyProperty MonthDayNameProperty =
                DependencyProperty.Register("MonthDayName", typeof(string), typeof(DayControl),
                new PropertyMetadata(null, new PropertyChangedCallback(DayControl.OnMonthDayNamePropertyChanged)));

        private static void OnMonthDayNamePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is DayControl)
            {
                (obj as DayControl).OnMonthDayNameValueChanged();
            }
        }

        protected void OnMonthDayNameValueChanged()
        {

        }

        private void RefreshMonthDayName()
        {
            MonthDayName = MonthDayHelper.GetMonthDateTime(Day);
        }
        #endregion

        private void RefreshBackground()
        {
            var now = DateTime.Now;
            if (Day.Year == now.Year && Day.Month == now.Month && Day.Day == now.Day)
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25ad5e"));
            }
            else
            {
                if (Day.Year == AppModel.Current.Year && Day.Month == AppModel.Current.Month)
                {
                    Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0F0F0"));
                }
            }
        }


    }
}