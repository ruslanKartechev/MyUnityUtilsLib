using System.Collections;
using UnityEngine;

namespace SleepDev
{
    public class CameraShaker : MonoBehaviour, ICameraShaker
    {
        [SerializeField] private CameraShakeArgs _defaultArgs;
        [SerializeField] private Transform _movable;
        private Coroutine _working;
        public void Play(CameraShakeArgs args)
        {
            Stop();
            _working = StartCoroutine(ShakingPosition(args));
        }

        public void PlayDefault()
        {
            Play(_defaultArgs);   
        }

        public void Stop()
        {
            if(_working != null)
                StopCoroutine(_working);
        }

        private IEnumerator ShakingRotation(CameraShakeArgs args)
        {
            var elapsed = 0f;
            var timeStep = 1f / args.freqDefault;
            var force = args.forceDefault;
            var forceMax = force;
            var forceMin = force * .1f;
            while (elapsed <= args.durationDefault)
            {
                var eulers = (Vector3)UnityEngine.Random.insideUnitCircle * force;
                var r1 = _movable.localRotation;
                var r2 = Quaternion.Euler(eulers);
                var t = 0f;
                while (t < timeStep)
                {
                    _movable.localRotation = Quaternion.Lerp(r1, r2, t / timeStep);
                    t += Time.deltaTime;
                    yield return null;
                }
                _movable.localRotation = r2;
                yield return null;
                // yield return new WaitForSeconds(timeStep);
                elapsed += timeStep;
                force = Mathf.Lerp(forceMax, forceMin, elapsed / args.durationDefault);
            }
            _movable.localRotation = Quaternion.identity;
        }
        
        private IEnumerator ShakingPosition(CameraShakeArgs args)
        {
            var elapsed = 0f;
            var timeStep = 1f / args.freqDefault;
            var force = args.forceDefault;
            var forceMax = force;
            var forceMin = force * .2f;
            var lookAtLocalVec = new Vector3(0, 0, 100);
            var dur = args.durationDefault * .5f;
            while (elapsed <= dur * 2)
            {
                var localPos = (Vector3)UnityEngine.Random.insideUnitCircle * force;
                _movable.localPosition = localPos;
                var rotVec = _movable.parent.TransformVector(lookAtLocalVec);
                _movable.rotation = Quaternion.LookRotation(rotVec);
                // yield return null;
                yield return new WaitForSeconds(timeStep);
                elapsed += timeStep;
                force = Mathf.Lerp(forceMax, forceMin, elapsed / dur);
            }
            
            yield return null;
            _movable.localRotation = Quaternion.identity;
            _movable.localPosition = Vector3.zero;
        }
    }
}