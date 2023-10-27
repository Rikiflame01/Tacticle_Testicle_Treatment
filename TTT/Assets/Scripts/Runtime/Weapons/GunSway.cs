using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{

    public class GunSway : MonoBehaviour
    {
        public float amount = 0.05f; // Sway amount
        public float maxAmount = 0.2f; // Max sway amount
        public float smoothAmount = 6f; // How smooth the sway is

        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.localPosition;
        }

        void Update()
        {
            float movementX = -Input.GetAxis("Horizontal") * amount;
            float movementY = -Input.GetAxis("Vertical") * amount;

            movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
            movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

            Vector3 finalPosition = new Vector3(movementX, movementY, 0);
            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
        }
    }

}
