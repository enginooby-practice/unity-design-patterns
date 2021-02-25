using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] InputActionReference jumpAction;
    [SerializeField] PlayerInput playerInput;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI jumpKeyLabel;
    [SerializeField] GameObject startBindingObject;
    [SerializeField] GameObject waitingForInputObject;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void StartRebinding()
    {
        // update UI
        startBindingObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        playerInput.SwitchCurrentActionMap("Player");

        jumpAction.action.Disable();
        rebindingOperation = jumpAction.action
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
        jumpAction.action.Enable();

        // update UI
        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);
        jumpKeyLabel.text = InputControlPath.ToHumanReadableString(jumpAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        startBindingObject.SetActive(true);
        waitingForInputObject.SetActive(false);
    }
}
