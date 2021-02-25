// GENERATED AUTOMATICALLY FROM 'Assets/Topics/Command Pattern/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ca3fdfc8-5e91-48b4-b9c8-e479f5ae42e4"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""98f98f6a-5299-4bb3-9e80-c91b8f094d69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""d334fe65-be9c-40bf-8544-0d42f20e4732"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""ac557c19-5a3a-4883-8c15-e08f8ee66e2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoForwards"",
                    ""type"": ""Button"",
                    ""id"": ""578965ce-24fd-4713-bf91-c7ae525db415"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b91c1abe-fd6f-4020-9178-4cf4cff65105"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15af4d69-5407-47aa-9f3c-17bc5bcfa1f3"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d09223f1-3653-47b0-be8a-52ac0ae12198"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db8d071d-c884-431e-8677-0e6ff01a871e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""GoForwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""474f05a1-e2dc-4f5c-aa9f-c780e1c831b4"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""5f8b866d-429c-44b1-8247-2fccd39eb2bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63633524-217f-4fc0-88bf-ed8a73967b34"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Global"",
            ""id"": ""468c947d-529d-432f-b49e-e42737274dcf"",
            ""actions"": [
                {
                    ""name"": ""Replay"",
                    ""type"": ""Button"",
                    ""id"": ""1818918e-5325-466d-a7b4-4cceb23793da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UndoLast"",
                    ""type"": ""Button"",
                    ""id"": ""c7cabc84-5126-4e81-b22c-a14686782ec2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4974c627-f75a-4745-8db3-492cf0c08c90"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Replay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd969258-d7cd-43b9-b575-89d0fa39cd76"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""UndoLast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Kick = m_Player.FindAction("Kick", throwIfNotFound: true);
        m_Player_Punch = m_Player.FindAction("Punch", throwIfNotFound: true);
        m_Player_GoForwards = m_Player.FindAction("GoForwards", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_Replay = m_Global.FindAction("Replay", throwIfNotFound: true);
        m_Global_UndoLast = m_Global.FindAction("UndoLast", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Kick;
    private readonly InputAction m_Player_Punch;
    private readonly InputAction m_Player_GoForwards;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Kick => m_Wrapper.m_Player_Kick;
        public InputAction @Punch => m_Wrapper.m_Player_Punch;
        public InputAction @GoForwards => m_Wrapper.m_Player_GoForwards;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Kick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Punch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @GoForwards.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoForwards;
                @GoForwards.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoForwards;
                @GoForwards.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoForwards;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @GoForwards.started += instance.OnGoForwards;
                @GoForwards.performed += instance.OnGoForwards;
                @GoForwards.canceled += instance.OnGoForwards;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_Replay;
    private readonly InputAction m_Global_UndoLast;
    public struct GlobalActions
    {
        private @Controls m_Wrapper;
        public GlobalActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Replay => m_Wrapper.m_Global_Replay;
        public InputAction @UndoLast => m_Wrapper.m_Global_UndoLast;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @Replay.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReplay;
                @Replay.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReplay;
                @Replay.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReplay;
                @UndoLast.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnUndoLast;
                @UndoLast.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnUndoLast;
                @UndoLast.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnUndoLast;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Replay.started += instance.OnReplay;
                @Replay.performed += instance.OnReplay;
                @Replay.canceled += instance.OnReplay;
                @UndoLast.started += instance.OnUndoLast;
                @UndoLast.performed += instance.OnUndoLast;
                @UndoLast.canceled += instance.OnUndoLast;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnGoForwards(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IGlobalActions
    {
        void OnReplay(InputAction.CallbackContext context);
        void OnUndoLast(InputAction.CallbackContext context);
    }
}
