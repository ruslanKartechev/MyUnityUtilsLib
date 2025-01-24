using UnityEngine;

namespace SleepDev
{
    public class ZSpinner : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;

        private void Update()
        {
            var angles = _target.eulerAngles;
            angles.z += _speed * Time.unscaledDeltaTime;
            _target.eulerAngles = angles;
        }
    }
}