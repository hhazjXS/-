
﻿using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory_Life_Assistant
{
    public class Student
    {

        [Key]
        public String StudentId { get; set; }
        public String StudentName { get; set; }
        public String Gender { get; set; }
        public String Grade { get; set; }
        public String Class { get; set; } //所在班级
        public String Department { get; set; }//所在系
        public String BuildingName//所在宿舍楼栋
        {
            get;
            set;
        }
        public String DormNumber { get; set; }//所在宿舍号
        List<Payment> bill;
        List<Repair> repair;
        public List<Complaint> complain;
        List<ClockIn> clockIn;//打卡信息及历史打卡信息
        List<Schedule> schedule;
        //public String Password { get; set; }//密码
        public Blob Profile { get; set; }//头像
        public List<ExchangeMessage> myMessage;

        public void changePassword(string pass) { }//修改密码
        public void changeProfile() { }//修改头像


        public Student()
        {

        }

        public Student(string id/*, string dormNumber*/)
        {
            StudentId = id;
            //DormNumber = dormNumber;

        }
    }
}
  
