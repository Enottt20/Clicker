using UnityEngine;
namespace Assets.Scripts
{

    [System.Serializable]
    public class Data
    {
        [ReadOnly]
        [SerializeField] protected int _id;

        public Data(int id)
        {
            _id = id;
        }

    }
}