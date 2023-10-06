//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Character/Controls/CharacterControls.inputactions
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

public partial class @CharacterControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControls"",
    ""maps"": [
        {
            ""name"": ""GroundMovement"",
            ""id"": ""9a68d892-87f3-49df-8579-f2fe01f422a5"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3001fdb-8124-4ea5-aa85-47addfb53eaf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0278a016-d3a2-496f-8c50-7055f3ad8544"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""31162fd6-4131-4161-9926-e16bf5785dc9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e6900615-c447-4be4-8013-74da6888b4c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b438aa74-6b56-4d05-ad8c-5842bad1fc1e"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0523f303-bc33-418e-a289-d31afb6518d9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7cf6b4f2-ade7-4cfa-add0-ff0ad180da87"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""df5ee0a9-cb64-4e3c-9dd3-8fb02312bb6e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9a2bea7b-b17d-4f86-bce3-80702955fa53"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fb8ec9c0-0f60-4fe8-b237-1adf0822ddbd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""23d8c4d4-71d5-4ce3-b75d-942e7d9815d4"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""760f0306-f255-43cd-9f71-ef0fc23bb05b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""2DMovement"",
            ""id"": ""d65b3e30-5bc6-4720-92f7-47ffacbfc022"",
            ""actions"": [
                {
                    ""name"": ""2dMovers"",
                    ""type"": ""Value"",
                    ""id"": ""2c7998a4-594f-49b1-893c-6abbb0cccd91"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d50663a6-dc16-4769-9e04-eec353f9c94a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2dMovers"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8b3295ea-7077-4d3c-b04a-2c7b48f51584"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2dMovers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""51924284-3bf8-407d-8da6-e062819d472e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2dMovers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d1a7fcc8-be5a-495e-97d8-0c1d14bae6c0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2dMovers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""852c958b-4103-45fa-bc67-49dbb69b9183"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2dMovers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GroundMovement
        m_GroundMovement = asset.FindActionMap("GroundMovement", throwIfNotFound: true);
        m_GroundMovement_HorizontalMovement = m_GroundMovement.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_GroundMovement_MouseY = m_GroundMovement.FindAction("MouseY", throwIfNotFound: true);
        m_GroundMovement_MouseX = m_GroundMovement.FindAction("MouseX", throwIfNotFound: true);
        m_GroundMovement_Jump = m_GroundMovement.FindAction("Jump", throwIfNotFound: true);
        // 2DMovement
        m__2DMovement = asset.FindActionMap("2DMovement", throwIfNotFound: true);
        m__2DMovement__2dMovers = m__2DMovement.FindAction("2dMovers", throwIfNotFound: true);
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

    // GroundMovement
    private readonly InputActionMap m_GroundMovement;
    private List<IGroundMovementActions> m_GroundMovementActionsCallbackInterfaces = new List<IGroundMovementActions>();
    private readonly InputAction m_GroundMovement_HorizontalMovement;
    private readonly InputAction m_GroundMovement_MouseY;
    private readonly InputAction m_GroundMovement_MouseX;
    private readonly InputAction m_GroundMovement_Jump;
    public struct GroundMovementActions
    {
        private @CharacterControls m_Wrapper;
        public GroundMovementActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_GroundMovement_HorizontalMovement;
        public InputAction @MouseY => m_Wrapper.m_GroundMovement_MouseY;
        public InputAction @MouseX => m_Wrapper.m_GroundMovement_MouseX;
        public InputAction @Jump => m_Wrapper.m_GroundMovement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_GroundMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundMovementActions set) { return set.Get(); }
        public void AddCallbacks(IGroundMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_GroundMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GroundMovementActionsCallbackInterfaces.Add(instance);
            @HorizontalMovement.started += instance.OnHorizontalMovement;
            @HorizontalMovement.performed += instance.OnHorizontalMovement;
            @HorizontalMovement.canceled += instance.OnHorizontalMovement;
            @MouseY.started += instance.OnMouseY;
            @MouseY.performed += instance.OnMouseY;
            @MouseY.canceled += instance.OnMouseY;
            @MouseX.started += instance.OnMouseX;
            @MouseX.performed += instance.OnMouseX;
            @MouseX.canceled += instance.OnMouseX;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IGroundMovementActions instance)
        {
            @HorizontalMovement.started -= instance.OnHorizontalMovement;
            @HorizontalMovement.performed -= instance.OnHorizontalMovement;
            @HorizontalMovement.canceled -= instance.OnHorizontalMovement;
            @MouseY.started -= instance.OnMouseY;
            @MouseY.performed -= instance.OnMouseY;
            @MouseY.canceled -= instance.OnMouseY;
            @MouseX.started -= instance.OnMouseX;
            @MouseX.performed -= instance.OnMouseX;
            @MouseX.canceled -= instance.OnMouseX;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IGroundMovementActions instance)
        {
            if (m_Wrapper.m_GroundMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGroundMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_GroundMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GroundMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GroundMovementActions @GroundMovement => new GroundMovementActions(this);

    // 2DMovement
    private readonly InputActionMap m__2DMovement;
    private List<I_2DMovementActions> m__2DMovementActionsCallbackInterfaces = new List<I_2DMovementActions>();
    private readonly InputAction m__2DMovement__2dMovers;
    public struct _2DMovementActions
    {
        private @CharacterControls m_Wrapper;
        public _2DMovementActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @_2dMovers => m_Wrapper.m__2DMovement__2dMovers;
        public InputActionMap Get() { return m_Wrapper.m__2DMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_2DMovementActions set) { return set.Get(); }
        public void AddCallbacks(I_2DMovementActions instance)
        {
            if (instance == null || m_Wrapper.m__2DMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m__2DMovementActionsCallbackInterfaces.Add(instance);
            @_2dMovers.started += instance.On_2dMovers;
            @_2dMovers.performed += instance.On_2dMovers;
            @_2dMovers.canceled += instance.On_2dMovers;
        }

        private void UnregisterCallbacks(I_2DMovementActions instance)
        {
            @_2dMovers.started -= instance.On_2dMovers;
            @_2dMovers.performed -= instance.On_2dMovers;
            @_2dMovers.canceled -= instance.On_2dMovers;
        }

        public void RemoveCallbacks(I_2DMovementActions instance)
        {
            if (m_Wrapper.m__2DMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(I_2DMovementActions instance)
        {
            foreach (var item in m_Wrapper.m__2DMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m__2DMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public _2DMovementActions @_2DMovement => new _2DMovementActions(this);
    public interface IGroundMovementActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface I_2DMovementActions
    {
        void On_2dMovers(InputAction.CallbackContext context);
    }
}
