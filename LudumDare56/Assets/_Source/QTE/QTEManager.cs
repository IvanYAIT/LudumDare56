using Player;
using System.Collections;
using UnityEngine;

namespace QTE
{
    public class QTEManager : MonoBehaviour
    {
        [SerializeField] private KeyCode[] keys;
        [SerializeField] private QTEView view;
        [SerializeField] private int timeToPressAllKey;
        [SerializeField] private LayerMask playerLayerMask;

        private int _row = 5;
        private KeyCode[] _currentKeyRow;
        private int _currentKey;
        private bool _start;
        private bool _startTimer;
        private float _timer;
        private int _playerLayer;
        private PlayerInputListener _playerInputListener;

        void Start()
        {
            _currentKeyRow = new KeyCode[_row];
            _currentKey = 0;
            _timer = timeToPressAllKey;
            _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        }

        void Update()
        {
            if (_start)
            {
                CheckKeyPress();
            }
            if( _startTimer)
            {
                if(_timer <= 0)
                {
                    Debug.Log("fail");
                    ResetQTE();
                }
                else
                {
                    view.SetTimer(_timer);
                    _timer -= Time.deltaTime;

                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == _playerLayer)
            {
                _playerInputListener = other.GetComponent<PlayerInputListener>();
                StartQTE();
            }
        }

        public void StartQTE()
        {
            GenerateKeyRow();
            view.KeyTextObject.SetActive(true);
            view.TimerTextObject.SetActive(true);
            view.SetKey(_currentKeyRow[_currentKey].ToString());
            _playerInputListener.TurnInput();
            StartCoroutine(QTEPreapare());
        }

        private void GenerateKeyRow()
        {
            for (int i = 0; i < _row; i++)
            {
                _currentKeyRow[i] = keys[Random.Range(0, keys.Length)];
            }
        }

        private void CheckKeyPress()
        {
            if (Input.GetKeyDown(_currentKeyRow[_currentKey]))
            {
                _currentKey++;
                if(_currentKey >= _currentKeyRow.Length)
                {
                    Debug.Log("win");
                    ResetQTE();
                    return;
                }

                view.SetKey(_currentKeyRow[_currentKey].ToString());
                _start = true;
                return;
            }else if(!Input.GetKeyDown(_currentKeyRow[_currentKey]) && Input.anyKeyDown)
            {
                Debug.Log("fail wrong key");
                ResetQTE();
            }
        }

        public void ResetQTE()
        {
            _playerInputListener.TurnInput();
            _start = false;
            _currentKey = 0;
            _timer = timeToPressAllKey;
            _startTimer = false;
            view.TimerTextObject.SetActive(false);
            view.KeyTextObject.SetActive(false);
            view.ResetText();
        }

        private IEnumerator QTEPreapare()
        {
            yield return new WaitForSeconds(1);
            _start = true;
            _startTimer = true;
        }
    }
}