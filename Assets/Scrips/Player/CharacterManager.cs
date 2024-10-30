using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instnace;
    
    public static CharacterManager Instance
    {
        get
        {
            if (_instnace == null)
            {
                _instnace = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instnace;
        }
    }

    public Player _player;

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        if(_instnace != null)
        {
            _instnace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(_instnace == this)
            {
                Destroy(gameObject);
            }
        }
    }

}
