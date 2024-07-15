using System;
using UnityEngine;

namespace Assets.Scripts.MovebleSystem
{
    public class RotateSystem : MonoBehaviour
    {
        [SerializeField] private RotationView _rotationView;

        private IRotateble _rotateble;
        private Func<bool> _rotateCondition;
        private PivotFinder _pivotFinder;

        private void Update()
        {
            if (_rotateCondition.Invoke())
            {
                if (_pivotFinder.Point == null) return;

                Vector3 directionToPivot = _pivotFinder.Point.transform.position - _rotationView.transform.position;
                directionToPivot.y = 0;

                float angle = Vector3.Angle(_rotationView.transform.forward, directionToPivot);

                float rotationSpeed = Mathf.Lerp(0, _rotateble.MaxRotationSpeed, Mathf.Clamp01(angle / _rotateble.RotationDistanceThreshold));

                Quaternion targetRotation = Quaternion.LookRotation(directionToPivot);

                _rotateble.SetRotation(Quaternion.RotateTowards(_rotationView.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
            }
        }

        public void Init(IRotateble rotate, PivotFinder pivot, Func<bool> rotationCondition)
        {
            _rotateble = rotate;
            _pivotFinder = pivot;
            _rotateCondition = rotationCondition;

            _rotationView.Init(_rotateble);
        }
    }
}
