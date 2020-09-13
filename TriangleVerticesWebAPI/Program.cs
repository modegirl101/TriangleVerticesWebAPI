﻿using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI
{
    class Program
    {
        const string url = "http://localhost:51634";
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server started at:" + url);
                Console.ReadLine();
            }
        }
    }
}
