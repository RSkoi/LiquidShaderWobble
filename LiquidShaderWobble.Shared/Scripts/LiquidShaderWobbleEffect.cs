using UnityEngine;

namespace LiquidShaderWobblePlugin
{
    public class LiquidShaderWobbleEffect : MonoBehaviour
    {
        public string ShaderRotXPropName { get; set; } = "_RotationX";
        public string ShaderRotZPropName { get; set; } = "_RotationZ";

        public float MaxWobble { get; set; } = 0.03f;
        public float WobbleSpeed { get; set; } = 1f;
        public float Recovery { get; set; } = 1f;

        private Renderer _rend;
        private Vector3 _lastPos;
        private Vector3 _velocity;
        private Vector3 _lastRot;
        private Vector3 _angularVelocity;
        private float _wobbleAmountX;
        private float _wobbleAmountZ;
        private float _wobbleAmountToAddX;
        private float _wobbleAmountToAddZ;
        private float _pulse;
        private float _time = 0.5f;

        public void Start()
        {
            _rend = GetComponent<Renderer>();
            if (_rend == null)
                LiquidShaderWobblePlugin._logger.LogError("LiquidShaderWobbleEffect found no renderer on targeted object");
        }

        public void Update()
        {
            if (_rend == null)
                return;
            if (string.IsNullOrEmpty(ShaderRotXPropName) || string.IsNullOrEmpty(ShaderRotZPropName))
                return;

            _time += Time.deltaTime;
            // decrease wobble over time
            _wobbleAmountToAddX = Mathf.Lerp(_wobbleAmountToAddX, 0, Time.deltaTime * (Recovery));
            _wobbleAmountToAddZ = Mathf.Lerp(_wobbleAmountToAddZ, 0, Time.deltaTime * (Recovery));

            // make a sine wave of the decreasing wobble
            _pulse = 2 * Mathf.PI * WobbleSpeed;
            _wobbleAmountX = _wobbleAmountToAddX * Mathf.Sin(_pulse * _time);
            _wobbleAmountZ = _wobbleAmountToAddZ * Mathf.Sin(_pulse * _time);

            // send it to the shader
            _rend.material.SetFloat(ShaderRotXPropName, _wobbleAmountX);
            _rend.material.SetFloat(ShaderRotZPropName, _wobbleAmountZ);

            // velocity
            _velocity = (_lastPos - transform.position) / Time.deltaTime;
            _angularVelocity = transform.rotation.eulerAngles - _lastRot;


            // add clamped velocity to wobble
            _wobbleAmountToAddX += Mathf.Clamp((_velocity.x + (_angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
            _wobbleAmountToAddZ += Mathf.Clamp((_velocity.z + (_angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

            // keep last position
            _lastPos = transform.position;
            _lastRot = transform.rotation.eulerAngles;
        }
    }
}
