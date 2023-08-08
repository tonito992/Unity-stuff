using System;
using UnityEngine;

namespace itonigames.unitystuff.HierarchicalStateMachine
{
    [Serializable]
    public class StateMachine : MonoBehaviour
    {
        public BaseState CurrentState { get; set; }

        protected virtual void Update()
        {
            CurrentState?.UpdateStates();
        }
    }
}