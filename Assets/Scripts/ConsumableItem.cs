using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
    public enum ItemType {
        Energy,
        Oxygen,
        Instrument,
    }

    public List<Item> _consumables = new List<Item>();
    public float _interval = 1f; //Время через которое вычисляется расход предмета

    [System.Serializable]
    public class Item
    {
        public ItemType _type;
        public int _fullValue; //Максимальная емкость
        public int _defaultConsumeValue; //Значение по умолчанию на которое убывает расходник каждый цикл
        public int _currentValue; //Текущее значение

        private int _consumeValue = 0; //Значение на которое и 
        private int[,] Chance =
        {
            {4,8,10 },
            {7,14,20 },
            {10,20,30 }
        };
        //private bool _isConыsuming=true; //На случай если в помещении, то false
        public int CurrentValue
        {
            get { return _currentValue; }
            set{ _currentValue = Mathf.Clamp(value, 0, _fullValue); }
        }
        public bool Consume(int value = 0) //Осуществление расхода предмета
        {
            value = value != 0 ? value : _consumeValue;
            if ((CurrentValue = Mathf.Clamp(CurrentValue - value, 0, _fullValue)) == 0) return true;
            return false;
        }
        public bool Charge(int value = 0) //Осуществление пополнения предмета (вдруг надо)
        {
            if ((CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _fullValue)) == 0) return true;
            return false;
        }
        public void ReturnToFull() //Заполнить полностью
        {
            _currentValue = _fullValue;
        }
        public void SetConsumeValue(int value = -1) //Изменение значения расхода предмета
        {
            _consumeValue = value<0? _defaultConsumeValue:value;
        }
        public float GetStock() //Возвращает отношение текущего значения к общему объему (для элементов UI) 
        {
            return (float)_fullValue / (float)_currentValue;
        }
        public void Damage(int currentSol,int maxSol)
        {
            Consume();
        }
    }
    



    // Start is called before the first frame update
    void Start()
    {
        Invoke("Cycle",1f);        
    }
    public void Cycle()
    {
        foreach (var el in _consumables)
            el.Consume();
        Invoke("Cycle", 1f);
    }
    
}
