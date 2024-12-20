//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Source/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""16d8636a-13c7-4f39-a84d-508c26dc7917"",
            ""actions"": [
                {
                    ""name"": ""Dragging"",
                    ""type"": ""Value"",
                    ""id"": ""b11575cf-69e6-4f45-b833-5eabcbc80ef5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DragStarted"",
                    ""type"": ""Button"",
                    ""id"": ""8bcb855a-2523-495a-a63e-9e0cdab74067"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraDragging"",
                    ""type"": ""Value"",
                    ""id"": ""73b07fa5-c206-491b-add1-bb060e9d9d88"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c04d7fb-89ec-4c42-b168-cd452c1f4f5e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerEditor"",
                    ""action"": ""Dragging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71f3de96-e621-480e-a179-75dd0fea7228"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerEditor"",
                    ""action"": ""Dragging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d86027d0-0201-4cc3-841f-aa651eaddaa3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerEditor"",
                    ""action"": ""DragStarted"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89466c17-0c1e-4259-bd14-a09f6c6244c8"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerEditor"",
                    ""action"": ""DragStarted"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ca84b22-5816-444a-b388-5a80b8828f0b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraDragging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddc878ef-bc4f-4277-bcbf-71826b5c8d5d"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraDragging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerEditor"",
            ""bindingGroup"": ""PlayerEditor"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Dragging = m_Player.FindAction("Dragging", throwIfNotFound: true);
        m_Player_DragStarted = m_Player.FindAction("DragStarted", throwIfNotFound: true);
        m_Player_CameraDragging = m_Player.FindAction("CameraDragging", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Dragging;
    private readonly InputAction m_Player_DragStarted;
    private readonly InputAction m_Player_CameraDragging;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dragging => m_Wrapper.m_Player_Dragging;
        public InputAction @DragStarted => m_Wrapper.m_Player_DragStarted;
        public InputAction @CameraDragging => m_Wrapper.m_Player_CameraDragging;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Dragging.started += instance.OnDragging;
            @Dragging.performed += instance.OnDragging;
            @Dragging.canceled += instance.OnDragging;
            @DragStarted.started += instance.OnDragStarted;
            @DragStarted.performed += instance.OnDragStarted;
            @DragStarted.canceled += instance.OnDragStarted;
            @CameraDragging.started += instance.OnCameraDragging;
            @CameraDragging.performed += instance.OnCameraDragging;
            @CameraDragging.canceled += instance.OnCameraDragging;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Dragging.started -= instance.OnDragging;
            @Dragging.performed -= instance.OnDragging;
            @Dragging.canceled -= instance.OnDragging;
            @DragStarted.started -= instance.OnDragStarted;
            @DragStarted.performed -= instance.OnDragStarted;
            @DragStarted.canceled -= instance.OnDragStarted;
            @CameraDragging.started -= instance.OnCameraDragging;
            @CameraDragging.performed -= instance.OnCameraDragging;
            @CameraDragging.canceled -= instance.OnCameraDragging;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PlayerEditorSchemeIndex = -1;
    public InputControlScheme PlayerEditorScheme
    {
        get
        {
            if (m_PlayerEditorSchemeIndex == -1) m_PlayerEditorSchemeIndex = asset.FindControlSchemeIndex("PlayerEditor");
            return asset.controlSchemes[m_PlayerEditorSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnDragging(InputAction.CallbackContext context);
        void OnDragStarted(InputAction.CallbackContext context);
        void OnCameraDragging(InputAction.CallbackContext context);
    }
}
