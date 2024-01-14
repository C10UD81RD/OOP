// ReSharper disable All

namespace lab_2.Library;

public static class FigureTestHelper
{
    public static TNumber CalculatePerimeter<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {

        // Выполнить расчет периметра для фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.
         TNumber result;
        Figure<TNumber> figure;
        if (!is3DFigure)
        {
            figure = new Rectangle<TNumber>(testData[0]);
        }
        else
        {
            figure = new Sphere<TNumber>(testData[0], testData[1]);
        }
        figure.CalculatePerimeterEvent += Figure_CalculatePerimeterEvent;
        result = figure.CalculatePerimeter();
        figure.Save();
        figure.CalculatePerimeterEvent -= Figure_CalculatePerimeterEvent;
        eventCounter = localeventcounter;
        return result;
        static void Figure_CalculatePerimeterEvent(object? sender, EventArgs e)
        {
            localeventcounter++;
        }

        return TNumber.Zero;
    }

    public static TNumber CalculateSquare<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {   

        // Выполнить расчет площади для фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.
        TNumber result;
        Figure<TNumber> figure;

        if (!is3DFigure)
        {
            figure = new Rectangle<TNumber>(testData[0]);
        }
        else
        {
            figure = new Sphere<TNumber>(testData[0], testData[1]);
        }
        figure.CalculatePerimeterEvent += Figure_CalculateSquareEvent;
        result = figure.CalculateSquare();
        figure.Save();
        figure.CalculatePerimeterEvent -= Figure_CalculateSquareEvent;
        eventCounter = localeventcounter;
        return result;

        static void Figure_CalculateSquareEvent(object? sender, EventArgs e)
        {
            localeventcounter++;
        }

        return TNumber.Zero;
    }

    public static TNumber CalculateVolume<TNumber>(bool is3DFigure, TNumber[] testData, ref uint eventCounter) where TNumber : INumber<TNumber>
    {
        // Выполнить расчет объема для фигуры на основе входных данных.
        // Счетчик должен увеличиваться при каждом срабатывании событий. Каждое событие должно выполниться один раз.
        TNumber result;
        Figure<TNumber> figure;
        if (!is3DFigure)
        {
            figure = new Rectangle<TNumber>(testData[0]);
        }
        else
        {
            figure = new Sphere<TNumber>(testData[0], testData[1]);
        }
        figure.CalculatePerimeterEvent += Figure_CalculateVolumeEvent;
        result = figure.CalculateVolume();
        figure.Save();
        figure.CalculatePerimeterEvent -= Figure_CalculateVolumeEvent;
        eventCounter = localeventcounter;
        return result;
        static void Figure_CalculateVolumeEvent(object? sender, EventArgs e)
        {
            localeventcounter++;
        }

        return TNumber.Zero;
    }
}
