using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_getQuaternion : MonoBehaviour
{
    public static Quaternion q_myQuaternion;
    public static Vector3 v3_start;

    // Update is called once per frame
    void Update()
    {
        v3_start = new Vector3(transform.rotation.x,0,transform.rotation.z);

        q_myQuaternion = Quaternion.identity;

        
    }
}
