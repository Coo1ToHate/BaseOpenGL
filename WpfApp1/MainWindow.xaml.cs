using System.Windows;
using SharpGL;
using SharpGL.WPF;

namespace WpfApp1
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

            // Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            #region Пирамида

            // Загружаем единичную матрицу
            gl.LoadIdentity();

            // Указываем оси вращения (x, y, z)
            gl.Rotate(rotation, 0, 1, 0);

            // Задаём какую фигуру будем рисовать
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(0f, 1f, 0f);
            gl.Vertex(0, 1, 0);
            gl.Vertex(1, -1, 1);
            gl.Vertex(-1, -1, 1);

            gl.Color(1f, 0f, 0f);
            gl.Vertex(0, 1, 0);
            gl.Vertex(1, -1, -1);
            gl.Vertex(1, -1, 1);

            gl.Color(0f, 0f, 1f);
            gl.Vertex(0, 1, 0);
            gl.Vertex(1, -1, -1);
            gl.Vertex(-1, -1, -1);

            gl.Color(1f, 1f, 0f);
            gl.Vertex(0, 1, 0);
            gl.Vertex(-1, -1, 1);
            gl.Vertex(-1, -1, -1);

            gl.End();

            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(0, 1, 1f);
            gl.Vertex(-1, -1, 1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(1, -1, -1);
            gl.Vertex(-1, -1, -1);

            gl.End();

            #endregion

            #region Куб

            // Загружаем единичную матрицу
            gl.LoadIdentity();

            // Указываем оси вращения (x, y, z)
            gl.Rotate(rotation, 1, 1, 1);

            gl.LineWidth(2.5f);

            gl.Begin(OpenGL.GL_LINES);
            
            gl.Color(1f, 0f, 1f);
            gl.Vertex(2, 2, 2);
            gl.Vertex(2, -2, 2);
            gl.Vertex(2, -2, 2);
            gl.Vertex(-2, -2, 2);
            gl.Vertex(-2, -2, 2);
            gl.Vertex(-2, 2, 2);
            gl.Vertex(-2, 2, 2);
            gl.Vertex(2, 2, 2);

            gl.Vertex(2, 2, 2);
            gl.Vertex(2, 2, -2);
            gl.Vertex(2, 2, -2);
            gl.Vertex(2, -2, -2);
            gl.Vertex(2, -2, -2);
            gl.Vertex(2, -2, 2);

            gl.Vertex(2, 2, -2);
            gl.Vertex(-2, 2, -2);
            gl.Vertex(-2, 2, -2);
            gl.Vertex(-2, -2, -2);
            gl.Vertex(-2, -2, -2);
            gl.Vertex(2, -2, -2);

            gl.Vertex(-2, 2, -2);
            gl.Vertex(-2, 2, 2);
            gl.Vertex(-2, -2, -2);
            gl.Vertex(-2, -2, 2);

            gl.End();

            #endregion

            //g1.Flush();

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
            gl.LookAt(5, 4, 10,
                0, 1, 0,
                0, 1, 0);
            // Задаем модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
