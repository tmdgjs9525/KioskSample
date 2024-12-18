﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KioskSample.Support.UI.Units
{
    public class CustomScrollViewer : ScrollViewer
    {
        public Brush ScrollBackGround
        {
            get { return (Brush)GetValue(ScrollBackGroundProperty); }
            set { SetValue(ScrollBackGroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollBackGround.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollBackGroundProperty =
            DependencyProperty.Register("ScrollBackGround", typeof(Brush), typeof(CustomScrollViewer), 
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#262b32"))));



        private double _velocity = 0.0;
        private const double _acceleration = 0.001;
        private const double _deceleration = 0.002;
        static CustomScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomScrollViewer), new FrameworkPropertyMetadata(typeof(CustomScrollViewer)));
        }
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            double delta = (e.Delta * -1) * 0.5;

            // 속도 갱신
            _velocity += delta;

            // 가속도 및 감속도 모델 적용
            CompositionTarget.Rendering += ApplyAccelerationAndDeceleration;
        }
        private void ApplyAccelerationAndDeceleration(object? sender, EventArgs e)
        {
            // 속도 적용
            _velocity += _velocity > 0 ? -_acceleration : _acceleration;

            // 최대 최소 속도 설정
            _velocity = Math.Max(-0.5, Math.Min(0.5, _velocity));

            // 스크롤 위치 변경
            ScrollToVerticalOffset(VerticalOffset + _velocity);

            // 감속도 적용
            if (_velocity > 0)
            {
                _velocity -= _deceleration;
                if (_velocity < 0) _velocity = 0;
            }
            else if (_velocity < 0)
            {
                _velocity += _deceleration;
                if (_velocity > 0) _velocity = 0;
            }

            // 속도가 0이면 더 이상 애니메이션 적용하지 않음
            if (_velocity == 0)
            {
                CompositionTarget.Rendering -= ApplyAccelerationAndDeceleration;
            }
        }
    }
}
