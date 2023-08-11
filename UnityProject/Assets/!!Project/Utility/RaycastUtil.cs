using UnityEngine;
using UnityEngine.InputSystem;

namespace itonigames.unitystuff.Utility
{
    public static class RaycastUtil
    {
        public static void Raycast<T>(out T hitComponent) where T : Component
        {
            hitComponent = null;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hitComponent = hit.collider.GetComponent<T>();
            }
        }
    }
}