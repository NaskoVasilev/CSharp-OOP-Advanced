using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            IShape rectangle = new Rectangle();
            IShape circle = new Circle();
            IShape square = new Square();

            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(square);
        }
    }
}
