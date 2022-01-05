using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Tk.Mist
{

    public class ImputEvents : MonoBehaviour
    {
        public static ImputEvents Intance;
        public Action<string, string, float, int> ButtonPress; 
        private void Awake()
        {
            Intance = Intance ? Intance : this;
        }


    }

}
