using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] InputActionReference actionReference;
    [SerializeField] PlayerInput playerInput;

    [Header("UI")]
    [SerializeField] string defaultKey = "Space";
    [SerializeField] TextMeshProUGUI jumpKeyLabel;
    [SerializeField] GameObject startBindingObject;
    [SerializeField] GameObject waitingForInputObject;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    {
        jumpKeyLabel.text = defaultKey;
    }
    public void StartRebinding()
    {
        // update UI
        startBindingObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        playerInput.SwitchCurrentActionMap("Player");

        actionReference.action.Disable();
        rebindingOperation = actionReference.action
            .PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithCancelingThrough("<Keyboard>/escape")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => FinishRebinding())
            .OnCancel(operation => FinishRebinding())
            .Start();
    }

    private void FinishRebinding()
    {
        rebindingOperation.Dispose();
        actionReference.action.Enable();

        // update UI
        int bindingIndex = actionReference.action.GetBindingIndexForControl(actionReference.action.controls[0]);
        jumpKeyLabel.text = InputControlPath.ToHumanReadableString(actionReference.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        startBindingObject.SetActive(true);
        waitingForInputObject.SetActive(false);
    }
}
