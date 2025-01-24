using UnityEngine;

namespace SleepDev
{
    public class XSpinner : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;

        private void Update()
        {
            _target.localRotation *= Quaternion.Euler( _speed * Time.deltaTime, 0f, 0f);
        }
    }
}