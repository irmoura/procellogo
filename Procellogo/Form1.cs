using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procellogo
{
    public partial class Form1 : Form
    {

        private Graphics graphics = null;
        private int centralHorizontalLine;
        private int centralVerticalLine;
        private int circleSize = 400;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            centralHorizontalLine = (this.Width / 2) - 8;
            centralVerticalLine = (this.Height / 2) - 7;
            //
            //DrawHorizontalLine(Color.Red, 0, this.Width, centralVerticalLine, 2);
            //DrawVerticalLine(Color.Red, centralHorizontalLine, 0, centralHorizontalLine, this.Height, 2);
            //
            DrawPie(centralHorizontalLine - (circleSize / 2), centralVerticalLine - (circleSize / (float)2.0), circleSize, circleSize, 90.0F, -180.0F, Color.Yellow);//RIGHT FACE
            //DrawPie(centralHorizontalLine - (circleSize / 2), centralVerticalLine - (circleSize / (float)2.0), circleSize, circleSize, 90.0F, 180.0F, Color.Red);//LEFT FACE
            //
            DrawEllipse(Color.White, centralHorizontalLine, centralVerticalLine - (circleSize / 2), circleSize);//OUTSIDE CIRCLE
            //
            DrawArc(centralHorizontalLine - (circleSize / 3), centralVerticalLine - (circleSize / 3.0f), (circleSize / 1.5f), (circleSize / 1.5f), 90.0F, -90.0F, Color.Black);//RIGHT SMILE
            DrawArc(centralHorizontalLine - (circleSize / 3), centralVerticalLine - (circleSize / 3.0f), (circleSize / 1.5f), (circleSize / 1.5f), 180.0F, -90.0F, Color.White);//LEFT SMILE
            //
            DrawFilledCircle(Color.Black, ((centralHorizontalLine + 25) + 60), centralVerticalLine - (circleSize / 4), (circleSize / 5), true);//RIGHT EYE
            //
            DrawFilledCircle(Color.White, ((centralHorizontalLine + 25) - 90), centralVerticalLine - 120, (circleSize / 5));//BOTTOM LEFT EYE
            DrawFilledCircle(Color.Black, ((centralHorizontalLine + 25) - 90), centralVerticalLine - 125, (circleSize / 5));//TOP LEFT EYE
            //
            int count01 = 185;
            for (int i = 0; i < 4; i++)
            {
                DrawArc(centralHorizontalLine - (circleSize / 4), centralVerticalLine + count01, (circleSize / 8.5f), (circleSize / 8.5f), 90.0F, 180.0F, Color.White);
                DrawArc(centralHorizontalLine + (circleSize / 7), centralVerticalLine + count01, (circleSize / 8.5f), (circleSize / 8.5f), 90.0F, -180.0F, Color.White);//
                count01 += 46;
            }
            //

            DrawHorizontalLine(Color.Black, centralHorizontalLine - 85, centralHorizontalLine + 85, centralVerticalLine + 192, 19);
            DrawHorizontalLine(Color.White, centralHorizontalLine - 85, centralHorizontalLine + 85, centralVerticalLine + 186, 7);
            //
            count01 = 233;
            int count02 = 185;
            for (int i = 0; i < 4; i++)
            {
                DrawHorizontalLines(Color.White, centralHorizontalLine - 85, centralVerticalLine + count01, centralHorizontalLine + 85, centralVerticalLine + count02, 6);
                count01 += 46;
                count02 += 46;
            }
            //
            DrawHorizontalLine(Color.White, centralHorizontalLine - 85, centralHorizontalLine + 85, centralVerticalLine + 370, 6);
            //
            DrawHorizontalLine(Color.White, centralHorizontalLine - 22, centralHorizontalLine + 22, centralVerticalLine + 420, 6);//SMALL BASE
            //
            DrawHorizontalLines(Color.White, centralHorizontalLine + 20, centralVerticalLine + (count01 + 2), centralHorizontalLine + 55, centralVerticalLine + count02, 6);//RIGHT
            DrawHorizontalLines(Color.White, centralHorizontalLine - 20, centralVerticalLine + (count01 + 2), centralHorizontalLine - 55, centralVerticalLine + count02, 6);//LEFT
        }

        private void DrawHorizontalLine(Color color, int x1, int x2, int y, int brushSize)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), brushSize), x1, y, x2, y);
        }

        private void DrawHorizontalLines(Color color, int x1, int y1, int x2, int y2, int brushSize)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), brushSize), x1, y1, x2, y2);
        }

        private void DrawVerticalLine(Color color, int x1, int y1, int x2, int y2, int brushSize)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), brushSize), x1, y1, x2, y2);
        }

        private void DrawPie(float x, float y, float width, float height, float startAngle, float sweepAngle, Color color)
        {
            graphics = this.CreateGraphics();
            graphics.FillPie(new SolidBrush(color), x, y, width, height, startAngle, sweepAngle);
        }

        private void DrawEllipse(Color color, int x, int y, int circleSize)
        {
            graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle((x - (circleSize / 2)), y, circleSize, circleSize);
            graphics.DrawEllipse(new Pen(new SolidBrush(color), 2), rectangle);
        }

        private void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle, Color color)
        {
            graphics = this.CreateGraphics();
            graphics.DrawArc(new Pen(new SolidBrush(color), 6), x, y, width, height, startAngle, sweepAngle);
        }

        private void DrawFilledCircle(Color color, int x, int y, int circleSize, bool change = false)
        {
            graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle((x - (circleSize / 2)), y, change == true ? (circleSize / 2) : circleSize, circleSize);
            graphics.FillEllipse(new SolidBrush(color), rectangle);
        }
    }
}
