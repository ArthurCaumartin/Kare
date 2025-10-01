using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int _maxLevel;

    public int Level
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            if (_currentLevel > _maxLevel)
            {
                EndGame();
                return;
            }
            OnLevelChanged?.Invoke(_currentLevel);
        }
    }
    private int _currentLevel = 0;

    public delegate void LevelChangedEvent(int newLevel);
    public event LevelChangedEvent OnLevelChanged;


    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnLevelUp(InputValue value)
    {
        if (value.Get<float>() > 0.5f)
            Level++;
    }
}