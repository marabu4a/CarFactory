using System.Collections;
using System.Collections.Generic;

namespace CarFactory.Custom
{
    public class CarEnumerator<T> : IEnumerator<T> where T : CarPart.CarPart
    {
        private T _current;
        private Car.Car<T> _car;
        private int _index;

        public CarEnumerator(Car.Car<T> car)
        {
            _car = car;
            _index = -1;
            _current = default(T);
        }

        public bool MoveNext()
        {
            if (++_index >= _car.Count)
            {
                return false;
            }
            else
            {
                _current = _car[_index];
            }
            return true;
        }

        public void Reset()
        {
            _current = default(T);
            _index = -1;
        }

        T IEnumerator<T>.Current => _current;

        public object? Current { get; }
        public void Dispose()
        {
            _car = null;
            _current = default(T);
            _index = -1;
        }
    }
}