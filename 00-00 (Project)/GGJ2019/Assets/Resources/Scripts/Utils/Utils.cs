using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static PhysicsMaterial2D noFriction{
        get{
            PhysicsMaterial2D temp = new PhysicsMaterial2D();
            temp.bounciness = 0;
            temp.friction = 0;

            return temp;
        }
    }

  
    public static bool CheckLayer(LayerMask mask, GameObject gameObject) {
        return (mask.value & 1 << gameObject.layer) == 1 << gameObject.layer;
    }

    public int SignZero(float value) {
        if (value != 0)
        {
            return (int)Mathf.Sign(value);
        }
        else {
            return 0;
        }
    }
}
