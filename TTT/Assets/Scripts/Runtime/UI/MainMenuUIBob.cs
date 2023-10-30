using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

namespace TTT
{
    public class MainMenuUIBob : MonoBehaviour
    {
        #region FIELDS

        private Transform Trans { get; set; }
        public float bobSpeed = 1.5f;
        public float bobHeight = 1f;
        public bool lockZ = true;
        public bool lockRotation = true;
        private Vector3 _startPos;
        private Vector3 _movementEquation;
        private Vector3 _RotationEquation;

        [Header("Movement")]
        [Range(0f, 2f)]
        public float XAmplitude = 0.15f;

        [Range(0f, 2f)]
        public float YAmplitude = 0.15f;

        [Range(0f, 2f)]
        public float ZAmplitude = 0.15f;

        [Range(0f, 2f)]
        public float XSpeed = 0.2f;

        [Range(0f, 2f)]
        public float YSpeed = 0.2f;

        [Range(0f, 2f)]
        public float ZSpeed = 0.2f;

        [Header("Rotation")]
        [Range(0f, 3f)]
        public float RotationAmplitude = 1.5f;

        [Range(0f, 2f)]
        public float RotationSpeedMultiplier = 0.25f;

        [Range(0f, 2f)]
        public float rotationSpeed = 0.2f;

        private Vector3 _progression;
        private readonly Vector3 _speedIncrement = Vector3.one;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            GetStart();
        }

        private void FixedUpdate()
        {
            //bob();
            ApplyWiggle();
            _progression += Time.fixedDeltaTime * _speedIncrement;
        }

        #endregion UNITY METHODS

        #region METHODS

        public void bob()
        {
            float newY = _startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            float newX = _startPos.x + Mathf.Cos(Time.time * bobSpeed) * bobHeight;

            if (lockZ)
                Trans.position = new Vector3(newX, newY, _startPos.z);
            else
                Trans.position = new Vector3(newX, newY, Trans.position.z);
        }

        private void ApplyWiggle()
        {
            transform.GetPositionAndRotation(out var position, out _);
            Vector3 currentPos = position;

            if (lockZ)
                transform.position = Vector3.Lerp(currentPos,
                new Vector3(_startPos.x + TrigMotionEquations((int)_movementEquation.x, _progression.x, XSpeed, XAmplitude),
                    _startPos.y + TrigMotionEquations((int)_movementEquation.y, _progression.y,
                        YSpeed, YAmplitude) * -1,
                    _startPos.z), Time.deltaTime * 2f);
            else
                transform.position = Vector3.Lerp(currentPos,
                new Vector3(_startPos.x + TrigMotionEquations((int)_movementEquation.x, _progression.x, XSpeed, XAmplitude),
                    _startPos.y + TrigMotionEquations((int)_movementEquation.y, _progression.y,
                        YSpeed, YAmplitude) * -1,
                    _movementEquation.z + TrigMotionEquations((int)_movementEquation.z, _progression.z,
                        ZSpeed, ZAmplitude)), Time.deltaTime * 2f);
            if (lockRotation)
                return;
            transform.localEulerAngles = new Vector3(
                Mathf.Clamp(TrigRotationEquations((int)_RotationEquation.x, _progression.x, RotationSpeedMultiplier, RotationAmplitude), -15f, 10f),
                Mathf.Clamp(TrigRotationEquations((int)_RotationEquation.y, _progression.y, RotationSpeedMultiplier, RotationAmplitude), -3f, 3f),
                Mathf.Clamp(TrigRotationEquations((int)_RotationEquation.z, _progression.z, RotationSpeedMultiplier, RotationAmplitude), -3f, 3f));
        }

        private void GetStart()
        {
            _startPos = transform.position;
            Trans = GetComponent<Transform>();
            _movementEquation = new Vector3(Mathf.Floor(Random.Range(0, 3)), Mathf.Floor(Random.Range(0, 3)), Mathf.Floor(Random.Range(0, 3)));
            _RotationEquation = new Vector3(Mathf.Floor(Random.Range(0, 3)), Mathf.Floor(Random.Range(0, 3)), Mathf.Floor(Random.Range(0, 3)));
        }

        private float TrigMotionEquations(int equation, float progression, float frequency, float amplitude)
        {
            float result = 0f;
            switch (equation)
            {
                case 0:
                    result = Mathf.Sin(1.8f * Mathf.Sin(Mathf.Cos(progression * 0.13f)) * Mathf.Cos((progression - 3f) * frequency)) * amplitude;
                    break;

                case 1:
                    result = Mathf.Sin((Mathf.Sin(progression * 0.8f) * 0.5f) * (Mathf.Cos(progression * 0.2f) * frequency)) * amplitude;
                    break;

                case 2:
                    result = (Mathf.Sin(progression * frequency)) * (Mathf.Sin((progression * 0.4f) * 0.3f)) * amplitude;
                    break;
            }
            return result;
        }

        private float TrigRotationEquations(int equation, float progression, float frequency, float amplitude)
        {
            float result = 0f;

            switch (equation)
            {
                case 0:
                    result = Mathf.Sin(progression * (rotationSpeed * frequency) * Mathf.Cos(progression * (rotationSpeed * frequency))) * amplitude;
                    break;

                case 1:
                    result = Mathf.Cos(progression * (rotationSpeed * frequency) * Mathf.Sin(progression * (rotationSpeed * frequency))) * amplitude;
                    break;

                case 2:
                    result = Mathf.Sin(progression * (rotationSpeed * frequency)) * Mathf.Cos(progression * (rotationSpeed * frequency)) * amplitude;
                    break;
            }
            return result;
        }

        #endregion METHODS
    }
}