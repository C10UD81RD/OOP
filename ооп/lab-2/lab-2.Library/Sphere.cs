namespace Lab2.Library
{
    public class Sphere<T> : Figure<T> where T : INumber<T>
    {
        private T _r;
        public Sphere(T r) : base(nameof(Sphere<T>), FigureType.ThreeD)
        {
            if (r <= T.Zero)
            {
                throw new ArgumentOutOfRangeException();
            }
            _r = r;
        }
        public void Deconstruct(out T r)
        {
            r = _r;
        }
        public override T CalculatePerimeter()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            return T.CreateChecked(double.Round(double.CreateChecked(T.CreateChecked(double.Pi) * T.CreateChecked(2) * _r), 3, MidpointRounding.ToZero));
        }
        public override T CalculateSquare()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            T res =  T.CreateChecked(double.CreateChecked(2)) * T.CreateChecked(Math.PI) * _r * _r + T.CreateChecked(double.CreateChecked(2)) * T.CreateChecked(Math.PI) * T.CreateChecked(Math.Pow(Convert.ToDouble(_r), 2));
            return T.CreateChecked(Math.Round(double.CreateChecked(res), 3, MidpointRounding.ToZero));
        }
        public override T CalculateVolume()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            T res = T.CreateChecked(double.Pi) * (_r * _r * _r) * 4 / 3;
            return T.CreateChecked(Math.Round(double.CreateChecked(res), 3, MidpointRounding.ToZero));
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
            string str = @$"Радиус равен {_r}, значит объем цилиндра равен {CalculateVolume()}";
            writer.Write(str);
            writer.Flush();
        }
        public override async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Радиус равен {_r}, значит объем цилиндра равен {CalculateVolume()}";
            await writer.WriteAsync(str);
            await writer.FlushAsync();
        }
    }
}