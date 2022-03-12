﻿using EdyCommonTools;
using System;
using UnityEngine;

namespace Perrinn424.AutopilotSystem
{
    [Serializable]
    public abstract class Corrector
    {
        public float kp;
        public float ki;
        public float kd;
        public float max;
        public PidController.ProportionalMode mode;

        protected Rigidbody rb;
        public PidController PID { get; private set; }

        public Vector3 Force { get; protected set; }
        public float Error { get; protected set; }

        public void Init(Rigidbody rb)
        {
            this.rb = rb;
            PID = new PidController();
        }

        protected void UpdatePIDSettings()
        {
            PID.SetParameters(kp, ki, kd);
            PID.limitedOutput = true;
            PID.maxOutput = max;
            PID.minOutput = -max;
            PID.proportionalMode = mode;
        }
    } 
}
