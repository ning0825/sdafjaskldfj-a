﻿/************************************************************************************
 【PXR SDK】
 Copyright 2015-2020 Pico Technology Co., Ltd. All Rights Reserved.

************************************************************************************/

using UnityEngine;
using UnityEngine.XR;

namespace Unity.XR.PXR
{
    public class PXR_ControllerKeyEffects : MonoBehaviour
    {
        public Texture2D textureIdle;
        public Texture2D textureApp;
        public Texture2D textureHome;
        public Texture2D textureTouchpad;
        public Texture2D textureVolUp;
        public Texture2D textureVolDown;
        public Texture2D textureTrigger;
        public Texture2D textureA;
        public Texture2D textureB;
        public Texture2D textureX;
        public Texture2D textureY;
        public Texture2D textureGrip;

        public PXR_Input.Controller hand;
        private Renderer controllerRenderMat;
        private XRNode node;

        private bool lPrimary2DButton, rPrimary2DButton, lMenuButton, rMenuButton, lGripButton, rGripButton, lTriggerButton, rTriggerButton,x,y,a,b;
        private bool isHaveEmission = false;

        void Start()
        {
            controllerRenderMat = GetComponent<Renderer>();
            isHaveEmission = PXR_Input.GetActiveController() == PXR_Input.ControllerDevice.Neo3;
            switch (hand)
            {
                case PXR_Input.Controller.LeftController:
                    node = XRNode.LeftHand;
                    break;
                case PXR_Input.Controller.RightController:
                    node = XRNode.RightHand;
                    break;
            }
        }

        void Update()
        {
            GetButtonState(node);
            ChangeKeyEffects(node);
        }

        private void GetButtonState(XRNode node)
        {
            switch (node)
            {
                case XRNode.LeftHand:
                    {
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out lPrimary2DButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.menuButton, out lMenuButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.gripButton, out lGripButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.triggerButton, out lTriggerButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.primaryButton, out x);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.secondaryButton, out y);
                    }
                    break;
                case XRNode.RightHand:
                    {
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.primary2DAxisClick, out rPrimary2DButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.menuButton, out rMenuButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.gripButton, out rGripButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.triggerButton, out rTriggerButton);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.primaryButton, out a);
                        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.secondaryButton, out b);
                    }
                    break;
            }
        }

        private void ChangeKeyEffects(XRNode node)
        {
            switch (node)
            {
                case XRNode.LeftHand:
                    {
                        if (lPrimary2DButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureTouchpad);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureTouchpad);
                        }
                        else if (lMenuButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureApp);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureApp);
                        }
                        else if (lTriggerButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureTrigger);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureTrigger);
                        }
                        else if (x)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureX);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureX);
                        }
                        else if (y)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureY);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureY);
                        }
                        else if (lGripButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureGrip);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureGrip);
                        }
                        else
                        {
                            if (controllerRenderMat.material.GetTexture("_MainTex") != textureIdle)
                            {
                                controllerRenderMat.material.SetTexture("_MainTex", textureIdle);
                                if (isHaveEmission)
                                    controllerRenderMat.material.SetTexture("_EmissionMap", textureIdle);
                            }
                        }
                    }
                    break;
                case XRNode.RightHand:
                    {
                        if (rPrimary2DButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureTouchpad);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureTouchpad);
                        }
                        else if (rMenuButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureApp);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureApp);
                        }
                        else if (rTriggerButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureTrigger);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureTrigger);
                        }
                        else if (a)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureA);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureA);
                        }
                        else if (b)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureB);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureB);
                        }
                        else if (rGripButton)
                        {
                            controllerRenderMat.material.SetTexture("_MainTex", textureGrip);
                            if (isHaveEmission)
                                controllerRenderMat.material.SetTexture("_EmissionMap", textureGrip);
                        }
                        else
                        {
                            if (controllerRenderMat.material.GetTexture("_MainTex") != textureIdle)
                            {
                                controllerRenderMat.material.SetTexture("_MainTex", textureIdle);
                                if (isHaveEmission)
                                    controllerRenderMat.material.SetTexture("_EmissionMap", textureIdle);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
