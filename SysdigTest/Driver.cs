﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysdigTest
{
    public class Driver
    {
        public IWebDriver NewChromeDriver()
        { 
            return new ChromeDriver();
        }

    }
}
