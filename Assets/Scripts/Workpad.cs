﻿/*
 * 
 * void SolveFiringSolution(Vector3 target, Vector3[] trackingData)
    {
        if (trackingData.Length > 25)
            return;

        float calcedAcceleration = Vector3.Distance(trackingData[24], trackingData[0]);
        float accelerationOverTime = (1 / calcedAcceleration) * Vector3.Distance(trackingData[24], trackingData[0]);
        Vector3 lastPosition = trackingData[0];
        Vector3 determinedVelocity = trackingData[24] - lastPosition;

        for (int i = 1; i < trackingData.Length / 25; i++)
        {
            //Debug.Log(i + (24 * i) - 1);
            //Debug.LogError(Vector3.Distance(trc.movementTracking[i + (24 * i) - 1], lastPosition));
            //determinedVelocity += trc.movementTracking[i + (24 * i) - 1] - lastPosition;
            accelerationOverTime += (1 / calcedAcceleration) * Vector3.Distance(trackingData[i + (24 * i) - 1], lastPosition);
            calcedAcceleration += Vector3.Distance(trackingData[i + (24 * i) - 1], lastPosition);
            lastPosition = trackingData[i + (24 * i) - 1];
        }
        //Debug.Log(calcedAcceleration);
        //Debug.Log(determinedVelocity);
        //Debug.Log(accelerationOverTime);
        calcedAcceleration /= 2f;
        accelerationOverTime /= 2f;
        accelerationOverTime = Mathf.Pow(accelerationOverTime, 2);
        //Debug.Log("Accel OT");
        //Debug.Log(accelerationOverTime);
        //determinedVelocity /= 4f;
        determinedVelocity = (trackingData[trackingData.Length - 1] - trackingData[trackingData.Length - 2]) * fixedSecondDivide;
        //Debug.Log(calcedAcceleration);
        //Debug.Log(determinedVelocity);
        //Debug.Log(determinedVelocity.normalized);
        //Debug.LogError(calcedAcceleration);

        determinedVelocity += (determinedVelocity.normalized * calcedAcceleration);
        //Debug.DrawLine(trc.targetPos, trc.targetPos + determinedVelocity, Color.red,0.1f,false);
        //Debug.Log(determinedVelocity);

        fs = CalculateFireSolution(trackingData[trackingData.Length - 1], determinedVelocity, determinedVelocity.magnitude, accelerationOverTime);

        if (fs.timeToImpact <= 0f)
        {
            return;
        }

        //Debug.Log(fs.direction);
        //Debug.Log(fs.timeToImpact);

        //wsc.AimTo(fs.direction);
        //if (trc.alignmentStatus == TrackingRadarController.Alignment.ALIGNED)
        //{
        //    if (wsc.AimTo(fs.direction))
        //    {
        //        wsc.UpdateFireSolution(fs);
        //        if (fs.timeToImpact * 1100f < 7500f)
        //        {
        //            if (wsc.firingState == WeaponSystemController.FiringState.IDLE)
        //            {
        //                wsc.StartBurst();
        //            }
        //        }
        //    }
        //}
        
    }

    (Vector3 direction, float timeToImpact) CalculateFireSolution(Vector3 tPosition, Vector3 tVelocity, float tSpeed, float accIncrease)
    {
        Vector3 turretCenter = BarrelOrigin.position;

        Vector3 p0 = tPosition;
        Vector3 v0 = tVelocity.normalized;
        float s0 = tSpeed;


        Vector3 p1 = turretCenter;
        float s1 = 1100f;

        float shotSpeed = 1100f;

        Vector3 shooterPosition = turretCenter;
        Vector3 targetPosition = tPosition;

        Vector3 shooterVelocity = Vector3.zero;
        //Vector3 targetVelocity = tVelocity.normalized * ((s0 * Mathf.Pow(accIncrease, (Vector3.Distance(p0, p1) / 1100f))) + s0) / 2;
        Vector3 targetVelocity = tVelocity.normalized * tSpeed;
        //Debug.LogError(tSpeed);

        Vector3 targetRelativePosition = targetPosition - shooterPosition;
        Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
        float t = FirstOrderInterceptTime
        (
            shotSpeed,
            targetRelativePosition,
            targetRelativeVelocity
        );

        //Debug.DrawLine(p1, p0, Color.red);
        //Debug.DrawLine(p0, p0 + (v0 * s0), Color.black);

        //Debug.DrawLine(tPosition, targetPosition + t * (targetRelativeVelocity), Color.cyan);

        return (targetRelativePosition + t * (targetRelativeVelocity), t);



        //Debug.DrawLine(p1, p0, Color.red);

        //s0 =  ((s0 * Mathf.Pow(accIncrease,(Vector3.Distance(p0, p1) / 1100f))) + s0) / 2;
        //Debug.DrawLine(p0, p0 + (v0 * s0), Color.black);

        //float a = ((v0.x * v0.x) + (v0.y * v0.y) + (v0.z * v0.z)) - (s1 * s1);
        //float b = 2 * (((p0.x * v0.x) + (p0.y * v0.y) + (p0.z * v0.z)) - ((p1.x * v0.x) - (p1.y * v0.y) - (p1.z * v0.z)));
        //float c = ((p0.x * p0.x) + (p0.y * p0.y) + (p0.z * p0.z)) + ((p1.x * p1.x) + (p1.y + p1.y) + (p1.z + p1.z)) - ((2 * p1.x * p0.x) - (2 * p1.y * p0.y) - (2 * p1.z * p0.z));

        //float t1 = (-b + Mathf.Sqrt((b * b) - (4 * a * c))) / (2 * a);
        //float t2 = (-b - Mathf.Sqrt((b * b) - (4 * a * c))) / (2 * a);
        //float t;
        //Debug.Log(t1);
        //Debug.Log(t2);
        //if (t1 >= 0 && (t2 >= 0 ? t1 < t2 : true))
        //{
        //    t = t1;
        //}
        //else if (t2 >= 0 && (t1 >= 0 ? t2 < t1 : true))
        //{
        //    t = t2;
        //}
        //else
        //{
        //    return(Vector3.zero, 0);
        //}
        //float timeToImpact = t;
        ////Debug.Log(accIncrease);
        //Debug.Log(timeToImpact);
        ////Debug.Log(Mathf.Pow(accIncrease, timeToImpact));

        //Vector3 v = (p0 - p1 + (t * s0 * v0)) / (t * s1);
        //v.x = (p0.x - p1.x + (t * s0 * v0.x)) / (t * s1);
        //v.y = (p0.y - p1.y + (t * s0 * v0.y)) / (t * s1);
        //v.z = (p0.z - p1.z + (t * s0 * v0.z)) / (t * s1);
        //Debug.Log(v.magnitude);

        //return (v.normalized, timeToImpact);

        return (Vector3.zero, 0);
    }

    public static float FirstOrderInterceptTime
    (
        float shotSpeed,
        Vector3 targetRelativePosition,
        Vector3 targetRelativeVelocity
    )
    {
        float velocitySquared = targetRelativeVelocity.sqrMagnitude;
        if (velocitySquared < 0.001f)
            return 0f;

        float a = velocitySquared - shotSpeed * shotSpeed;

        //handle similar velocities
        if (Mathf.Abs(a) < 0.001f)
        {
            float t = -targetRelativePosition.sqrMagnitude /
            (
                2f * Vector3.Dot
                (
                    targetRelativeVelocity,
                    targetRelativePosition
                )
            );
            return Mathf.Max(t, 0f); //don't shoot back in time
        }

        float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
        float c = targetRelativePosition.sqrMagnitude;
        float determinant = b * b - 4f * a * c;

        if (determinant > 0f)
        { //determinant > 0; two intercept paths (most common)
            float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
                    t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
            if (t1 > 0f)
            {
                if (t2 > 0f)
                    return Mathf.Min(t1, t2); //both are positive
                else
                    return t1; //only t1 is positive
            }
            else
                return Mathf.Max(t2, 0f); //don't shoot back in time
        }
        else if (determinant < 0f) //determinant < 0; no intercept path
            return 0f;
        else //determinant = 0; one intercept path, pretty much never happens
            return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
    }
 * 
 * 
 * 
 * 
 * 
 */