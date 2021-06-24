using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [System.Serializable]
    public struct PowerRing
    {
        public List<PowerDetection> DetectionsInCircut;
    }

    public List<PowerRing> PowerRings;

    public int PowerRingActive { get { return activePowerRing; }  set { UpdatePowerRing(value); }}
    private int activePowerRing = 0;

    private void Start()
    {
        if (PowerRings != null)
        {
            for(int i = 0; i < PowerRings.Count; i++)
            {
                if (activePowerRing == i) ActivateRing(PowerRings[i]);
                else DeactivateRing(PowerRings[i]);
            }
        }
    }

    public void CyclePower()
    {
        int temp = activePowerRing + 1;
        if(temp >= PowerRings.Count)
        {
            temp = 0;
        }

        PowerRingActive = temp;
    }

    private void UpdatePowerRing(int value)
    {
        //Check if new value is in bounds
        if (PowerRings == null || value >= PowerRings.Count || value < 0) return;

        //Deactivate Current Ring
        DeactivateRing(PowerRings[activePowerRing]);
        ActivateRing(PowerRings[value]);
        activePowerRing = value;
    }

    private void ActivateRing(PowerRing ring)
    {
        if (ring.DetectionsInCircut == null) return;
        
        for(int i = 0; i < ring.DetectionsInCircut.Count; i++)
        {
            ring.DetectionsInCircut[i].OnPowerActivate.Invoke();
        }
    }

    private void DeactivateRing(PowerRing ring)
    {
        if (ring.DetectionsInCircut == null) return;

        for (int i = 0; i < ring.DetectionsInCircut.Count; i++)
        {
            ring.DetectionsInCircut[i].OnPowerDeativate.Invoke();
        }
    }

}
