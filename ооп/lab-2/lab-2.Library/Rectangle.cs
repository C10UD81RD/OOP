namespace Lab2.Library
{
    public class Square<T> : Figure<T>, IDisposable where T : INumber<T>
    {
        readonly T _a;
        readonly T _b;
        public Square(T a) : base(nameof(Square<T>), FigureType.SecondD)
        {
            if (a <= T.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }
            if (b <= T.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }
            _a = a;
            _b = b;
        }
        public void Deconstruct(out T a, out T b)
        {
            a = _a;
            b = _b;
        }
        public override T CalculatePerimeter()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            return T.CreateChecked(2) * (_a + _b);
        }
        public override T CalculateSquare()
        {
            OnCalculateSquareEvent(EventArgs.Empty);
            return _a * _b;
        }
        public override T CalculateVolume()
        {
            OnCalculateVolumeEvent(EventArgs.Empty);
            throw new ArgumentOutOfRangeException();
        }
        public override async Task<T> CalculatePerimeterAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculatePerimeter();
            if (OnCalculatePerimeterAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override async Task<T> CalculateSquareAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculateSquare();
            if (OnCalculateSquareAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override async Task<T> CalculateVolumeAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculateVolume();
            if (OnCalculateVolumeAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override void Save()
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Стороны прямоугольника равны: {_a}, {_b}, значит периметр равен: {CalculatePerimeter()}, площадь равна: {CalculateSquare()}, двумерная фигура квадрата не имеет объема!";
            writer.Write(str);
            writer.Flush();
        }
        public override async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Стороны прямоугольника равны: {_a}, {_b}, значит периметр равен: {CalculatePerimeter()}, Площадь равна: {CalculateSquare()}, Двумерная фигура не может иметь объема!";
            await writer.WriteAsync(str);
            await writer.FlushAsync();
        }
    }
}
