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
        [SerializeField] private AudioSource audio;
        [SerializeField] private int row = 5;

        private KeyCode[] _currentKeyRow;
        private int _currentKey;
        private bool _start;
        private bool _startTimer;
        private float _timer;
        private int _playerLayer;
        private PlayerInputListener _playerInputListener;

        void Start()
        {
            _currentKeyRow = new KeyCode[row];
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
                    ResetQTE();
                    _playerInputListener.ResetPosition();
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
            audio.Play();
            StartCoroutine(QTEPreapare());
        }

        private void GenerateKeyRow()
        {
            for (int i = 0; i < row; i++)
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
                    ResetQTE();
                    return;
                }

                view.SetKey(_currentKeyRow[_currentKey].ToString());
                _start = true;
                return;
            }else if(!Input.GetKeyDown(_currentKeyRow[_currentKey]) && Input.anyKeyDown)
            {
                ResetQTE();
                _playerInputListener.ResetPosition();
            }
        }

        public void ResetQTE()
        {
            gameObject.SetActive(false);
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