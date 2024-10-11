using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesMachine : MonoBehaviour
{
    BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if(currentState != null)
            currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if( currentState != null )
            currentState.UpdateLogic();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label(content);
    }
}
