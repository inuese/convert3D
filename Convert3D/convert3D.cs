using System;
using System.Windows.Forms;
using ChartDirector;
using OpenCvSharp;

namespace Convert3D
{
    public partial class convert3D : Form
    {
        //차트를 움직이기 위한 파라미터의 멤버변수를 정의
        double elevationAngle = 30;
        double rotationAngle = 45;

        string imgPath;

        private int lastMouseX = -1;
        private int lastMouseY = -1;
        private bool isDragging = false;

        public convert3D()
        {
            InitializeComponent();
        }
        private string openDriectory()
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "FileOpen";
            ofd.FileName = "";
            ofd.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp|PNG File(*.png)|*.png";
            
            //Dialog Load
            DialogResult dr = ofd.ShowDialog();

            //DialogResult OK
            if (dr == DialogResult.OK)
            {
                //File명.확장자를 Get
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 Get
                string fileFullName = ofd.FileName;

                //label1에 파일명을 입력
                label1.Text = "파일명 : " + fileName;
                
                //이미지 정보 (filename + Path)
                return fileFullName;
            }
            //Dialog Result Cancel
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }
            return "";
        }
        public void Draw(WinChartViewer viewer)
        {
            Mat img = new Mat(imgPath);
            Mat grayScale = new Mat(img.Rows, img.Cols, MatType.CV_8UC1);

            grayScale = img.CvtColor(ColorConversionCodes.BGR2GRAY);
            byte[,] data = new byte[grayScale.Rows, grayScale.Cols];

            for (int i = 0; i < grayScale.Rows; i++)
            {
                for (int j = 0; j < grayScale.Cols; j++)
                {
                    data[i, j] = grayScale.At<Byte>(i, j);
                }
            }
            double[] dataX = new double[grayScale.Rows * grayScale.Cols];
            double[] dataY = new double[grayScale.Rows * grayScale.Cols];
            double[] dataZ = new double[grayScale.Rows * grayScale.Cols]; //GrayValue

            int SIZE = 0;
            for (int x = 0; x < grayScale.Rows; x++)
            {
                for (int y = 0; y < grayScale.Cols; y++)
                {
                    dataX[SIZE] = x;
                    dataY[SIZE] = y;
                    dataZ[SIZE] = data[x, y];
                    SIZE++;
                }
            }
            
            SurfaceChart c = new SurfaceChart(595, 400);
            
            c.setPlotRegion(240, 170, 250, 250, 180);
            c.setData(dataX, dataY, dataZ);
            c.setInterpolation(100, 100);
            c.setViewAngle(elevationAngle, rotationAngle);
            
            c.setShadingMode(Chart.RectangularFrame);
            c.setColorAxis(530, 270, Chart.Left, 200, Chart.Right);
            c.setWallColor(0x000000);

            c.setWallGrid(0xffffff, 0xffffff, 0xffffff, 0x888888, 0x888888, 0x888888);
            c.setWallThickness(0, 0, 0);
            c.setWallVisibility(true, false, false);

            c.xAxis().setTitle("Y Axis", "Arial Bold", 15);
            c.yAxis().setTitle("X Axis", "Arial Bold", 15);

            c.xAxis().setLabelStyle("Arial", 10);
            c.yAxis().setLabelStyle("Arial", 10);
            c.zAxis().setLabelStyle("Arial", 10);
            c.colorAxis().setLabelStyle("Arial", 10);

            // Output the chart
            viewer.Chart = c;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            imgPath = openDriectory();
            drawChart.updateViewPort(true, false);
        }
        private void drawChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (0 != (e.Button & MouseButtons.Left))
            {
                // Start Drag
                isDragging = true;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }
        private void drawChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            { 
                rotationAngle += (lastMouseX - e.X) * 90.0 / 360;
                elevationAngle += (e.Y - lastMouseY) * 90.0 / 270;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }
        private void drawChart_MouseUp(object sender, MouseEventArgs e)
        {
            if (0 != (e.Button & MouseButtons.Left))
            {
                // End Drag
                isDragging = false;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }
        private void drawChart_ViewPortChanged(object sender, ChartDirector.WinViewPortEventArgs e)
        {
            if (e.NeedUpdateChart)
                Draw(drawChart);
        }
    }
}