
namespace GeometryFigures.Figures
{
    //Интерфейс фигуры
    public interface IFigure
    {
        string Data { get; }//Строковое представление данных
        string SquareString { get; }//Строковое представление площади
        string Type { get; }//Строковое представление типа фигуры
        double Square();//Рассчет площади
    }
}
