using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static GameManager _GM { get { return GameManager.instance; } }//brings our manager to our game manager
    protected static EnemyManager _EM { get { return EnemyManager.instance; } }
    protected static UIManager _UI { get { return UIManager.instance; } }
    public static List<T>ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp= _list[i];
            int randomIndex= UnityEngine.Random.Range(0, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;  
        }
        return _list;
    } 
}
