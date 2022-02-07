using System.Windows;
using SharpGL;
using SharpGL.WPF;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // угол поворота
        float rotation = 0.0f;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OnOpenGLDraww(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;

            float[] v1 = { 2, 2, 2, -2, 2, 2, -2, -2, 2, 2, -2, 2 };
            float[] n1 = { 2, 2, 3, -2, 2, 3, -2, -2, 3, 2, -2, 3 };
            float[] v2 = { 2, -2, 2, 2, -2, -2, -2, -2, -2, -2, -2, 2 };
            float[] n2 = { 2, -3, 2, 2, -3, 2, -2, -3, 2, -2, -3, 2 };
            float[] v3 = { 2, -2, -2, -2, -2, -2, -2, 2, -2, 2, 2, -2 };
            float[] n3 = { 2, -2, -3, -2, -2, -3, -2, 2, -3, 2, 2, -3 };
            float[] v4 = { -2, 2, -2, -2, 2, 2, -2, -2, 2, -2, -2, -2 };
            float[] n4 = { -3, 2, -2, -3, 2, 2, -3, -2, 2, -3, -2, -2 };
            float[] v5 = { -2, 2, 2, 2, 2, 2, 2, 2, -2, -2, 2, -2 };
            float[] n5 = { -2, 3, 2, 2, 3, 2, 2, 3, -2, -2, 3, -2 };
            float[] v6 = { 2, 2, 2, 2, 2, -2, 2, -2, -2, 2, -2, 2 };
            float[] n6 = { 3, 2, 2, 3, 2, -2, 3, -2, -2, 3, -2, 2 };


            gl.Enable(OpenGL.GL_DEPTH_TEST);

            // Включаем свет
            gl.Enable(OpenGL.GL_LIGHTING);
            // Источник света
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_NORMALIZE);

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.PushMatrix();

            gl.Rotate(-60, 1, 0, 0);
            gl.Rotate(33, 0, 0, 1);
            gl.Translate(2, 3, -2);

            #region Освещение

            gl.PushMatrix();

            gl.Rotate(rotation, 0, 1, 0);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] { 0, 0, 1, 0 });
            gl.Translate(0, 0, 5);
            gl.Scale(0.2, 0.2, 0.2);
            gl.Color(1f, 1f, 1f);

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(2, 2, 2);
            gl.Vertex(-2, 2, 2);
            gl.Vertex(-2, -2, 2);
            gl.Vertex(2, -2, 2);
            gl.End();

            gl.PopMatrix();

            #endregion
            // Указываем оси вращения (x, y, z)
            gl.Rotate(-rotation, 0, 0, 1);

            gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.EnableClientState(OpenGL.GL_NORMAL_ARRAY);

            gl.Color(0f, 1f, 0f);
            gl.VertexPointer(3, 0, v1);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n1);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

            gl.Color(0f, 0f, 1f);
            gl.VertexPointer(3, 0, v2);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n2);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

            gl.Color(1f, 0f, 0f);
            gl.VertexPointer(3, 0, v3);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n3);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

            gl.Color(1f, 0f, 1f);
            gl.VertexPointer(3, 0, v4);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n4);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

            gl.Color(0f, 1f, 1f);
            gl.VertexPointer(3, 0, v5);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n5);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

           
            gl.Color(1f, 1f, 0f);
            gl.VertexPointer(3, 0, v6);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, n6);
            gl.DrawArrays(OpenGL.GL_TRIANGLE_FAN, 0, 4);

            gl.DisableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.DisableClientState(OpenGL.GL_NORMAL_ARRAY);

            gl.PopMatrix();

            rotation += 1.5f;
        }

        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;
            // Цвет фона
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }

        private void OpenGLControl_Resized(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;
            // Задаем матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Единичная матрица для последующих преобразований
            gl.LoadIdentity();
            // Преобразование
            gl.Perspective(60, (double)Width / (double)Height, 0.01, 100);
            // Устанавливаем камеру и ее положение
            gl.LookAt(0, 0, 10,
                0, 1, 0,
                0, 1, 0);
            // Задаем модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
        }
    }
}
