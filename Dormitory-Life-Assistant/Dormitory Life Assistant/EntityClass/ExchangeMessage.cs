﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dormitory_Life_Assistant
{
    public class ExchangeMessage
    {
        public string ExchangeMessageID { get; set; }//主键
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public string SupervisorId { get; set; }//发送信息的宿管ID，外键
        public string SupervisorName
        {
            get
            {
                return Supervisor.SupervisorName;
            }
        }
        public Supervisor Supervisor { get; set; }
        public string StudentId { get; set; }
        public string StudentName
        {
            get
            {
                return Student.StudentName;
            }
        }
        public Student Student { get; set; }
        public ExchangeMessage() 
        {
            ExchangeMessageID = Guid.NewGuid().ToString();
            Time = DateTime.Now;
        }
        public ExchangeMessage(string content,Student student,Supervisor supervisor)
        {
            ExchangeMessageID = Guid.NewGuid().ToString();
            Content = content;
            Time = DateTime.Now;
            this.Supervisor = supervisor;
            this.Student = student;
        }
    }
}