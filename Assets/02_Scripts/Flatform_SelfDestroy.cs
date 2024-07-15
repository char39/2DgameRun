using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flatform_SelfDestroy : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.x < -25f)
            Destroy(this.gameObject);
    }
}
