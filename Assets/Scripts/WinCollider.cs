using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{

    public class WinCollider : MonoBehaviour
    {

        // ------------------------------------------------- //

        void OnTriggerEnter2D(Collider2D other)
        {
            GameManager.Instance.Win();
        }

        // ------------------------------------------------- //

    }

}