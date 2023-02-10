using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Config<T> : ScriptableObject where T : Data
    {
        [SerializeField, HideInInspector] protected List<T> _datas;

        [SerializeField] protected T _currentData;

        protected int _currentIndex = 0;

        public T GetNext()
        {
            if (_currentIndex < _datas.Count - 1)
                _currentIndex++;
            else _currentIndex = 0;
            _currentData = this[_currentIndex];
            return _currentData;
        }

        public T GetPrevious()
        {
            if (_currentIndex > 0)
                _currentIndex--;
            else _currentIndex = _datas.Count - 1;
                _currentData = this[_currentIndex];
            return _currentData;
        }
        
        public T GetElement(int id)
        {
            return _datas[id];
        }

        public T this[int index]
        {
            get
            {
                if (_datas != null && index >= 0 && index < _datas.Count)
                    return _datas[index];
                return null;
            }

            set
            {
                if (_datas == null)
                    _datas = new List<T>();

                if (index >= 0 && index < _datas.Count && value != null)
                    _datas[index] = value;
            }
        }

        public void AddElement()
        {
            if (_datas == null)
                _datas = new List<T>();

            _currentData = DataConvert(new Data(_datas.Count));
            _datas.Add(_currentData);
            _currentIndex = _datas.Count - 1;
        }

        private T DataConvert(Data data)
        {
            var serializedParent = JsonConvert.SerializeObject(data); 
            return JsonConvert.DeserializeObject<T>(serializedParent);
        }

        public void RemoveCurrentElement()
        {
            if (_currentIndex >= 0)
            {
                _currentData = _datas[_currentIndex--];
                _datas.RemoveAt(_currentIndex+1);
            }
            else
            {
                _datas.Clear();
                _currentData = null;
            }

            GetNext();
        }
        
    }
}