﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DateWork.Helpers
{
    public class WindowDrag : DependencyObject
    {
        #region CanDrag DependencyProperty 
        public static readonly DependencyProperty CanDragProperty =
                DependencyProperty.RegisterAttached(
                    "CanDrag",
                    typeof(bool),
                    typeof(WindowDrag),
                    new PropertyMetadata(false, OnCanDragChanged));

        private static void OnCanDragChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is Window)
            {
                BindWindow(d as Window);
            }
        }

        public static bool GetCanDrag(UIElement obj)
        {
            return (bool)obj.GetValue(CanDragProperty);
        }

        public static void SetCanDrag(UIElement obj, bool value)
        {
            obj.SetValue(CanDragProperty, value);
        }
        #endregion

        private static void BindWindow(Window window)
        {
            if (!GetCanDrag(window))
            {
                return;
            }
            window.MouseLeftButtonDown += Window_MouseLeftButtonDown;
            window.Closed += Window_Closed;
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            var window = sender as Window;
            window.MouseLeftButtonDown -= Window_MouseLeftButtonDown;
            window.Closed -= Window_Closed;
        }

        private static void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //编辑文本框，失去焦点后，会提示错误鼠标左键没有按下不能DargMove,所以加了一个判断
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                (sender as Window).DragMove();
            }
        }
    }
}
