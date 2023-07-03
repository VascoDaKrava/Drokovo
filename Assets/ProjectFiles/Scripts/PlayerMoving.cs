using UnityEngine;


namespace Drokovo
{
    public class PlayerMoving : MonoBehaviour
    {

        [SerializeField] private Transform _headTransform;
        [SerializeField] private Transform _playerTransform;

        private float _speedWalk = 2.5f;

        private Vector2 _inputMouseDirection = Vector2.zero;
        private float _yRot = 0.0f;
        private float _forward = 0.0f;
        private float _strafe = 0.0f;

        private void Update()
        {
            GetInput();
        }

        private void LateUpdate()
        {
            HeadRotate();
            PlayerMove();
        }

        /// <summary>
        /// Get inputs
        /// </summary>
        private void GetInput()
        {
            _forward = Input.GetAxis("Vertical");
            _strafe = Input.GetAxis("Horizontal");

            _yRot = Input.GetAxisRaw("Mouse X");

            _inputMouseDirection.x += Input.GetAxis("Mouse X");
            _inputMouseDirection.y -= Input.GetAxis("Mouse Y");
        }

        /// <summary>
        /// Change head angles
        /// </summary>
        private void HeadRotate()
        {
            if (_inputMouseDirection.y > 65.0f) _inputMouseDirection.y = 65.0f;
            if (_inputMouseDirection.y < -65.0f) _inputMouseDirection.y = -65.0f;

            _headTransform.rotation = Quaternion.Euler(_inputMouseDirection.y, _inputMouseDirection.x, 0.0f);


            _playerTransform.rotation = Quaternion.Euler(0.0f, _headTransform.rotation.eulerAngles.y, 0.0f);
        }

        private void PlayerMove()
        {
            if (!Mathf.Approximately(_forward, 0.0f))
            {
                _playerTransform.position += _forward * _speedWalk * Time.deltaTime * _playerTransform.forward;
            }

            if (!Mathf.Approximately(_strafe, 0.0f))
            {
                _playerTransform.position += _strafe * _speedWalk * Time.deltaTime * _playerTransform.right;
            }
        }

    }
}