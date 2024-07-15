using System;
using UnityEngine;

public interface IRotateble
{
    public Quaternion Rotation { get; }
    public event Action<Quaternion> OnChangeRotation;

    public float RotationDistanceThreshold { get; }
    public float MaxRotationSpeed { get; }

    public void SetRotation(Quaternion rotation);
}
