﻿using System;
using UnityEngine;

namespace Perrinn424.AutopilotSystem
{
    [Serializable]
    public struct Sample
    {
        public Vector3 position;
        public Quaternion rotation;

        public int rawSteer;
        public int rawThrottle;
        public int rawBrake;

        public int gear;
        public float steeringAngle;
        public float throttle;
        public float brakePressure;

        public int automaticGear;

        public static Sample Lerp(Sample a, Sample b, float t)
        {
            return new Sample
            {
                position = Vector3.Lerp(a.position, b.position, t),
                rotation = Quaternion.Lerp(a.rotation, b.rotation, t),
                
                rawSteer = IntLerp(a.rawSteer, b.rawSteer, t),
                rawThrottle = IntLerp(a.rawThrottle, b.rawThrottle, t),
                rawBrake = IntLerp(a.rawBrake, b.rawBrake, t),
                automaticGear = a.automaticGear,
                
                steeringAngle = Mathf.Lerp(a.steeringAngle, b.steeringAngle, t),
                throttle = Mathf.Lerp(a.throttle, b.throttle, t),
                brakePressure = Mathf.Lerp(a.brakePressure, b.brakePressure, t),
                gear = a.gear
            };
        }

        public static Sample LerpUncampled(Sample a, Sample b, float t)
        {
            return new Sample
            {
                position = Vector3.LerpUnclamped(a.position, b.position, t),
                rotation = Quaternion.LerpUnclamped(a.rotation, b.rotation, t),
                
                rawSteer = IntLerpUncampled(a.rawSteer, b.rawSteer, t),
                rawThrottle = IntLerpUncampled(a.rawThrottle, b.rawThrottle, t),
                rawBrake = IntLerpUncampled(a.rawBrake, b.rawBrake, t),
                automaticGear = a.automaticGear,
                
                steeringAngle = Mathf.LerpUnclamped(a.steeringAngle, b.steeringAngle, t),
                throttle = Mathf.LerpUnclamped(a.throttle, b.throttle, t),
                brakePressure = Mathf.LerpUnclamped(a.brakePressure, b.brakePressure, t),
                gear = a.gear
            };
        }

        private static int IntLerp(int a, int b, float t)
        {
            return (int)Mathf.Lerp(a, b, t);
        }

        private static int IntLerpUncampled(int a, int b, float t)
        {
            return (int)Mathf.LerpUnclamped(a, b, t);
        }
    } 
}
