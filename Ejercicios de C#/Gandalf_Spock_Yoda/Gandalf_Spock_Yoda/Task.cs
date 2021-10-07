﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalf_Spock_Yoda
{
    class Task
    {
        private int code;
        private InterfaceTask.TaskType taskType;
        private int score;

        public Task()
        {
            this.Code = RandomNumber.random_Number(1, 100);
            this.TaskType = (InterfaceTask.TaskType)RandomNumber.random_Number(0,3);
            this.Score = RandomNumber.random_Number(1, 5);

        }

        public int Code { get => code; set => code = value; }
        public InterfaceTask.TaskType TaskType { get => taskType; set => taskType = value; }
        public int Score { get => score; set => score = value; }
    }
}
