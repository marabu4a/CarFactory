using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.EngineModel;
using CarFactory.CarPart.TransmissionModel;
using CarFactory.Custom;

namespace CarFactory.Car
{
    public class Car<T> : IComparable, ICollection<T> where T : CarPart.CarPart
    {
        public static event Logger.LogHandler Log;

        private Engine _engine;
        private Chassis _chassis;
        private Transmission _transmission;
        private Body _body;
        private static List<T> _mainCarParts;
        private int _carCost = 0;

        private Guid _carId;
        private Guid CarId { get; }
        public Engine Engine => _engine;
        public Chassis Chassis => _chassis;
        public Transmission Transmission => _transmission;
        public Body Body => _body;
        public int CarCost => _carCost;

        public Car()
        {
            _mainCarParts = new List<T>();
            _carId = Guid.NewGuid();
        }

        public IActionPossible CanAddPart(CarPart.CarPart carPart)
        {
            if (carPart is null)
            {
                return new ActionImpossible("Cannot add null part");
            }

            if (Contains(carPart as T))
            {
                return new ActionImpossible("Part already added");
            }

            if (!carPart.AvailableForThisCar(this).IsPossible)
            {
                return new ActionImpossible(carPart.AvailableForThisCar(this).Reason);
            }

            return new ActionPossible();
        }

        private void AddPart(CarPart.CarPart part)
        {
            _carCost += part.Cost;
            IActionPossible canAdd = CanAddPart(part);
            if (!canAdd.IsPossible)
            {
                throw new CarPartException(canAdd.Reason, part);
            }

            _mainCarParts.Add(part as T);
        }


        public bool HasAllMainParts()
        {
            return Engine != null && Chassis != null && Transmission != null && Body != null;
        }

        public override string ToString()
        {
            var carOutput = new StringBuilder();
            if (HasAllMainParts())
            {
                carOutput.Append("\n ---  ---  ---  ---  Информация об автомобиле:  ---  ---  ---  --- \n");
                carOutput.Append(Body.ToString() + "\n");
                carOutput.Append(Engine.ToString() + "\n");
                carOutput.Append(Chassis.ToString() + "\n");
                carOutput.Append(Transmission.ToString() + "\n");
                carOutput.Append(" ---  ---  ---  --- Общая цена :" + CarCost + "\n");
            }

            return carOutput.Length > 1 ? carOutput.ToString() : "Ошибка в выводе информации о машине";
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CarEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CarEnumerator<T>(this);
        }

        public void Add(T carPart)
        {
            switch (carPart)
            {
                case Transmission transmission:
                {
                    _transmission = transmission;
                    AddPart(transmission);
                    break;
                }
                case Engine engine:
                {
                    _engine = engine;
                    AddPart(engine);
                    break;
                }
                case Chassis chassis:
                {
                    _chassis = chassis;
                    AddPart(chassis);
                    break;
                }
                case Body body:
                {
                    _body = body;
                    AddPart(body);
                    break;
                }
                case CarPart.CarPart anotherPart:
                {
                    throw new CarPartException("Данную запчасть не добавить к машине", anotherPart);
                }
            }
        }

        public void Clear()
        {
            _engine = null;
            _chassis = null;
            _transmission = null;
            _body = null;
            _mainCarParts.Clear();
        }

        public bool Contains(T item)
        {
            foreach (T carPart in _mainCarParts)
            {
                if (item != null && carPart.Id == item.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new CarException("Метод не определен!",_carId);
        }

        public bool Remove(T item)
        {
            bool result = false;

            for (int i = 0; i < _mainCarParts.Count; i++)
            {
                T carPart = (T) _mainCarParts[i];
                if (item != null && carPart != null && carPart.Id == item.Id)
                {
                    _mainCarParts.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        public virtual T this[int index]
        {
            get => (T) _mainCarParts[index];
            set => _mainCarParts[index] = value;
        }

        public int Count => _engine.Count + _chassis.Count + _transmission.Count + _body.Count;
        public bool IsReadOnly { get; }

        public void Sort(Func<T, T, int> comparer)
        {
            if (_mainCarParts.Count > 1)
            {
                for (int i = _mainCarParts.Count - 1; i > 0; i--)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        var carPartFirst = _mainCarParts[j - 1];
                        var carPartSecond = _mainCarParts[j];
                        if (comparer(carPartFirst, carPartSecond) > 0)
                        {
                            var temporary = _mainCarParts[j];
                            _mainCarParts[j] = _mainCarParts[j - 1];
                            _mainCarParts[j - 1] = temporary;
                        }
                    }
                }
            }
            else throw new CarException("Список деталей пуст", this as Car<CarPart.CarPart>);
        }

        public void Sort()
        {
            if (_mainCarParts.Count > 1)
            {
                for (int i = _mainCarParts.Count - 1; i > 0; i--)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        var carPartFirst = _mainCarParts[j - 1];
                        var carPartSecond = _mainCarParts[j];
                        if (CarPartsComparer.CompareByCost(carPartFirst, carPartSecond) > 0)
                        {
                            var temporary = _mainCarParts[j];
                            _mainCarParts[j] = _mainCarParts[j - 1];
                            _mainCarParts[j - 1] = temporary;
                        }
                    }
                }
            }
            else throw new CarException("Список деталей пуст", _carId);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Car<CarPart.CarPart> anotherCar)
            {
                return _carCost.CompareTo(anotherCar._carCost);
            }
            else
                throw new CarException("Невозможно сравнить эти 2 объекта",_carId);
        }
    }
}