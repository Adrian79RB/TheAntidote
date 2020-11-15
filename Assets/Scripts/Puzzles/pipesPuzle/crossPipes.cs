﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossPipes : PipeScript
{
    public override int checkPipes(int indice)
    {
        GameObject currentPipe = puzleManager.Pipes[connectedPipes[indice].i, connectedPipes[indice].j].gameObject;
        if (currentPipe.GetComponent<PipeScript>().connected)
        {
            if (currentPipe.GetComponent<PipeScript>().types == 2)
            {
                if (connectedPipes[indice].i < myI && (currentPipe.transform.eulerAngles.z == 180 || (currentPipe.transform.eulerAngles.z > 269 && currentPipe.transform.eulerAngles.z < 271)))
                    connected = true;
                else if (connectedPipes[indice].i > myI && (currentPipe.transform.eulerAngles.z == 0 || (currentPipe.transform.eulerAngles.z < 91 && currentPipe.transform.eulerAngles.z > 89)))
                    connected = true;
                else if (connectedPipes[indice].j < myJ && (currentPipe.transform.eulerAngles.z == 0 || (currentPipe.transform.eulerAngles.z > 269 && currentPipe.transform.eulerAngles.z < 271)))
                    connected = true;
                else if (connectedPipes[indice].j > myJ && (currentPipe.transform.eulerAngles.z == 180 || (currentPipe.transform.eulerAngles.z < 91 && currentPipe.transform.eulerAngles.z > 89)))
                    connected = true;
                else if (connected)
                    connected = false;
            }
            else if (currentPipe.GetComponent<PipeScript>().types == 3 || currentPipe.GetComponent<PipeScript>().types == 0 || currentPipe.GetComponent<PipeScript>().types == 1)
            {
                if ((connectedPipes[indice].i < myI || connectedPipes[indice].i > myI)
                    && ((currentPipe.transform.eulerAngles.z < 91 && currentPipe.transform.eulerAngles.z > 89) || (currentPipe.transform.eulerAngles.z > 269 && currentPipe.transform.eulerAngles.z < 271)))
                    connected = true;
                else if ((connectedPipes[indice].j < myJ || connectedPipes[indice].j > myJ)
                    && (currentPipe.transform.eulerAngles.z == 0 || currentPipe.transform.eulerAngles.z == 180))
                    connected = true;
                else if (connected)
                    connected = false;
            }
            return 0;
        }
        else
            return 1;
    }
}
