using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Car : IRotateble
    {
        public Quaternion Rotation { get; private set; }
        public float RotationDistanceThreshold => 110;
        public float MaxRotationSpeed => 150;
        public event Action<Quaternion> OnChangeRotation;

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;

            OnChangeRotation?.Invoke(Rotation);
        }
    }
}