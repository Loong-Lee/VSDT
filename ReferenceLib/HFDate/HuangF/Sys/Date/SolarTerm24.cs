﻿namespace HuangF.Sys.Date
{
    using System;

    public class SolarTerm24
    {
        public static string l_GetLunarHolDay(DateTime date1)
        {
            int num2;
            byte[] buffer = new byte[] { 
                150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                0x97, 0x87, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 120, 0x87, 
                150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 
                150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 
                0x95, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 
                0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x97, 150, 0x97, 0x87, 0x79, 0x79, 
                0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                0x95, 180, 150, 0xa6, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa5, 0x97, 150, 0x97, 0x87, 0x79, 0x79, 
                0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 0xa6, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa6, 
                0x97, 0x97, 120, 0x79, 120, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 0x97, 0x97, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 0x79, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 120, 0x79, 120, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 0x97, 0x97, 0x79, 0x79, 
                0x79, 0x69, 120, 120, 150, 0xa5, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 120, 0x79, 120, 0x68, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                0x79, 0x69, 120, 0x77, 150, 0xa5, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 150, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 0xb5, 150, 0xa5, 0xa6, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                120, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x89, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 150, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x79, 120, 0x87, 150, 180, 150, 0xa6, 150, 0x97, 120, 0x79, 
                120, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 
                120, 0x69, 120, 0x77, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 
                0xa5, 180, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 0x79, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                0xa5, 180, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                150, 150, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 0x86, 0x97, 0x88, 120, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 0x76, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                120, 0x79, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                0xa5, 0xb3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 0xa6, 0xa5, 
                0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 0x86, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 180, 0xa5, 0xa5, 
                0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                0xa6, 0xa6, 0x88, 120, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 0xb5, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xb5, 
                0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 0x88, 0x87, 150, 
                0xa5, 0xc3, 0xa5, 180, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xb5, 
                0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa5, 0x97, 0x87, 0x87, 0x88, 0x86, 150, 
                0xa4, 0xc3, 0xa5, 0xa5, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 0x86, 0xa5, 0xc3, 0xa5, 0xb5, 
                0xa6, 0xa6, 0x87, 0x88, 120, 120, 0x87, 0x87
             };
            string[] strArray = new string[] { 
                "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", 
                "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
             };
            int year = date1.Year;
            if ((year < 0x76d) || (year > 0x802))
            {
                return "";
            }
            int month = date1.Month;
            int day = date1.Day;
            byte num = buffer[(((year - 0x76d) * 12) + month) - 1];
            if (day < 15)
            {
                num2 = 15 - ((num >> 4) & 15);
            }
            else
            {
                num2 = (num & 15) + 15;
            }
            if (day != num2)
            {
                return "";
            }
            if (day > 15)
            {
                return strArray[((month - 1) * 2) + 1];
            }
            return strArray[(month - 1) * 2];
        }
    }
}
