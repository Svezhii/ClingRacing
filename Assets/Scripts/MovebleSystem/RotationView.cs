using System;
using UnityEngine;

namespace Assets.Scripts.MovebleSystem
{
    public class RotationView : MonoBehaviour
    {
        private IRotateble _rotateble;

        public void Init(IRotateble rotateble)
        {
            _rotateble = rotateble;

            _rotateble.OnChangeRotation += OnChangeRotation;
        }

        private void OnDestroy()
        {
            _rotateble.OnChangeRotation -= OnChangeRotation;
        }

        private void OnChangeRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}