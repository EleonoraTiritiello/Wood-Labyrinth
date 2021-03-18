﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WoodLabyrinth
{
    public class GyroController : MonoBehaviour
    {
        private bool gyroEnable;
        private Gyroscope gyro;

        private GameObject cameraContainer;
        private Quaternion rot;


        private void Start()
        {
            cameraContainer = new GameObject("Camera Container");
            cameraContainer.transform.position = transform.position;
            transform.SetParent(cameraContainer.transform);

            gyroEnable = EnableGyro();
        }

        private bool EnableGyro()
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0, 0, 1, 0);

                return true;
            }

            return false;
        }

        private void Update()
        {
            if (gyroEnable)
            {
                transform.localRotation = gyro.attitude * rot; 
            }
        }
    }

}
