using PAW.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAW
{
    public partial class HistogramControl : Control
    {
        private HistogramValue[] _data;
        public HistogramValue[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public HistogramControl()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void HistogramControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clipRectangle = e.ClipRectangle;

            int[] data = { 2, 4, 10, 6, 6, 2 };

            int width = clipRectangle.Width;
            int height = clipRectangle.Height;
            int dataCount = data.Length;
            int barWidth = width / dataCount;
            int maxDataValue = data.Max();
            float scalingFactor = (float)height / maxDataValue;

            Color[] barColors = { Color.Plum, Color.Violet, Color.MediumOrchid, Color.DarkOrchid, Color.Purple };

            int gridCount = 5;
            using (Pen gridPen = new Pen(Color.LightGray))
            {
                for (int i = 0; i < gridCount; i++)
                {
                    int y = height - (int)((maxDataValue / gridCount * i) * scalingFactor);
                    graphics.DrawLine(gridPen, 0, y, width, y);
                }
            }

            using (Pen gridPen = new Pen(Color.LightGray))
            {
                for (int i = 0; i < dataCount; i++)
                {
                    int x = i * barWidth;
                    graphics.DrawLine(gridPen, x, 0, x, height);
                }
            }

            for (int i = 0; i < dataCount; i++)
            {
                int barHeight = (int)(data[i] * scalingFactor);
                int x = i * barWidth;
                int y = height - barHeight;
                Color barColor = barColors[i % barColors.Length];
                using (Brush barBrush = new SolidBrush(barColor))
                {
                    graphics.FillRectangle(barBrush, x, y, barWidth, barHeight);
                }
            }
        }
    }
}
