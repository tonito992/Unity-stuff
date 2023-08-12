using UnityEngine;
using UnityEngine.InputSystem;

namespace itonigames.unitystuff.Utility
{
    public static class RaycastUtil
    {
        public static Vector3 MouseHitPosition => MouseToWorld();
        public static void Raycast<T>(out T hitComponent) where T : Component
        {
            hitComponent = null;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                hitComponent = hit.collider.GetComponent<T>();
            }
        }

        public static bool MouseHit()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                return true;
            }

            return false;
        }

        public static Vector3 MouseToWorld()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                return hit.point;
            }

            return Vector3.zero;
        }
    }
}